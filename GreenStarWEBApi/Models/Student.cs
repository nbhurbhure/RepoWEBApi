namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Caste { get; set; }
        public string SectionName { get; set; }
        public int FSectionId { get; set; }
    }
}
