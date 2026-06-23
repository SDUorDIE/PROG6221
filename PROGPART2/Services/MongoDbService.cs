using MongoDB.Driver;
using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI.Services
{
    //Handles MongoDB operations
    public class MongoDbService
    {
        private readonly IMongoCollection<TaskItem> tasksCollection;

        public MongoDbService()
        {
            var client = new MongoClient(
                "mongodb://localhost:27017");

            var database =
                client.GetDatabase("CyberSecurityDB");

            tasksCollection =
                database.GetCollection<TaskItem>("Tasks");
        }

        //Create
        public void AddTask(TaskItem task)
        {
            tasksCollection.InsertOne(task);
        }

        //Read
        public List<TaskItem> GetTasks()
        {
            return tasksCollection
                .Find(_ => true)
                .ToList();
        }

        //Delete
        public void DeleteTask(int id)
        {
            tasksCollection.DeleteOne(
                t => t.Id == id);
        }

        //Update
        public void CompleteTask(int id)
        {
            var update =
                Builders<TaskItem>.Update
                    .Set(t => t.IsCompleted, true);

            tasksCollection.UpdateOne(
                t => t.Id == id,
                update);
        }
    }
}