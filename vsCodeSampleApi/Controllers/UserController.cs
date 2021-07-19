using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csCodeSampleApi.Models;
using vsCodeSampleApi.Data;

namespace vsCodeSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SampleContext _context;

        public UserController(SampleContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestUser>>> GetTestUsers()
        {
            return await _context.TestUsers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestUser>> GetTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);

            if (testUser == null)
            {
                return NotFound();
            }

            return testUser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestUser(int id, TestUser testUser)
        {
            if (id != testUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(testUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestUser>> PostTestUser(TestUser testUser)
        {
            _context.TestUsers.Add(testUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestUser", new { id = testUser.Id }, testUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestUser(int id)
        {
            var testUser = await _context.TestUsers.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }

            _context.TestUsers.Remove(testUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestUserExists(int id)
        {
            return _context.TestUsers.Any(e => e.Id == id);
        }
    }
}
