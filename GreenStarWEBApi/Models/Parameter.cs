namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SchoolName { get; set; }
        public int FSchoolId { get; set; }
    }
}
