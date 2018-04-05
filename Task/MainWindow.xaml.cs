using System;
using System.Collections.ObjectModel;
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

        ObservableCollection<Student> listOfStudents;
        Confirm confirmWindow;
        public MainWindow()
        {

            InitializeComponent();
            //задаем цвет рамки textbox'ов
            studentFirstNameTextBox.BorderBrush = Brushes.Aquamarine;
            studentAgeTextBox.BorderBrush = Brushes.Aquamarine;
            studentLastNameTextBox.BorderBrush = Brushes.Aquamarine;

            listOfStudents = new ObservableCollection<Student>();

            //подписываем DataGrid на событие изменения содержимого ячейки
            DataGrid.CellEditEnding += myDG_CellEditEnding;
            // Читаем из файла xml файла в Datagrid
            new MyVieWModel(listOfStudents).ReadFromXmlFileToDataGrid("C:/Users/Никита/Documents/Visual Studio 2015/Projects/StudentList/StudentList/Students.xml", DataGrid);
        }

    }
}
