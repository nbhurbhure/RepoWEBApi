namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Standard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SchoolName { get; set; }
        public int FSchoolId { get; set; }
    }
}
