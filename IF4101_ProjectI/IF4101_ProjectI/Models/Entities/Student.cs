using System;
using System.Collections.Generic;

#nullable disable

namespace IF4101_ProjectI.Models.Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
