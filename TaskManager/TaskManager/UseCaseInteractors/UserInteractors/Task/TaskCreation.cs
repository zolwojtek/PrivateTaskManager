using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class TaskCreation
    {
        private IDataGateway _dataGateway;

        public TaskCreation(IDataGateway dataGateway)
        {
            this._dataGateway = dataGateway;
        }

        public Task CreateTask(string name, string description, TaskCategory category)
        {
            Task task = new Task() { Name = name, Description = description };

            if (_dataGateway.DoesElementExist(task))
                throw new ArgumentException($"Task with name: {name} and description: {description} already exists in category: {category.Name}.");
            else
                _dataGateway.Write(task);

            return task;
        }
    }
}
