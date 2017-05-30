using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _11.Students_Joined_to_Specialties
{
    public class StartUp
    {
        public static void Main()
        {
            var students = new List<Student>();
            var studentsSpecialities = new List<StudentSpecialty>();

            while (true)
            {
                string dataRow = Console.ReadLine();
                if (dataRow == "Students:")
                {
                    break;
                }

                var indexBetweenSpecialitiesData = dataRow.LastIndexOf(" ");
                var speciality = dataRow.Substring(0, indexBetweenSpecialitiesData).Trim();
                string fNum = dataRow.Substring(indexBetweenSpecialitiesData + 1).Trim();

                studentsSpecialities.Add(new StudentSpecialty(speciality, fNum));
            }

            while (true)
            {
                string dataRow = Console.ReadLine();
                if (dataRow == "END")
                {
                    break;
                }

                var inexBetweenStudentsData = dataRow.IndexOf(" ");
                var fNum = dataRow.Substring(0, inexBetweenStudentsData).Trim();
                var name = dataRow.Substring(inexBetweenStudentsData + 1).Trim();

                students.Add(new Student(name, fNum));
            }

            var query = studentsSpecialities.Join(students,
                o => o.FacultyNumber, i => i.FacultyNumber, (o, i) => new
                {
                    StName = i.StudentName,
                    facNumb = o.FacultyNumber,
                    specName = o.SpecialtyName,
                }).OrderBy(x => x.StName);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.StName} {item.facNumb} {item.specName}");
            }
        }

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
}