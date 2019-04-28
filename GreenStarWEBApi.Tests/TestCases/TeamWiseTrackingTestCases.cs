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
    public class TeamWiseTrackingTestCases
    {

        [Test]
        public void getTeamWiseTrackingTestCases()
        {
            DataTable dt = new DataTable();
            dt = TeamWiseTrackingService.GetTeamWiseTrackings();
            Assert.IsTrue(dt!=null);
        }
        [Test]
        public void getTeamWiseTrackingByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = TeamWiseTrackingService.GetTeamWiseTrackingsById(id);
            Assert.IsTrue(dt!=null);
        }
    }
}