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
    public class RoleScreenMappingTestCases
    {
        [Test]
        public void getRoleScreenMappingTestCases()
        {
            DataTable dt = new DataTable();
            dt = RoleScreenMappingService.GetRoleScreenMappings();

            Assert.IsTrue(dt.Rows.Count>0);
        }
        [Test]
        public void getRoleScreenMappingByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = RoleScreenMappingService.GetRoleScreenMappingsById(id);
            Assert.IsTrue(dt.Rows.Count>0);
        }
    }
}