using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Service;

namespace GreenStarWEBApi.TestCases
{
    [TestFixture]
    public class TeamTestCases
    {
        [Test]
        public void getTeamTestCases()
        {
            DataTable dt = new DataTable();
            dt = TeamService.GetTeams();
            
            Assert.IsTrue(dt !=null);
        }
        [Test]
        public void getTeamByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = TeamService.GetTeamsById(id);
            Assert.IsTrue(dt !=null);
        }
    }
}
