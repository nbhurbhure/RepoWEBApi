namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WeekInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkingDay { get; set; }
        public int FSchoolId { get; set; }
    }
}
