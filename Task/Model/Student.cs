using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskI
{
    class Student
    {

        string name, lastName, gender,age;
      
        public string Name { get {return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName= value; } }
        public string Gender { get { return gender; } set {gender = value; } }
        public string Age { get { return age; } set {SetPostfixForAge(value); } }
        public Student()
        {

        }
        public Student(string name, string lastName, string age, string gender)
        {
            string[] array = age.Split(' ');
            if (array.Length == 1)
                this.age = SetPostfixForAge(age);
            else this.Age = "0";
            this.name = name;
            this.lastName = lastName;
            this.gender = gender;
        }
      public string SetPostfixForAge(string age)//функция для добавления постфикса
        {
            try
            {

                if (Convert.ToInt32(age) >=5 && Convert.ToInt32(age)<=20){ age = age + " лет";this.age = age; return age; }
               
                int lastNumberOfAge = Convert.ToInt32(age) % 10;
                if (lastNumberOfAge == 1)
                    age = age + " год";
                else if (lastNumberOfAge >= 2 && lastNumberOfAge <= 4)
                    age = age + " года";
                else
                    age = age + " лет";
                this.age = age;
            }
            catch (Exception)
            {
                Age = "0";
            }
           
            return age; 
        }

        public override string ToString()
        {
            StringBuilder student = new StringBuilder();
            int lastNumberOfAge = Convert.ToInt32(age) % 10;
            if (lastNumberOfAge == 1)
                student.Append(name + " " + lastName + " " + age + " год");
            else if (lastNumberOfAge >= 2 && lastNumberOfAge <= 4)
                student.Append(name + " " + lastName + " " + age + " года");
            else
                student.Append(name + " " + lastName + " " + age + " лет");
            return student.ToString();
        }

    }
}
