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
    public class TeacherTestCases
    {
        [Test]
        public void getTeacherTestCases()
        {
            DataTable dt = new DataTable();
            dt = TeacherService.GetTeachers();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getTeacherByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = TeacherService.GetTeachersById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}