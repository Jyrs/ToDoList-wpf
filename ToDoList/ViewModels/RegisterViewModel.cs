using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace ToDoList.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _login;
        public SecureString SecurePassword { private get; set; }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
