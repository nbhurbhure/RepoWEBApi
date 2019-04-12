namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonthInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public string YearInfoName { get; set; }
        public int FYearInfoId { get; set; }
    }
}
