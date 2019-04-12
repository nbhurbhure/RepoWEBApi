namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentStatus { get; set; }
        public string YearInfoName { get; set; }
        public string MonthInfoName { get; set; }
        public string DayInfoName { get; set; }
        public string StudentName { get; set; }
        public string ParameterName { get; set; }
        public int FYearInfoId { get; set; }
        public int FMonthInfoId { get; set; }
        public int FDayInfoId { get; set; }
        public int FStudentId { get; set; }
        public int FParameterId { get; set; }
    }
}
