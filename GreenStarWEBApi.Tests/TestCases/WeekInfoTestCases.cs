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
    public class WeekInfoTestCases
    {
        [Test]
        public void getWeekInfoTestCases()
        {
            DataTable dt = new DataTable();
            dt = WeekInfoService.GetWeekInfos();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getWeekInfoByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = WeekInfoService.GetWeekInfosById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}