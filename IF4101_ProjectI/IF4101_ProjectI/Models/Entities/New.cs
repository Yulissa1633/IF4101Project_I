using System;
using System.Collections.Generic;

#nullable disable

namespace IF4101_ProjectI.Models.Entities
{
    public partial class New
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
