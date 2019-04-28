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
    public class OutreachTestCases
    {
        [Test]
        public void getOutreachTestCases()
        {
            DataTable dt = new DataTable();
            dt = OutreachService.GetOutreachs();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getOutreachByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = OutreachService.GetOutreachsById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }

}