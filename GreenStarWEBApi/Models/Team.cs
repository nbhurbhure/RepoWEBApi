namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int TeamLead { get; set; }
        public string StandardName { get; set; }
        public int FStandardId { get; set; }
    }
}
