using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess;
using TaskManager.Entities;

namespace ConsoleUI
{
    public class FileDataAccess : IDataGateway
    {
        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public bool DoesElementExist<T>(T element) where T : Entity
        {
            throw new NotImplementedException();
        }

        public ToDoEvent ReadActiveToDoEvent()
        {
            throw new NotImplementedException();
        }

        public AppSettings ReadAppSettings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadCollection<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Write<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
