using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csharp
{
    class Student : Person, IDateAndCopy
    {
        private Education _education;
        private int _group;
        protected ArrayList? _exams;
        protected ArrayList? _tests;

        public Student(Person person, Education education, int group)
        {
            Person = person;
            Educate = education;
            Group = group;
        }

        public Student() : this(person: new Person(), education: Education.Bachelor, group: 101)
        {
            Exams = new ArrayList() { new Exam(), new Exam("exam1", 5, new DateTime(2022, 6, 4)) };
            Tests = new ArrayList() { new Test(), new Test("test1", false), new Test("Java", true) };
        }

        public Person Person
        {
            get
            {
                return new Person(Name, Surname, Birthday);
            }
            init
            {
                Name = value.Name;
                Surname = value.Surname;
                Birthday = value.Birthday;
            }
        }


        public Education Educate
        {
            get
            {
                return _education;
            }
            init
            {
                _education = value;
            }
        }

        public int Group
        {
            get
            {
                return _group;
            }
            init
            {
                if (value <= 100 || value > 699)
                {
                    throw new Exception("Number group must be more than 100 and less than 700");
                }
                _group = value;
            }
        }

        public ArrayList? Exams
        {
            get
            {
                return _exams;
            }

            set
            {
                _exams = value;
            }
        }

        public ArrayList? Tests
        {
            get
            {
                return _tests;
            }

            set
            {
                _tests = value;
            }
        }

        public double AverageGrade
        {
            get
            {
                double average = 0;
                if (Exams == null || Exams.Count == 0) return 0;

                foreach (Exam exam in Exams)
                {
                    average += exam.Grade;
                }
                return average / Exams.Count;
            }
        }

        public bool this[Education educate]
        {
            get
            {
                return educate == Educate;
            }
        }

        public void AddExams(Exam[] newExams)
        {
            if (Exams == null)
            {
                Exams = new ArrayList();
            }

            int j = 0;
            while (j < newExams.Length)
            {
                Exams.Add(newExams[j]);
                j++;
            }
        }

        public void AddTests(Test[] newTests)
        {

            if (Tests == null)
            {
                Tests = new ArrayList();
            }

            int j = 0;
            while (j < newTests.Length)
            {
                Tests.Add(newTests[j]);
                j++;
            }
        }

        public override string ToString()
        {

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            if (Exams != null)
            {
                foreach (Exam ex in Exams)
                {
                    sb1.Append(ex);
                }
            }

            if (Tests != null)
            {
                foreach (Test test in Tests)
                {
                    sb2.Append(test);
                }
            }

            return $"Info about student:\n{Person}\nEducation: {Educate}\nGroup: {Group}\n\nList exams:\n\n{sb1}\nList zaliks:\n\n{sb2}\n";
        }

        public new string ToShortString()
        {
            return $"Info about student:\n{Person}\nEducation: {Educate}\nGroup: {Group}\nAverage grade: {AverageGrade}\n";
        }

        public override object DeepCopy()
        {
            ArrayList exams = new ArrayList();
            ArrayList tests = new ArrayList();
            if (Exams != null && Exams.Count != 0)
            {
                foreach (Exam ex in Exams)
                {
                    exams.Add(ex);
                }
            }

            if (Tests != null && Tests.Count != 0)
            {
                foreach (Test tes in Tests)
                {
                    tests.Add(tes);
                }
            }

            return new Student(person: (Person)Person.DeepCopy(), education: Educate, group: Group) { Exams = exams, Tests = tests };
        }

        object IDateAndCopy.DeepCopy()
        {
            return MemberwiseClone();
        }


        public ArrayList AllExamsAndTests()
        {
            ArrayList temp = new ArrayList();

            if (Exams != null)
            {
                foreach (Exam exam in Exams)
                {
                    temp.Add(exam);
                }
            }

            if (Tests != null)
            {
                foreach (Test test in Tests)
                {
                    temp.Add(test);
                }
            }
            return temp;
        }

        public ArrayList AllGoodExams(int grade)
        {

            ArrayList temp = new ArrayList();

            if (Exams != null)
            {
                foreach (Exam exam in Exams)
                {
                    if (exam.Grade > grade)
                    {
                        temp.Add(exam);
                    }
                }
            }

            return temp;
        }


        public ArrayList PassedTests()
        {
            ArrayList temp = new ArrayList();

            if (Tests != null)
            {
                foreach (Test test in Tests)
                {
                    if (test.Passed)
                    {
                        temp.Add(test);
                    }
                }
            }
            return temp;
        }

        public IEnumerator GetEnumerator()
        {

            ArrayList allExams = new ArrayList();
            ArrayList allTests = new ArrayList();

            if (Exams != null)
            {
                foreach (Exam exam in Exams)
                {
                    allExams.Add(exam.Subject);
                }
            }
            else
            {
                allExams.Add("Null");
            }

            if (Tests != null)
            {
                foreach (Test test in Tests)
                {
                    allTests.Add(test.Name);
                }
            }
            else
            {
                allTests.Add("Null");
            }

            return new StudentEnumerator(allExams, allTests);
        }

        public IEnumerable PassedTestsAndExams()
        {
            ArrayList goodExams = AllGoodExams(2);
            ArrayList passedTests = PassedTests();

            if (goodExams != null)
            {
                foreach (object exam in goodExams)
                {
                    yield return exam;
                }
            }

            if (passedTests != null)
            {
                foreach (object test in passedTests)
                {
                    yield return test;
                }
            }
        }



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Student student = (Student)obj;
            if (Exams != null && student.Exams != null)
            {
                if (Exams.Count != student.Exams.Count) return false;

                int i = 0;
                while (i < Exams.Count && Exams[i] != null && student.Exams[i] != null && Exams[i] == student.Exams[i])
                {
                    i++;
                }
                if (i < Exams.Count) return false;
                return student.Person == Person && student.Educate == Educate && student.Group == Group && student.Exams == Exams;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Student student1, Student student2)
        {

            return student1.Equals(student2);

        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }

        public override int GetHashCode()
        {
            int sum = 0;
            foreach (object obj in AllExamsAndTests())
            {
                sum += obj.GetHashCode();
            }
            return Person.GetHashCode() + Educate.GetHashCode() + Group.GetHashCode()  + sum;
        }

       
    }
}
