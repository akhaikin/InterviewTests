using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Requirement
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
                _IDs[(int)enValues.Math] = 100;
                _IDs[(int)enValues.Science] = 102;
                _IDs[(int)enValues.Literature] = 103;
                _IDs[(int)enValues.PhysichalEducation] = 104;
            }
            return _IDs;
        }
        public static int[] GetAllIDs()
        {
            return getIDs();
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
        /*
        private static Dictionary<int, string> _data;
        private static Dictionary<int, string> getData()
        {
            if (_data == null)
            {
                _data = new Dictionary<int, string>();
                for (int i = 0; i < csDataCount; i++ )
                {
                    _data.Add(getIDs()[i], getNames()[i]);
                }
            }
            return _data;
        }
        */
        //private string _name;
        public int Id { get; }
        public string Name { get; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public List<int> Courses { get; } = new List<int>();
        public Requirement(enValues enValue)
        {
            Id = getIDs()[(int)enValue];
            Name = getNames()[(int)enValue];
            MinimumMark = 50;
            Credits = 1;
        }
        public static Requirement[] CreateAll()
        {
            var result = new Requirement[csDataCount];
            for (int i = 0; i < csDataCount; i++)
            {
                result[i] = new Requirement((enValues)i);
            }
            result[(int)enValues.Math].Courses.Add(Course.GetId(Course.enValues.Math));
            result[(int)enValues.Literature].Courses.Add(Course.GetId(Course.enValues.Literature));
            result[(int)enValues.Science].Courses.Add(Course.GetId(Course.enValues.Science));
            result[(int)enValues.PhysichalEducation].Courses.Add(Course.GetId(Course.enValues.PhysichalEducation));
            return result;
        }
    }
}
