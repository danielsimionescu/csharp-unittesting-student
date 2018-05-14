using Microsoft.VisualStudio.TestTools.UnitTesting;
using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTests
{
    [TestClass]
    class TeacherTests
    {
        private Teacher _teacher;

        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void TestName()
        {
            _teacher.Name = "Poul";
            Assert.AreEqual("Poul", _teacher.Name);

            try
            {
                _teacher.Name = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Name is null or empty", ex.Message);
            }
        }

        [TestMethod]
        public void TestSalary()
        {
            _teacher.Salary = 5000;
            Assert.AreEqual(5000, _teacher.Salary);
            try
            {
                _teacher.Salary = -1;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Salary error", ex.Message);
            }
            try
            {
                _teacher.Salary = 0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Salary error", ex.Message);
            }
        }
    }
}
