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
    public class DayInfoTestCases
    {
        [Test]
        public void getDayInfoTestCases()
        {
            DataTable dt = new DataTable();
            dt = DayInfoService.GetDayInfos();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getDayInfoByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = DayInfoService.GetDayInfosById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}