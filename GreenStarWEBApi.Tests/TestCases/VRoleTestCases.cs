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
    public class VRoleTestCases
    {
        [Test]
        public void getVroleTestCases()
        {
            DataTable dt = new DataTable();
            dt = VroleService.GetVroles();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getVroleByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = VroleService.GetVrolesById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}