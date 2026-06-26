using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    public class TaskManager
    {
        private TaskStorageHelper _storage;

        //  initialized the storage helper 
        public TaskManager()
        {
            _storage = new TaskStorageHelper();
        }

        //to add task, log activity, returns a confirmation string
        public string AddTask(string title, string description, string reminder)
        {
            _storage.AddTask(title, description, reminder);

            //logging action to the ActivityLogger
            ActivityLogger.Log($"Task Added: {title}");

            return "Task successfully created!";
        }
        
        public List<CyberTask> GetAllTasks() //return list of task
        {
            return _storage.LoadTasks();
        }

        
        public void MarkAsComplete(int id)//marking task using ID
        {
            _storage.MarkAsComplete(id);
            ActivityLogger.Log($"Task {id} marked as complete.");
        }

        // delete task from storage
        public void DeleteTask(int id)
        {
            _storage.DeleteTask(id);
            ActivityLogger.Log($"Task {id} deleted.");
        }

        }
}
