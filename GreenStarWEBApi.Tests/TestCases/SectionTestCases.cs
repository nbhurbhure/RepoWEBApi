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
    public class SectionTestCases
    {
        [Test]
        public void getSectionTestCases()
        {
            DataTable dt = new DataTable();
            dt = SectionService.GetSections();
            Assert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void getSectionByIdTestCases()
        {
            DataTable dt = new DataTable();
            int id = 1;
            dt = SectionService.GetSectionsById(id);
            Assert.IsTrue(dt.Rows.Count > 0);
        }
    }
}