
using System.Windows.Input;


namespace ToDoList.ViewModels
{
    internal class SignInViewModel
    {
        private int _click;

        public int Clicks
        {
            get { return _click; }
            set
            {
                _click = value;
            }
        }

        //public ICommand SignInButtonClick
        //{
        //    get
            
        //        //return new/DelegateCommand(() =>
        //        //{
        //        //    Clicks++;
        //        //});
            
        //}

        //public ICommand RegisterButtonClick
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            Clicks++;
        //        });
        //    }
        //}
    }
}
