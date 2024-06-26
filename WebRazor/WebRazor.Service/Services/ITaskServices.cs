﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRazor.Domain.Entities;
using WebRazor.Service.Models;

namespace WebRazor.Service.Services
{
    public interface ITaskServices
    {
        public void NewTask(string taskName, string taskDescription, string priority);
        public List<TasksModel> ShowAllTask();
        public TasksModel ShowTaskById(int id);
        public void DeleteTaskById(int taskid);
        public void UpdateTask(int id, string taskName, string taskDescription, string priority);
        public void TaskIsCompleted(int taskId);
        public void DeleteAll();
        public List<TasksModel> UsersTask(int userId);
        public void AddTaskToUser(int UserId, int TaskId);
    }
}
