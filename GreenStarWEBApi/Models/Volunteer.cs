namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string VPassword { get; set; }
        public string VroleName { get; set; }
        public string SchoolName { get; set; }
        public int FVroleId { get; set; }
        public int FSchoolId { get; set; }
    }
}
