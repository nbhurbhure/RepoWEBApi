using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Web;
using WebAPI.Controllers;
using WebAPI.Service;

namespace GreenStarWEBApi.TestCases
{
    [TestFixture]
    public class cityTestCases
    {
        [Test]
        public void GetCitysTestCase()
        {
            //Assign
            DataTable dt=new DataTable();

            //Act
            dt = CityService.GetCitys();

            //Assert
            Assert.IsTrue(dt.Rows.Count >=1);
        }

        [Test]
        public void GetCitysByIdTestCase()
        {
            //Assign
            DataTable dt = new DataTable();
            int Id = 1;
            //Act
            dt = CityService.GetCitysById(Id);

            //Assert
            Assert.IsTrue(dt.Rows.Count >= 1);
        }
    }
}