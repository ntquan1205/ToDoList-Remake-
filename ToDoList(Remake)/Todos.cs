using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_Remake_
{
    public class Todos : INotifyPropertyChanged
    {
        public Todos() 
        {
            _allTodos = new ObservableCollection<ToDo>()
            {
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<ToDo> _allTodos;
        public ObservableCollection<ToDo> AllTodos
        {
            get { return _allTodos; }
            set
            {
                _allTodos = value;
                OnPropertyChanged(nameof(AllTodos));
            }
        }

        public void SortByName()
        {
            var sorted = _allTodos.OrderBy(todo => todo.Name).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByNameDescending()
        {
            var sorted = _allTodos.OrderByDescending(todo => todo.Name).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByPriority()
        {
            var sorted = _allTodos.OrderBy(todo => todo.Priority).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByPriorityDescending()
        {
            var sorted = _allTodos.OrderByDescending(todo => todo.Priority).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByCategory()
        {
            var sorted = _allTodos.OrderBy(todo => todo.Category).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByCategoryDescending()
        {
            var sorted = _allTodos.OrderByDescending(todo => todo.Category).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByDueDate()
        {
            var sorted = _allTodos.OrderBy(todo => todo.DueDate).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByDueDateDescending()
        {
            var sorted = _allTodos.OrderByDescending(todo => todo.DueDate).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByIsDone()
        {
            var sorted = _allTodos.OrderBy(todo => todo.IsDone).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }

        public void SortByIsDoneDescending()
        {
            var sorted = _allTodos.OrderByDescending(todo => todo.IsDone).ToList();
            AllTodos = new ObservableCollection<ToDo>(sorted);
        }
    }
}
