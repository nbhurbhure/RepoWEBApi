namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HolidayTypeName { get; set; }
        public string YearInfoName { get; set; }
        public string MonthInfoName { get; set; }
        public string DayInfoName { get; set; }
        public string SchoolName { get; set; }
        public int FHolidayTypeId { get; set; }
        public int FYearInfoId { get; set; }
        public int FMonthInfoId { get; set; }
        public int FDayInfoId { get; set; }
        public int FSchoolId { get; set; }
    }
}
