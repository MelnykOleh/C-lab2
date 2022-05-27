using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csharp
{
    class Person : IDateAndCopy
    {
        protected string _name;
        protected string _surname;
        protected DateTime _birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person() : this(name: "Oleh", surname: "Melnyk", birthday: new DateTime(2001, 8, 27))
        { }

        public string Name
        {
            get
            {
                return _name;
            }

            init
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }

            init
            {
                _surname = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }

            set
            {
                _birthday = value;
            }
        }

        public int Year
        {
            get
            {
                return Birthday.Year;
            }

            set
            {

                Birthday = new DateTime(Birthday.Year + value, Birthday.Month, Birthday.Day);
            }
        }

        DateTime IDateAndCopy.Date { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public override string ToString()
        {
            return $"Name:{Name}\tSurname: {Surname}\tBirthday: {Birthday}\n";
        }

        public string ToShortString()
        {
            return $"Name: {Name}\tSurname: {Surname}\n";
        }

        //функція нижче, порівнює значення змінних двох обєктів даного касу
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Person person = (Person)obj;
            return person.Name == Name && person.Surname == Surname && person.Birthday == Birthday;
        }

        //нижче додані перевизначені оператори порівнянь
        public static bool operator == (Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator != (Person person1, Person person2)
        {
            return !(person1.Equals(person2));
        }

        //GetHashCode() потрібний щоб генерувати хеш коди об'єктів 
        //по яких вони будуть порівнюватись. Ця перевірка виконується перед 
        //Equals() і якщо вона дає позитивний результат тоді виконується порівняння з використанням Equals() 
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() *  +  Birthday.GetHashCode() ;
        }

        //DeepCopy() використовуємо для копіювання об'єктів класів
        object IDateAndCopy.DeepCopy()
        {
            return MemberwiseClone();
        }

        public virtual object DeepCopy()
        {
            return new Person();
        }
    }
}
