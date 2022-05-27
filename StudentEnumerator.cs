using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csharp
{
    //інтерфейс IEnumerator дозволяє перебирати внутріщні об'єкти в контейнері
    class StudentEnumerator : Student, IEnumerator
    {
        private ArrayList? exams;
        private ArrayList? tests;
        private ArrayList? result;
        private int position = -1;


        public StudentEnumerator(ArrayList exams, ArrayList tests)
        {
            this.exams = exams;
            this.tests = tests;
            result = new ArrayList();
        }
        public object? Current
        {
            get
            {
                if (position == -1 || position >= exams?.Count)
                {
                    throw new ArgumentException();
                }

                foreach (string nameExam in exams)
                {
                    foreach (string nameTest in tests)
                    {
                        if (nameExam == nameTest)
                        {
                            result?.Add(nameExam);
                        }
                    }
                }
                exams.Clear();
                exams = result;
                return exams[position];
            }
        }
        
        public bool MoveNext()
        {
            if (position < exams?.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }
}

