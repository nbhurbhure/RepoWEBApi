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
    public class HolidayTestCases
    {
        [Test]
        public void getHolidayTestCases()
        {
            DataTable dt = new DataTable();
            dt = HolidayService.GetHolidays();
            Assert.IsTrue(dt.Rows.Count>0);
        }
        [Test]
        public void getHolidayByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = HolidayService.GetHolidaysById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}