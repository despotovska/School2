using System;

namespace School
{
    public class School
    {
        public ISchoolDatabase SchoolDatabase { get; private set; }

        public School(ISchoolDatabase schoolDatabase)
        {
            SchoolDatabase = schoolDatabase;
        }

        public bool RegisterStudent(Student student)
        {
            //throw new NotImplementedException();

            if (!SchoolDatabase.DoesStudentExist(student))
            {
                return SchoolDatabase.Register(student);
            }

            return false;
        }
    }
}
