namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExcelData
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string SchoolNam { get; set; }
        public string SchoolAddress { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public string TeacherNam { get; set; }
        public string StudentNam { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string TeamNam { get; set; }
        public string LeaderNam { get; set; }
        public string ParameterNam { get; set; }
        public string Marks { get; set; }
    }
}
