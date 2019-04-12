namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleScreenMapping
    {
        public int Id { get; set; }
        public string VroleName { get; set; }
        public string ScreenName { get; set; }
        public int FVroleId { get; set; }
        public int FScreenId { get; set; }
    }
}
