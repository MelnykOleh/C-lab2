using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csharp
{
    class Exam : IDateAndCopy
    {
        private string _subject;
        private int _grade;
        private DateTime _date;

        public Exam(string subject, int grade, DateTime date)
        {
            Subject = subject;
            Grade = grade;
            Date = date;
        }

        public Exam() : this(subject: "Mathematics", grade: 4, date: new DateTime(2022, 5, 26)) 
        { }

        public string Subject
        {
            get
            {
                return _subject;
            }

            set
            {
                _subject = value;
            }
        }

        public int Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                _grade = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        DateTime IDateAndCopy.Date { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public override string ToString()
        {
            return $"\nSubject: {Subject}\tGrade: {Grade} \tDate exam: {Date}\n";
        }

        object IDateAndCopy.DeepCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Exam exam = (Exam)obj;

            return exam.Subject == Subject && exam.Grade == Grade && exam.Date == Date;
        }

        public static bool operator ==(Exam exam1, Exam exam2)
        {
            return exam1.Equals(exam2);
        }

        public static bool operator !=(Exam exam1, Exam exam2)
        {
            return !(exam1.Equals(exam2));
        }

        public override int GetHashCode()
        {
            return Subject.GetHashCode()  + Grade.GetHashCode() + Date.GetHashCode();
        }
    }
}
