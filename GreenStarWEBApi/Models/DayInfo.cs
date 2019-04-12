namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DayInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
        public string MonthInfoName { get; set; }
        public int FMonthInfoId { get; set; }
    }
}
