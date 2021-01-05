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
    public class SchoolBddFluentTests
    {
        private School schoolSUT;

        private Mock<ISchoolDatabase> databaseMock;

        private bool result;

        /// <summary>
        /// BDDfy Fluent API
        /// read more: https://teststackbddfy.readthedocs.io/en/latest/
        /// </summary>
        [TestMethod]
        public void Execute()
        {
            var studentToBeRegistered = new Student();

            this.Given(s => s.GivenStudentExists(studentToBeRegistered))
                .When(s => s.WhenITryToRegister(studentToBeRegistered))
                .Then(s => s.ThenIGet(false), "Then the School Register should return False")
                    .And(s => s.AndThatRegisterIsNotCalled(studentToBeRegistered))
                .BDDfy("Same test with Fluent API");
        }

        void GivenStudentExists(Student studentToBeRegistered)
        {
            databaseMock = new Mock<ISchoolDatabase>();
            databaseMock.Setup(db => db.DoesStudentExist(studentToBeRegistered)).Returns(true);

            schoolSUT = new School(databaseMock.Object);
        }

        void WhenITryToRegister(Student studentToBeRegistered)
        {
            result = schoolSUT.RegisterStudent(studentToBeRegistered);
        }

        void ThenIGet(bool expected)
        {
            Assert.AreEqual(expected, result);
        }

        void AndThatRegisterIsNotCalled(Student studentToBeRegistered)
        {
            databaseMock.Verify(db => db.Register(studentToBeRegistered), Times.Never(), "when student exists, it shouldn't be added to the db");
        }
    }
}
