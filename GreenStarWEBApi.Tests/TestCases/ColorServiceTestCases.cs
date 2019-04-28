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
    public class ColorServiceTestCases
    {
        [Test]
        public void GetColorsTestCase()
        {
            //Assign
            DataTable dt = new DataTable();

            //Act
            dt = ColorService.GetColors();

            //Assert
            Assert.IsTrue(dt.Rows.Count >= 1);
        }

        [Test]
        public void GetColorsByIdTestCase()
        {
            //Assign
            DataTable dt = new DataTable();

            int id = 1;
            //Act
            dt = ColorService.GetColorsById(id);

            //Assert
            Assert.IsTrue(dt.Rows.Count >= 1);
        }
    }
}