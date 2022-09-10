using System;
using System.Collections.Generic;

namespace WebAPIDBFirst.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? SName { get; set; }
        public string? SAddress { get; set; }
        public int? Deptid { get; set; }

        public virtual Department? Dept { get; set; }
    }
}
