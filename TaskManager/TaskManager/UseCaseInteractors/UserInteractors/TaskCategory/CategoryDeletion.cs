using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class CategoryDeletion
    {
        IDataGateway _dataGateway;

        public CategoryDeletion(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public void DeleteCategory(TaskCategory category)
        {
            if (!_dataGateway.DoesElementExist(category))
                throw new InvalidOperationException($"Category with name {category.Name} does not exist.");
            else
                _dataGateway.Delete(category);
        }
    }
}
