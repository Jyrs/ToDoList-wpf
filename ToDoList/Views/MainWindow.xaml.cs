using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Media.ColorConverter;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string login, short isAdmin)
        {
            InitializeComponent();
            GreetingsLabel.Content += " " + login;
            if (isAdmin == 1)
            {
                TabItemConfig.IsEnabled = true;
                TabItemConfig.Visibility = Visibility.Visible;
            }
            else
            {
                TabItemConfig.IsEnabled = false;
                TabItemConfig.Visibility = Visibility.Collapsed;
            }

        }


        private void ButtonAddTask_OnClick(object sender, RoutedEventArgs e)
        {
            CreateTaskWindow createTaskWin = new CreateTaskWindow();
            var isResultDialog = createTaskWin.ShowDialog();
            if ((bool)isResultDialog)
            {

                CheckBox addedBox = new CheckBox();
                addedBox.Content = createTaskWin.TextBox_TaskName.Text + " (" + createTaskWin.DatePickerDeadline.Text + ")";
                addedBox.VerticalContentAlignment = VerticalAlignment.Center;
                addedBox.Margin = new Thickness(5);
                addedBox.FlowDirection = System.Windows.FlowDirection.LeftToRight;

                addedBox.FontSize = 15;
                if (createTaskWin.TextBox_TaskDescription.Text != "")
                    addedBox.ToolTip = createTaskWin.TextBox_TaskDescription.Text;

                StackPanelActualTasks.Children.Add(addedBox);

                addedBox.Checked += AddedBox_Checked;
                addedBox.MouseRightButtonDown += AddedBox_MouseRightButtonDown;
            }

            createTaskWin.Close();
        }

        private void AddedBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox) sender;
            ContextMenu ctxMenu = new ContextMenu();
            currentCheckBox.ContextMenu = ctxMenu;

            MenuItem menuItemDelete = new MenuItem() {Header = "Delete"};
            ctxMenu.Items.Add(menuItemDelete);

            menuItemDelete.Click += MenuItem_DeleteOnClick;
        }

        private void MenuItem_DeleteOnClick(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                if (menuItem.Parent is ContextMenu parentContextMenu)
                {
                    CheckBox currentCheckBox = parentContextMenu.PlacementTarget as CheckBox;
                    StackPanelActualTasks.Children.Remove(currentCheckBox);
                }
            }

        }

        private void AddedBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox currentCheckbox = (CheckBox) sender;
            StackPanelActualTasks.Children.Remove(currentCheckbox);

            StackPanelCompleteTasks.Children.Add(currentCheckbox);
            currentCheckbox.IsEnabled = false;

        }

        private void ButtonAddContact_OnClick(object sender, RoutedEventArgs e)
        {
            CreateContactWindow contactWindow = new CreateContactWindow();
            var isResultDialog = contactWindow.ShowDialog(); ;
            if ((bool)isResultDialog)
            {
                ListBoxItem createiTem = new ListBoxItem() {Content = contactWindow.TextBox_Login.Text + " " + contactWindow.TextBox_Number.Text};
                listBoxContacts.Items.Add(createiTem);
            }

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader("accounts.txt");


                while (!reader.EndOfStream)
                {
                    string buff = reader.ReadLine();
                    string[] buff_split = buff.Split(' ');
                    ListBoxItem currentAccount = new ListBoxItem() {Content = buff_split[0]};

                    ListBoxAccounts.Items.Add(currentAccount);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void ButtonDeleteAccount_OnClick(object sender, RoutedEventArgs e)
        {
            //StreamWriter writer;
            //try
            //{
            //    writer = new StreamWriter("accounts.txt");

            //    writer.WriteLine(,);
            //    writer.

            //    while (writer)
            //    {
            //        string buff = writer.ReadLine();
            //        string[] buff_split = buff.Split(' ');
            //        ListBoxItem currentAccount = new ListBoxItem() { Content = buff_split[0] };

            //        listBoxAccounts.Items.Add(currentAccount);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());

            //}
        }

        private void Button_Logout_OnClick(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }
    }
}
