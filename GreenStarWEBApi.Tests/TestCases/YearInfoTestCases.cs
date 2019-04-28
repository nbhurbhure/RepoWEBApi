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
    public class YearInfoTestCases
    {
        [Test]
        public void getYearInfoTestCases()
        {
            DataTable dt = new DataTable();
            dt = YearInfoService.GetYearInfos();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getYearInfoByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = YearInfoService.GetYearInfosById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}