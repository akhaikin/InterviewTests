using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; }
        public List<Course> Courses { get; } = new List<Course>();
        public STANDING Standing { get; set; } = STANDING.None;
        public static STANDING CalculateStanding(double average)
        {
            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude; //MagnaCumLaude;
            return standing;
        }
        public static bool hasGraduated(STANDING standing)
        {
            bool result = false;
            switch (standing)
            {
                case STANDING.Average:
                case STANDING.SumaCumLaude:
                case STANDING.MagnaCumLaude:
                    {
                        result = true;
                        break;
                    }
            }
            return result;
        }

        public Student(int id)
        {
            Id = id;
        }

        public Course AddCourse(Course.enValues enValue)
        {
            var course = new Course(this, enValue);
            Courses.Add(course);
            return course;
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma)
        {
            var credits = 0;
            double average = 0;
            var requirements = Repository.GetRequirements();
            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                var requirement = Repository.GetRequirement(requirements, diploma.Requirements[i]);
                for (int j = 0; j < Courses.Count; j++)
                {
                    for (int k = 0; k < requirement.Courses.Count; k++)
                    {
                        if (requirement.Courses[k] == Courses[j].Id)
                        {
                            average += Courses[j].Mark;
                            if (Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            average = average / Courses.Count;

            var standing = Student.CalculateStanding(average);

            bool hasGraduated = Student.hasGraduated(standing);

            var result = new Tuple<bool, STANDING>(hasGraduated, standing);
            return result;
        }
    }
}
