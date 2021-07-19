using System.ComponentModel.DataAnnotations;

namespace csCodeSampleApi.Models
{
    public class TestUser
    {
        public TestUser()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        
    }
}