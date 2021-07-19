using System.ComponentModel.DataAnnotations;

namespace vsCodeSampleApi.Models
{
    public class TestRole
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public TestRole()
        {
        }
    }
}