using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.BDDfy;

namespace School.Tests
{
    [TestClass]
    [Story(
        AsA = "As a Student",
        IWant = "I want to register in School",
        SoThat = "So that I can study :)")]
    public class SchoolBddTests
    {
        private School schoolSUT;

        private Student studentToBeRegistered;
        private Mock<ISchoolDatabase> databaseMock;

        private bool result;

        /// <summary>
        /// BDDfy Reflective API
        /// BDDfy uses reflection to scan your classes for steps. 
        /// In this mode, known as reflective mode, it has two ways of finding a step: using attributes and method name conventions. 
        /// read more: https://teststackbddfy.readthedocs.io/en/latest/
        /// </summary>
        [TestMethod]
        public void Execute()
        {
            this.BDDfy();
        }

        // Must start in Given
        // You can override step text using executable attributes
        [Given("Given the student already exists")]
        void GivenStudentExists()
        {
            studentToBeRegistered = new Student();

            databaseMock = new Mock<ISchoolDatabase>();
            databaseMock.Setup(db => db.DoesStudentExist(studentToBeRegistered)).Returns(true);

            schoolSUT = new School(databaseMock.Object);
        }

        // Must start in When
        void WhenITryToRegister()
        {
            result = schoolSUT.RegisterStudent(studentToBeRegistered);
        }

        // Must start in Then
        void ThenIGetFalse()
        {
            Assert.IsFalse(result);
        }

        // Must start in And
        void AndThatRegisterIsNotCalled()
        {
            databaseMock.Verify(db => db.Register(studentToBeRegistered), Times.Never(), "when student exists, it shouldn't be added to the db");
        }
    }
}
