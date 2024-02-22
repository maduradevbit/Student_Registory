using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        
        public DateTime createDateTime {  get; set; }= DateTime.Now;

    }
}
