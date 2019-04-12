namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StandardName { get; set; }
        public int FStandardId { get; set; }
    }
}
