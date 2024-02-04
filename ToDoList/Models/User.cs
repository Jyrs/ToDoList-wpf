using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace ToDoList.Models
{
    internal class User : INotifyPropertyChanged
    {
        private int _id;
        private string _login; 
        private string _hashedPassword;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            } 
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string HashedPassword
        {
            get => _hashedPassword;
            set
            {
                _hashedPassword = value;
                OnPropertyChanged("HashedPassword");
            }
        }

        private User()
        {
            _login = "none";
            _hashedPassword = "none";
        }

        private User(string login, string hashedPassword)
        {
            _login = login;
            _hashedPassword = hashedPassword;
        }

        //public static User GetInstance(string login, string password)
        //{
        //    return new User(login,password);
        //}

        public event PropertyChangedEventHandler PropertyChanged; //Событие, которое будет вызвано при изменении модели 
        public void OnPropertyChanged([CallerMemberName] string prop = "") //Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
