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
    public class StudentTestCases
    {
        [Test]
        public void getStudentTestCases()
        {
            DataTable dt = new DataTable();
            dt = StudentService.GetStudents();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getStudentByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = StudentService.GetStudentsById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}