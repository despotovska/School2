namespace School
{
    public interface ISchoolDatabase
    {
        bool Register(Student student);

        bool DoesStudentExist(Student student);
    }
}