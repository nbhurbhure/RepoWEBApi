namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamWiseTracking
    {
        public int Id { get; set; }
        public string TeamNam { get; set; }
        public string ParameterNam { get; set; }
        public string StudentStatus { get; set; }
    }
}
