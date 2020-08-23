using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UnitTests.Mocks
{
    public class FakeDataAccess : IDataGateway
    {
        private readonly IList<TaskCategory> _categories = new List<TaskCategory>()
        {
            new TaskCategory { Name = "Existing Category"}
        };

        public void Delete<T>(T element) where T : Entity
        {
            switch (element)
            {
                case TaskCategory tc:
                    _categories.Remove(tc);
                    break;
                default:
                    break;
            }
        }

        public bool DoesElementExist<T>(T element) where T : Entity
        {
            switch(element)
            {
                case TaskCategory tc:
                    return _categories.Contains(tc);
                default:
                    throw new InvalidOperationException($"Unknown type: {typeof(T)}");
            }
            
        }

        public ToDoEvent ReadActiveToDoEvent()
        {
            throw new NotImplementedException();
        }

        public AppSettings ReadAppSettings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskCategory> ReadCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadCollection<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> ReadTasks(TaskCategory category)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T element) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Write<T>(T element) where T : Entity
        {
            switch (element)
            {
                case TaskCategory tc:
                    _categories.Add(tc);
                    break;
                default:
                    break;
            }
        }
    }
}
