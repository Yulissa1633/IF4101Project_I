using System;
using System.Collections.Generic;

#nullable disable

namespace IF4101_ProjectI.Models.Entities
{
    public partial class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public string Semester { get; set; }
        public string Description { get; set; }
    }
}
