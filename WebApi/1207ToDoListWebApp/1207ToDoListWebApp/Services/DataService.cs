using _1207ToDoListWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1207ToDoListWebApp.Services
{
    public class DataService
    {
        private List<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel() { Name = "test one"}
        };

        public List<TaskModel> GetAll()
        {
            return tasks;
        }

        public void Add(TaskModel taskModel)
        {
            tasks.Add(taskModel);
        }
    }
}
