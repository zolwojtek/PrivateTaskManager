using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class CategoryTasksFetch
    {
        IDataGateway _dataGateway;

        public CategoryTasksFetch(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public IEnumerable<Task> FetchTasks(TaskCategory category)
        {
            if (!_dataGateway.DoesElementExist(category))
                throw new InvalidOperationException($"Category with name {category.Name} does not exist.");

            IEnumerable<Task> tasks;
            tasks = _dataGateway.ReadTasks(category);
            return tasks;
        }
    }
}
