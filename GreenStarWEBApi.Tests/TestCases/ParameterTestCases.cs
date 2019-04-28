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
    public class ParameterTestCases
    {
        [Test]
        public void getParameterTestCases()
        {
            DataTable dt = new DataTable();
            dt = ParameterService.GetParameters();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getParameterByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = ParameterService.GetParametersById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }


}