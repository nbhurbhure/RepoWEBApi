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
    public class MonthInfoTestCases
    { 
        [Test]
        public void getMonthInfoTestCases()
        {
            DataTable dt = new DataTable();
            dt = MonthInfoService.GetMonthInfos();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getMonthInfoByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = MonthInfoService.GetMonthInfosById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}