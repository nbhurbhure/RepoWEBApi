namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Principal { get; set; }
        public string CityName { get; set; }
        public int FCityId { get; set; }
    }
}
