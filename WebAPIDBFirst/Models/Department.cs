using System;
using System.Collections.Generic;

namespace WebAPIDBFirst.Models
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Sname { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
