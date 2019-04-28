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
    public class SchoolTestCases
    {
        [Test]
        public void getSchoolTestCases()
        {
            DataTable dt = new DataTable();
            dt = SchoolService.GetSchools();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getSchoolByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = SchoolService.GetSchoolsById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}
