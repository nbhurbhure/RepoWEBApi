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
    public class StandardTestCases
    {
        [Test]
        public void getStandardTestCases()
        {
            DataTable dt = new DataTable();
            dt = StandardService.GetStandards();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getStandardByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = StandardService.GetStandardsById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}