using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_Remake_.Services;

namespace ToDoList_Remake_
{
    public class Todos : INotifyPropertyChanged
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoData.json";
        private FileIOServices _fileIOServices;
        public Todos() 
        {
            _fileIOServices = new FileIOServices(PATH);
            _allTodos = _fileIOServices.LoadData();

            _allTodos.CollectionChanged += (s, e) => SaveData();

            foreach (var todo in _allTodos)
            {
                todo.PropertyChanged += Todo_PropertyChanged;
            }
        }

        private void Todo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveData();
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
                if (_allTodos != null)
                {
                    _allTodos.CollectionChanged -= (s, e) => SaveData();
                    foreach (var todo in _allTodos)
                    {
                        todo.PropertyChanged -= Todo_PropertyChanged;
                    }
                }
                _allTodos = value;

                if (_allTodos != null)
                {
                    _allTodos.CollectionChanged += (s, e) => SaveData();
                    foreach (var todo in _allTodos)
                    {
                        todo.PropertyChanged += Todo_PropertyChanged;
                    }
                }
                OnPropertyChanged(nameof(AllTodos));
                SaveData();
            }
        }

        private void SaveData()
        {
            _fileIOServices.SaveData(_allTodos);
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
