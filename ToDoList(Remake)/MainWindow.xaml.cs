using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList_Remake_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Todos todos;
        public MainWindow()
        {
            InitializeComponent();
            todos = new Todos();
            DataContext = todos;
        }

        private void AddButton_clicked(object sender, RoutedEventArgs e)
        {
            ToDo todo = new ToDo()
            {
                Name = NewToDoTextBox.Text
            };
            todos.AllTodos.Add(todo);

        }
    }
}
