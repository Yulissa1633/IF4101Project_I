using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IF4101_ProjectI.Models.Entities
{
    public partial class UserProfile
    {
        public string Name { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public int Id { get; set; }
    }
}
