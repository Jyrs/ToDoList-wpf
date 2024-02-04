using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Create_ClickOn(object sender, RoutedEventArgs e)
        {
            if (TextBox_Login.Text != "" && TextBox_Login.Text != "")
            {
                string Login = TextBox_Login.Text.Replace(" ", "");
                using (StreamWriter writer = new StreamWriter("accounts.txt", true, System.Text.Encoding.Default))
                {
                    writer.WriteLine(Login + " " + TextBox_Password.Password);
                    writer.Close();
                }

                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is empty", "Error");
            }

        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword; }

        }


    }


}
