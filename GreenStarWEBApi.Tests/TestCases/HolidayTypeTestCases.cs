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
    public class HolidayTypeTestCases
    {
        [Test]
        public void getHolidayTypeTestCases()
        {
            DataTable dt = new DataTable();
            dt = HolidayTypeService.GetHolidayTypes();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getHolidayTypeByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = HolidayTypeService.GetHolidayTypesById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}