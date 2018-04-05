using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Text.RegularExpressions;
namespace TaskI
{ 
    public partial class MainWindow : Window
    {
        void myDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) //Обрабочик события изменения содержимого ячейки
        {

            if (e.EditAction == DataGridEditAction.Commit)
            {
                
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    dynamic bindingPaths=null;
                    dynamic bindingPath1=null, bindingPath2=null;
                    try
                    {
                        bindingPaths = (column.Binding as MultiBinding).Bindings.ToArray();
                        bindingPath1 = (bindingPaths[0] as Binding).Path.Path;
                        bindingPath2 = (bindingPaths[1] as Binding).Path.Path;
                    }
                    catch (Exception)
                    {
                        bindingPath1 = (column.Binding as Binding).Path.Path;
                    } 
                    
                    //получаем имя столбца,в котором было изменено содержимое
                    var textBox = e.EditingElement as TextBox;
                    
                    int rowIndex = e.Row.GetIndex();
                    var arrayStudents = listOfStudents.ToArray();
                    if (bindingPath1 == "Name")//Ищем столбец, в котором было изменено содержимое
                    {
                        if (textBox.Text.Length == 0)//если пустая строка
                        {
                            errorLabel.Content = "Cell is empty";
                            textBox.Foreground = Brushes.Red;
                        }
                        string[] array;
                        
                        int countWords = 0;
                        array = textBox.Text.Split(' ');
                        if (array.Length >= 2)//проверяем два ли слова в ячейке(имя,фамилия)
                        {
                            string[] array1=new string[2];
                            int j = 0;
                            for (int i=0; i < array.Length; i++)
                            {
                                if (!String.IsNullOrEmpty(array[i]))
                                {
                                    countWords++;//считаю слова
                                    if (j < 2)
                                    {
                                        array1[j] = array[i];
                                        j++;
                                    }
                                }
                            }
                            array = array1;                         
                        }
                        if (countWords < 2)//если введено слишком мало слов
                        {
                            errorLabel.Content = "Please,input first name or second name must ";
                            textBox.Foreground = Brushes.Red;
                            textBox.Text = "";
                            textBox.Text = arrayStudents[rowIndex].Name + " " + arrayStudents[rowIndex].LastName;
                        }
                        else if (countWords > 2)//если введено слишком много слов
                        {
                            errorLabel.Content = "Was inputted too many words";
                            textBox.Foreground = Brushes.Red;
                            textBox.Text = "";
                            textBox.Text = arrayStudents[rowIndex].Name + " " + arrayStudents[rowIndex].LastName;
                        }                   
                        else//если все хорошо
                        {
                            arrayStudents[rowIndex].Name = array[0];
                            arrayStudents[rowIndex].LastName = array[1];
                            listOfStudents.RemoveAt(rowIndex);//удаляем старого студента 
                            listOfStudents.Add(arrayStudents[rowIndex]);//добавляем нового
                            textBox.Foreground = Brushes.Gray;
                        }
                    }
                    if (bindingPath1 == "Age")
                    {
                        try
                        {
                            string[] array = textBox.Text.Split(' ');//заносим в массив отдельно количество лет и слово,например,"лет"
                            Convert.ToInt32(array[0]);
                            arrayStudents[rowIndex].SetPostfixForAge(array[0]);
                            listOfStudents.RemoveAt(rowIndex);//удаляем старого студента 
                            listOfStudents.Add(arrayStudents[rowIndex]);//добавляем нового
                            DataGrid.ItemsSource = listOfStudents;
                        }
                        catch (FormatException)
                        {
                            errorLabel.Content = "Please,input number";
                            textBox.Text = arrayStudents[rowIndex].Age;//возвращаем предидущее значение
                        }
                    }
                    if (bindingPath1 == "Gender")
                    {
                        if (textBox.Text != "Man" || textBox.Text != "Woman")
                        {
                            errorLabel.Content = "Please,input Man or Woman";
                            textBox.Text = arrayStudents[rowIndex].Gender;
                        }
                    }
                }
            }
            DataGrid.IsReadOnly = false;

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string gender = manRadioButton.IsChecked == true ? "Man" : "Woman";
            Regex regExp = new Regex("[a-zA-Zа-яА-Я]");
            string firstName = studentFirstNameTextBox.Text;
            string lastName = studentLastNameTextBox.Text;
            string age = studentAgeTextBox.Text;
            bool add=true;
            if (!regExp.IsMatch(firstName))//Если имя введено неверно
            {           
                studentFirstNameTextBox.BorderBrush = Brushes.Red;//задаем красный цвет рамки
                errorLabel.Content = "Please,input name";//задаем сообщение ошибки
                add = false;
            }
            else
            {
                studentFirstNameTextBox.BorderBrush = Brushes.Aquamarine;
            }
            if (!regExp.IsMatch(lastName))//Если имя введено неверно
            {
                studentLastNameTextBox.BorderBrush = Brushes.Red;//задаем красный цвет рамки

                if ((errorLabel.Content).ToString() != "")
                    errorLabel.Content = errorLabel.Content + ",last name";//задаем сообщение ошибки
                else
                {
                    errorLabel.Content = "Please,input last name";//задаем сообщение ошибки
                }
                add = false;
            }
            else
            {
                studentLastNameTextBox.BorderBrush = Brushes.Aquamarine;//если все введено правильно задаем цвет рамки Aquamarine
            }
            regExp = new Regex("[0-9]");
            if (!regExp.IsMatch(age) && age!="")//Если имя введено неверно
            {
                int newAge=0;                   
                    try
                    {
                        newAge = Convert.ToInt32(age);
                        if (newAge < 16 || newAge > 100)
                            throw new IndexOutOfRangeException();
                    }
                    catch (Exception)
                    {
                    errorLabel.Content = "Please,input number from 16 to 100 ";
                    }
                    
                
                studentAgeTextBox.BorderBrush = Brushes.Red;//задаем красный цвет рамки
                if ((errorLabel.Content).ToString() != "")
                    errorLabel.Content = errorLabel.Content + " age";
                else
                {
                    errorLabel.Content = "Please,input age";
                }
                add = false;
            }
            else
            {
                studentAgeTextBox.BorderBrush = Brushes.Aquamarine;//если все введено правильно задаем цвет рамки Aquamarine
            }

            if (listOfStudents.Count == 0)//если в спеске нет элементво
            {
                DataGrid.Visibility = Visibility.Visible ;//делаем видимым datagrid
                labelListEmpty.Visibility= Visibility.Hidden;//"прячем" labelListEmpty
                deleteBtn.IsEnabled = true; //делаем кнопку активной
            }
            if (add==true)
            {
                var student = new Student(firstName, lastName, age, gender);
                listOfStudents.Add(student);
                DataGrid.ItemsSource = listOfStudents;
                errorLabel.Content = "";
            }
            
        }      
        private void deleteBtn_Click(object sender, RoutedEventArgs e)//обработка собтия нажатия на кнопку deleteBtn 
        {
            int count = DataGrid.SelectedItems.Count;
            bool answer = true;           
            confirmWindow = new Confirm();
            confirmWindow.Owner = this;
            if (count > 1)//Если выбрано несколько строк выводим сообщение в новом окне "Are you sure?"
            {
                confirmWindow.ShowDialog();
                answer = confirmWindow.Answer;//получение ответа
            }
            if (answer == true && count>0)//в случае получения положительного ответа и что выбрано несколько строк
                {
                   
                    for (int i = 0; i < count; i++)//удаляем строки
                    {
                        DataGridRow row = new DataGridRow();
                            try
                            {
                             listOfStudents.RemoveAt(DataGrid.SelectedItems.IndexOf(DataGrid.SelectedItems[0]));
                            }
                            catch (Exception)
                            {
                            
                            }                       
                    }
                }           
            if (listOfStudents.Count == 0)
            {
                deleteBtn.IsEnabled = false;
                DataGrid.Visibility = Visibility.Hidden;
                labelListEmpty.Visibility = Visibility.Visible;
            }

        } 


    }
}
