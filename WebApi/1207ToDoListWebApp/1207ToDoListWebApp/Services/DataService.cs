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
            new TaskModel() { Name = "Test name one", Description = "Description 1"}
        };

        public List<TaskModel> GetAll()
        {
            return tasks;
        }

        public void Add(TaskModel taskModel)
        {
            if (taskModel.Name != null)
            {
                tasks.Add(taskModel);
            }

        }

    }
}
