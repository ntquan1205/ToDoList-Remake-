using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            DueDatePicker.SelectedDate = DateTime.Today;
        }

        private void AddButton_clicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewToDoTextBox.Text))
            {
                MessageBox.Show("Добавьте название .", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ToDo todo = new ToDo()
            {
                Name = NewToDoTextBox.Text,
                Priority = int.Parse((PriorityComboBox.SelectedItem as ComboBoxItem).Content.ToString()),
                Category = (Category)CategoryComboBox.SelectedIndex,
                DueDate = DueDatePicker.SelectedDate ?? DateTime.Today
            };

            todos.AllTodos.Add(todo);

            NewToDoTextBox.Clear();
            PriorityComboBox.SelectedIndex = 2;
            CategoryComboBox.SelectedIndex = 0;
            DueDatePicker.SelectedDate = DateTime.Today;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgToDoApp.SelectedItem is ToDo selectedTodo)
            {
                todos.AllTodos.Remove(selectedTodo);
            }
            else
            {
                MessageBox.Show("Выбирайте что-то, чтобы удалять", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dgToDoApp_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true; 
            string columnName = e.Column.Header.ToString();
            ListSortDirection direction = ListSortDirection.Ascending;
            switch (columnName)
            {
                case "Задача":
                    if (direction == ListSortDirection.Ascending)
                        todos.SortByName();
                    else
                        todos.SortByNameDescending();
                    break;

                case "Приоритет":
                    if (direction == ListSortDirection.Ascending)
                        todos.SortByPriority();
                    else
                        todos.SortByPriorityDescending();
                    break;

                case "Категория":
                    if (direction == ListSortDirection.Ascending)
                        todos.SortByCategory();
                    else
                        todos.SortByCategoryDescending();
                    break;

                case "Срок выполнения":
                    if (direction == ListSortDirection.Ascending)
                        todos.SortByDueDate();
                    else
                        todos.SortByDueDateDescending();
                    break;

                case "Выполнена ли она":
                    if (direction == ListSortDirection.Ascending)
                        todos.SortByIsDone();
                    else
                        todos.SortByIsDoneDescending();
                    break;
            }

            e.Column.SortDirection = direction;

            foreach (var column in dgToDoApp.Columns)
            {
                if (column != e.Column)
                    column.SortDirection = null;
            }
        }
        private void dgToDoApp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
