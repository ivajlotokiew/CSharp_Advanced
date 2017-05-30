namespace _11.Students_Joined_to_Specialties
{
    public class Student
    {
        public Student(string studentName, string facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }

        public string StudentName { get; set; }

        public string FacultyNumber { get; set; }
    }
}