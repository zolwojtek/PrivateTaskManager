using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class TaskDeletion
    {
        private IDataGateway _dataGateway;

        public TaskDeletion(IDataGateway dataGateway)
        {
            this._dataGateway = dataGateway;
        }

        public void DeleteTask(Task task)
        {
            if (!_dataGateway.DoesElementExist(task))
                throw new InvalidOperationException($"Task with name: {task.Name} and description: {task.Description} does not exist in category: {task.Category.Name}.");
            else
                _dataGateway.Delete(task);
        }
    }
}
