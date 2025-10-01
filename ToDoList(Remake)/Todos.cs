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

    }
}
