namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IndividualTracking
    {
        public int Id { get; set; }
        public string SchoolNam { get; set; }
        public string RollNo { get; set; }
        public string StudentNam { get; set; }
        public string StudentCaste { get; set; }
        public string DayInfo { get; set; }
        public string MonthInfo { get; set; }
        public string YearInfo { get; set; }
        public string ParameterNam { get; set; }
        public string DataValue { get; set; }
    }
}
