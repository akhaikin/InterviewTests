using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestRepositoryGetRequirements()
        {
            var requirements = Repository.GetRequirements();
            Assert.AreEqual(4, requirements.Length);
            Assert.AreEqual(100, requirements[0].Id);
            Assert.AreEqual(102, requirements[1].Id);
            Assert.AreEqual(103, requirements[2].Id);
            Assert.AreEqual(104, requirements[3].Id);

            Assert.AreEqual("Math", requirements[0].Name);
            Assert.AreEqual("Science", requirements[1].Name);
            Assert.AreEqual("Literature", requirements[2].Name);
            Assert.AreEqual("Physichal Education", requirements[3].Name);
        }

        [TestMethod]
        public void TestRepositoryGetStudent()
        {
            var student = Repository.GetStudent(-1);
            Assert.AreEqual(null, student);
            student = Repository.GetStudent(5);
            Assert.AreEqual(null, student);

            student = Repository.GetStudent(1);
            Assert.AreEqual(1, student.Id);
            Assert.AreEqual(4, student.Courses.Count);
            for (int i1 = 0; i1 < 4; i1++)
            {
                int mark = student.Courses[i1].Mark;
                Assert.AreEqual(95, mark);
            }

            student = Repository.GetStudent(2);
            Assert.AreEqual(2, student.Id);
            Assert.AreEqual(4, student.Courses.Count);
            for (int i1 = 0; i1 < 4; i1++)
            {
                int mark = student.Courses[i1].Mark;
                Assert.AreEqual(80, mark);
            }
        }

        [TestMethod]
        public void TestHasCredits()
        {
            var diploma = Repository.GetDiploma(1);
            Assert.AreNotEqual(null, diploma);
            var students = Repository.GetStudentsAll();
            Assert.AreEqual(4, students.Length);
            foreach (var student in students)
            {
                Assert.AreEqual(4, student.Courses.Count);
            }
            var tp = students[0].HasGraduated(diploma);
            Assert.AreEqual(true, tp.Item1);
            Assert.AreEqual(STANDING.SumaCumLaude, tp.Item2);

            tp = students[1].HasGraduated(diploma);
            Assert.AreEqual(true, tp.Item1);
            Assert.AreEqual(STANDING.MagnaCumLaude, tp.Item2);

            tp = students[2].HasGraduated(diploma);
            Assert.AreEqual(true, tp.Item1);
            Assert.AreEqual(STANDING.Average, tp.Item2);

            tp = students[3].HasGraduated(diploma);
            Assert.AreEqual(false, tp.Item1);
            Assert.AreEqual(STANDING.Remedial, tp.Item2);

        }


    }
}
