using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using People;

namespace StudentTests
{
    [TestClass]
    public class StudentTests
    {
        private Student _student1;
        private Student _student2;
        private Student _student3;

        [TestInitialize]
        public void Initialize()
        {
            _student1 = new Student { Name = "Matthew", Semester = 2, Address = "Longby", Gender = Genders.Male };
            _student2 = new Student { Name = "Matthew", Semester = 2, Address = "Longby", Gender = Genders.Male };
            _student3 = new Student { Name = "Paula", Semester = 6, Address = "Longby", Gender = Genders.Female };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameNullOrEmptyTest()
        {
            var name = string.Empty;
            _student1.Name = name;
            Assert.AreNotEqual(_student1.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentNameShortTest()
        {
            const string name = "A";
            _student1.Name = name;
            Assert.AreNotEqual(_student1, name);
        }


        [TestMethod()]
        public void StudentTest1()
        {

        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.AreEqual(_student1, _student2);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Assert.AreNotEqual(_student1, _student3);
        }

        [TestMethod()]
        public void SameTest1()
        {
            Assert.AreSame(_student1, _student1);
        }

        [TestMethod()]
        public void SameTest2()
        {
            Assert.AreNotSame(_student1, _student2);
        }


        [TestMethod()]
        public void GetHashCodeTest()
        {

        }
    }
}
