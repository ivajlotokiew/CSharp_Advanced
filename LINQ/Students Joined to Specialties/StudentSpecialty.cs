namespace _11.Students_Joined_to_Specialties
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string specialtyName, string facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecialtyName { get; set; }

        public string FacultyNumber { get; set; }
    }
}