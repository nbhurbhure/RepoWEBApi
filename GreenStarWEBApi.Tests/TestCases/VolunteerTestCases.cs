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
    public class VolunteerTestCases
    {
        [Test]
        public void getVolunteerTestCases()
        {
            DataTable dt = new DataTable();
            dt = VolunteerService.GetVolunteers();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getVolunteerByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = VolunteerService.GetVolunteersById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}
