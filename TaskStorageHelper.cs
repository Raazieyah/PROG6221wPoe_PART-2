using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CyberSecurityChatbot
{

    public class TaskStorageHelper
    {
        private const string FilePath = "tasks.json";

        

        public List<CyberTask> LoadTasks() 
        {
            try// try catch methods used
            {
                if (!File.Exists(FilePath))
                {
                    return new List<CyberTask>(); // Return empty list if the file does not exist
                }

                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<CyberTask>>(json) ?? new List<CyberTask>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading tasks: " + ex.Message);
                return new List<CyberTask>();
            }
        }

        // Converts the List of tasks into JSON text and saves it to the file
        public void SaveTasks(List<CyberTask> tasks)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving tasks: " + ex.Message);
            }
        }

        // Adds a new task with a unique ID
        public void AddTask(string title, string description, string reminder)//--correction made
        {
            var tasks = LoadTasks();

            // Find the highest ID and add 1. If no tasks exist, start at 1.
            int newId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;

            var newTask = new CyberTask
            {
                Id = newId,
                Title = title,
                Description = description,
                Reminder = reminder,
                IsComplete = false
            };

            tasks.Add(newTask);
            SaveTasks(tasks);
        }

        // Finds a task by ID and sets its status to complete
        public void MarkAsComplete(int id)
        {
            var tasks = LoadTasks();
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsComplete = true;
                SaveTasks(tasks);//calling save task
            }
        }

        // removes a task from the list based on its ID
        public void DeleteTask(int id)
        {
            var tasks = LoadTasks();
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);

            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                SaveTasks(tasks);
            }
        }
    }





}

