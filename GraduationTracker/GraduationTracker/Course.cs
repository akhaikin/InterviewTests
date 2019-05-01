using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Course
    {
        public enum enValues
        {
            Math = 0,
            Science,
            Literature,
            PhysichalEducation
        }
        private const int csDataCount = 4;
        private static int[] _IDs;
        private static int[] getIDs()
        {
            if (_IDs == null)
            {
                _IDs = new int[csDataCount];
                _IDs[(int)enValues.Math] = 1;
                _IDs[(int)enValues.Science] = 2;
                _IDs[(int)enValues.Literature] = 3;
                _IDs[(int)enValues.PhysichalEducation] = 4;
            }
            return _IDs;
        }
        public static int GetId(enValues enValue)
        {
            return getIDs()[(int)enValue];
        }
        private static string[] _Names;

        private static string[] getNames()
        {
            if (_Names == null)
            {
                _Names = new string[csDataCount];
                _Names[(int)enValues.Math] = "Math";
                _Names[(int)enValues.Science] = "Science";
                _Names[(int)enValues.Literature] = "Literature";
                _Names[(int)enValues.PhysichalEducation] = "Physichal Education";
            }
            return _Names;
        }

        private Student _student;
        public int Id { get; }
        public string Name { get; }
        public int Mark { get; set; }
        public int Credits { get; }
        public Course(Student student, enValues enValue)
        {
            Id = getIDs()[(int)enValue];
            Name = getNames()[(int)enValue];
            _student = student;
        }
     }
}
