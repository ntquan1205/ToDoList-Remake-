using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ToDoList_Remake_.Services
{
    public class FileIOServices
    {
        
        private readonly string PATH;

        public FileIOServices(string path)
        {
            PATH = path;
        }

        public ObservableCollection<ToDo> LoadData()
        {
            
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<ToDo>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(fileText))
                {
                    return new ObservableCollection<ToDo>();
                }
                return JsonConvert.DeserializeObject<ObservableCollection<ToDo>>(fileText);
            }
            
        }

        public void SaveData(ObservableCollection<ToDo> toDoData)
        {
           
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(toDoData, Formatting.Indented);
                writer.Write(output);
            }
            
        }
    }
}
