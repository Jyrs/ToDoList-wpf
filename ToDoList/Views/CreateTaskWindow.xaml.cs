using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using System.Data.SQLite;
using ToDoList.Core;
using static System.Windows.Media.ColorConverter;


namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для CreateTask.xaml
    /// </summary>
    public partial class CreateTaskWindow : Window
    {

        public string TaskName => TextBox_TaskName.Text;
        public string DescriptionTask => TextBox_TaskDescription.Text;

        public bool HighPriority
        {
            get
            {
                if (TextBox_TaskHighPriority.IsChecked == null) return false;
                return (bool)TextBox_TaskHighPriority.IsChecked;
            }
        }

        public CreateTaskWindow()
        {
            InitializeComponent();
        }

        private void ButtonEnterAddTask_OnClick(object sender, RoutedEventArgs e)
        {
            if(TextBox_TaskName.Text.Length == 0) 
                TextBox_TaskName.Background = new SolidColorBrush((Color)ConvertFromString("#FFE1E1"));
            else
            {
                SQLiteConnection connection = DBConnection.GetConnection();
                //string cmd = $"INSERT INTO Task(Title_Task, Description_Task) VALUES('{TextBox_TaskName.Text}, {TextBox_TaskDescription.Text});";
                
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = connection.CreateCommand();

                sqlite_cmd.CommandText = $"INSERT INTO Tasks(Title_Task, Description_Task, ID_User) VALUES('{TextBox_TaskName.Text}', '{TextBox_TaskDescription.Text}', '{null}');";

                sqlite_cmd.ExecuteNonQuery();
                connection.Close();
                //DialogResult = true;
                this.Close();
            }
        }
        }
}
