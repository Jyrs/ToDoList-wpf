using System;
using System.IO;
using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            StreamReader reader;
            bool isLoginSuccessful = false;

            try
            {
                reader = new StreamReader("accounts.txt");


                while (!reader.EndOfStream)
                {
                    string buff = reader.ReadLine();
                    string[] buff_split = buff.Split(' ');

                    if (TextBox_Login.Text == buff_split[0] && TextBox_Password.Password == buff_split[1])
                    {
                        reader.Close();
                        isLoginSuccessful = true;
                        MainWindow toDoListWindow = new MainWindow(TextBox_Login.Text, Convert.ToInt16(buff_split[2]));
                        toDoListWindow.Show();
                        this.Close();
                        break;

                    }

                }

                if (!isLoginSuccessful) MessageBox.Show("Incorrect login or password", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "runtime error");

            }


        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWin = new RegisterWindow();
            registerWin.ShowDialog();
        }
    }
}
