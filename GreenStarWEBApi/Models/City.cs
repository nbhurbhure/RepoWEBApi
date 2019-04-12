namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OutreachName { get; set; }
        public int FOutreachId { get; set; }
    }
}
