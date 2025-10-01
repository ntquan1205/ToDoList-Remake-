using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_Remake_
{
    public class ToDo
    {

        public ToDo() 
        {
            Name = string.Empty;
        }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
