namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamStudentMapping
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string StudentName { get; set; }
        public int FTeamId { get; set; }
        public int FStudentId { get; set; }
    }
}
