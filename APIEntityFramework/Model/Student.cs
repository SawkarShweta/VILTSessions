using System.ComponentModel.DataAnnotations;

namespace APIEntityFramework.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Addess { get; set; }
    }
}
