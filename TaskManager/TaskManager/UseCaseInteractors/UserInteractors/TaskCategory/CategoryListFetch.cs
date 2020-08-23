using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace TaskManager.UseCaseInteractors.UserInteractors
{
    public class CategoryListFetch
    {
        private IDataGateway _dataGateway;

        public CategoryListFetch(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public IEnumerable<TaskCategory> FetchCategories()
        {
            IEnumerable<TaskCategory> categories;
            categories = _dataGateway.ReadCategories();
            return categories;
        }
    }
}
