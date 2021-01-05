using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace School.Tests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [Ignore("uncomment NotImplementedException to demo this one")]
        [ExpectedException(typeof(NotImplementedException))]
        public void ExpectedExceptionDemo()
        {
            // Arrange
            var sut = new School(new SchoolDatabase());

            // Act
            sut.RegisterStudent(new Student());
        }

        [TestMethod]
        public void RegisterStudent_WhenStudentAlreadyExists_ShouldReturnFalse()
        {
            // Arrange
            var studentToBeRegistered = new Student();

            var databaseMock = new Mock<ISchoolDatabase>();
            databaseMock.Setup(db => db.DoesStudentExist(studentToBeRegistered)).Returns(true);

            var sut = new School(databaseMock.Object);


            // Act
            var result = sut.RegisterStudent(studentToBeRegistered);


            // Assert
            Assert.IsFalse(result);
            databaseMock.Verify(db => db.Register(studentToBeRegistered), Times.Never(), "when student exists, it shouldn't be added to the db");
        }

        [TestMethod]
        public void Register_WhenStudentDoesntExist_ShouldReturnTrue()
        {
            // Arrange
            var studentToBeRegistered = new Student();

            var databaseMock = new Mock<ISchoolDatabase>();
            databaseMock.Setup(db => db.DoesStudentExist(studentToBeRegistered)).Returns(false);
            databaseMock.Setup(s => s.Register(studentToBeRegistered)).Returns(true);

            var sut = new School(databaseMock.Object);


            // Act
            var result = sut.RegisterStudent(studentToBeRegistered);


            // Assert
            Assert.IsTrue(result);
        }
    }
}
