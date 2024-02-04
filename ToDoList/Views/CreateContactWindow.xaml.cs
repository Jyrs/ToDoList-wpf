using System;
using System.IO;
using System.Windows;
using System.Windows.Input;


namespace ToDoList
{
    public partial class CreateContactWindow : Window
    {
        public CreateContactWindow()
        {
            InitializeComponent();
        }

        private void Button_CreateContact_Click(object sender, RoutedEventArgs e)
        { 
            DialogResult = true;
            this.Close();

        }

        private void TextBox_Number_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(Convert.ToChar(e.Text)))
            {
                e.Handled = true;
            }
        }
    }


}
