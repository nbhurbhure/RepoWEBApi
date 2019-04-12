namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Login
    {
        public int Id { get; set; }
        public string UserNam { get; set; }
        public int Password { get; set; }
        public string OutreachName { get; set; }
        public string CityName { get; set; }
        public string SchoolName { get; set; }
        public int FOutreachId { get; set; }
        public int FCityId { get; set; }
        public int FSchoolId { get; set; }
    }
}
