using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IF4101_ProjectI.Models.Entities
{
    public partial class Inquirie
    {
        public int Id { get; set; }
        public string Inquirie1 { get; set; }
        public string Author { get; set; }
        public string Professor { get; set; }
        public string Type { get; set; }
    }
}
