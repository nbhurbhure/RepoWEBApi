namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComparativeChart
    {
        public int Id { get; set; }
        public string StandardNam { get; set; }
        public string SectionNam { get; set; }
        public string ParameterNam { get; set; }
        public string MonthNam { get; set; }
        public string MonthPercent { get; set; }
        public string IncreasePercent { get; set; }
    }
}
