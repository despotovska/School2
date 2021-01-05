using System;

namespace School
{
    public class SchoolDatabase: ISchoolDatabase
    {
        public bool Register(Student student)
        {
            if (!DoesStudentExist(student))
            {
                AddStudent();

                return true;
            }

            return false;
        }

        public bool DoesStudentExist(Student student)
        {
            return false;
        }

        private void AddStudent()
        {
            Console.WriteLine("Student Added");
        }
    }
}
