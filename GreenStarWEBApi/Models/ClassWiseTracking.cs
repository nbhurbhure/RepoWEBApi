namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassWiseTracking
    {
        public int Id { get; set; }
        public string StandardNam { get; set; }
        public string SectionNam { get; set; }
        public string ParameterNam { get; set; }
        public string StudentStatus { get; set; }
    }
}
