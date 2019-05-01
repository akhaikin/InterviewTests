using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            Student student = null;
            if (GetStudents().ContainsKey(id))
            {
                student = GetStudents()[id];
            }
            return student;
        }

        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = null;

            for (int i = 0; i < diplomas.Length; i++)
            {
                if (id == diplomas[i].Id)
                {
                    diploma = diplomas[i];
                }
            }
            return diploma;

        }
        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            Requirement requirement = GetRequirement(requirements, id);
            return requirement;
        }
        public static Requirement GetRequirement(Requirement[] requirements, int id)
        {
            Requirement requirement = null;

            for (int i = 0; i < requirements.Length; i++)
            {
                if (id == requirements[i].Id)
                {
                    requirement = requirements[i];
                    return requirement; //AK
                }
            }
            return requirement;
        }


        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = Requirement.GetAllIDs()
                }
            };
        }

        public static Requirement[] GetRequirements()
        {
            var result = Requirement.CreateAll();
            return result;
        }

        private static void addCourses(Student student, int mark)
        {
            for (Course.enValues i1 = Course.enValues.Math; i1 <= Course.enValues.PhysichalEducation; i1++)
            {
                Course course = student.AddCourse(i1);
                course.Mark = mark;
            }
        }
        private static Student[] _studentsAll;
        private static Dictionary<int, Student> _students;
        private static Dictionary<int, Student> GetStudents()
        {
            if (_students == null)
            {
                createStudents();
            }
            return _students;
        }
        private static void createStudents()
        {
            var marks = new int[] { 95, 80, 50, 40 };
            _studentsAll = new Student[4];
            _students = new Dictionary<int, Student>();
            int i2 = 0;
            for (int i1 = 0; i1 < _studentsAll.Length; i1++)
            {
                Student student = new Student(i1 + 1);
                _studentsAll[i1] = student;
                _students.Add(student.Id, student);
                addCourses(student, marks[i2]);
                if (i2 < marks.Length - 1)
                {
                    i2++;
                }
            }
        }

        public static Student[] GetStudentsAll()
        {
            if (_studentsAll == null)
            {
                createStudents();
            }
            return _studentsAll;
        }
    }


}
