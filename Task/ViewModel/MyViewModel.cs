using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Windows.Controls;
namespace TaskI
{
    public class MyVieWModel
    {
        XDocument xdoc;
        ObservableCollection<Student> listOfStudents;
        public MyVieWModel(object listOfStudents)
        {
            this.listOfStudents = (ObservableCollection < Student >)listOfStudents;
        }
        public void ReadFromXmlFileToDataGrid(string path,DataGrid Datagrid)//Читаем из файла xml файла в Datagrid
        {
            Student student;
            xdoc = XDocument.Load(path);
            foreach (XElement studentElement in xdoc.Element("Students").Elements("Student"))
            {
                //получаем значения по указанным атрибутам
                XAttribute idAttribute = studentElement.Attribute("Id");
                XElement firstNameElement = studentElement.Element("FirstName");
                XElement lastNameElement = studentElement.Element("Last");
                XElement ageElement = studentElement.Element("Age");
                XElement genderElement = studentElement.Element("Gender");

                if (idAttribute != null && lastNameElement != null && ageElement != null)//добавление элемента Student в список listOfStudets
                {
                    student = new Student();
                    //задаем значения свойств student'а соответствующими значениями из файла 
                    student.Name = firstNameElement.Value;
                    student.LastName = lastNameElement.Value;
                    int age1 = 0;

                    try
                    {
                        age1 = Convert.ToInt32(ageElement.Value);
                        if (age1 == 0)
                            continue;
                    }
                    catch (Exception)//если в файле была допущена ошибка,то не добавляем элемент в список 
                    {
                        continue;
                    }
                    student.Age = age1.ToString();
                    student.Gender = genderElement.Value == "0" ? "Man" : "Woman";
                    listOfStudents.Add(student);//добавляем элементы прочитанные из файла в список
                }
            }
            Datagrid.ItemsSource = listOfStudents;//задаем содержимое Datagrid
        }
        public int TestAge(String age)
        {
            int newAge = 0;
            try
            {
                newAge = Convert.ToInt32(age);
                if (newAge < 16 || newAge > 100)
                    throw new IndexOutOfRangeException();
            }
            catch (Exception)
            {
              
            }
            return newAge;
        }
    }
}
