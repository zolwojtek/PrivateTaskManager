using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class CategoryCreation
    {
        IDataGateway _dataGateway;

        public CategoryCreation(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public TaskCategory CreateCategory(string categoryName)
        {
            var category = new TaskCategory() { Name = categoryName };

            if(_dataGateway.DoesElementExist(category))
                throw new ArgumentException($"Category with name {categoryName} already exists.");
            else
                _dataGateway.Write(category);

            return category;
        }
    }
}
