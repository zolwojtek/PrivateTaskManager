using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class CategoryEdit
    {
        private IDataGateway _dataGateway;

        public CategoryEdit(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public void UpdateCategory(TaskCategory category)
        {
            if (!NameValidator.Validate(category.Name))
                throw new InvalidOperationException($"Given category name {category.Name} contains illegal signs ({NameValidator.IllegalSigns}).");

            if (!_dataGateway.DoesElementExist(category))
                throw new InvalidOperationException($"Category with name {category.Name} does not exist.");
            else
                _dataGateway.Update(category);
        }
    }
}
