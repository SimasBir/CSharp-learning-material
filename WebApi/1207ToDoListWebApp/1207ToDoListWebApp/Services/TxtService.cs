using _1207ToDoListWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1207ToDoListWebApp.Services
{
    public class TxtServiceW
    {

        public List<TaskModel> GetAll()
        {
            List<TaskModel> tasks = new List<TaskModel>();
            var logFile = System.IO.File.ReadAllLines("D:\\~Github\\test\\sample.txt");
            var taskList = new TaskListModel();
            foreach (var line in logFile)
            {
                string[] words = line.Split("}{");
                tasks.Add(new TaskModel() { Name = words[0], Description = words[1] });
            }
            return tasks;
        }

        public void Add(TaskModel taskModel)
        {
            if (taskModel.Name != null)
            {
                System.IO.File.AppendAllText("D:\\~Github\\test\\sample.txt", taskModel.Name + "}{" + taskModel.Description + Environment.NewLine);
            }

        }

        internal void Delete(TaskModel model)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines("D:\\~Github\\test\\sample.txt").Where(l => !l.StartsWith(model.Name));

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete("D:\\~Github\\test\\sample.txt");
            File.Move(tempFile, "D:\\~Github\\test\\sample.txt");

            //if(tasks.Count > 0)
            //{
            //    tasks.RemoveAll(x => x.Name == model.Name);
            //}

        }
    }
}
