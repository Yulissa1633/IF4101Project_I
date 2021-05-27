using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
