using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DataAccess
{
    public interface IDataGateway
    {
        #region Read
        /// <summary>
        ///     Reads collection of given Entity type from data storage.
        /// </summary>
        /// <typeparam name="T"> Type derriving from Entity class.  </typeparam>
        /// <returns> All entities with given type found in the storage. </returns>
        IEnumerable<T> ReadCollection<T>() where T : Entity;  
        
        /// <summary>
        ///     Reads application setting.
        /// </summary>
        /// <returns> Class representing application settings. </returns>
        AppSettings ReadAppSettings();

        /// <summary>
        ///     Reads currenty active To-Do event.
        /// </summary>
        /// <returns> Active To-Do event or null if there is no such event. </returns>
        ToDoEvent ReadActiveToDoEvent();

        /// <summary>
        ///     Verifies whether the given element exist in data storage.
        /// </summary>
        /// <typeparam name="T">  Type derriving from Entity class.  </typeparam>
        /// <param name="element"> Element which existance is to be verified. </param>
        /// <returns></returns>
        bool DoesElementExist<T>(T element) where T : Entity;

        #endregion Read

        #region Write
        /// <summary>
        ///     Writes given entity into data storage.
        /// </summary>
        /// <typeparam name="T"> Type derriving from Entity class.  </typeparam>
        void Write<T>(T entity) where T : Entity;
        #endregion Write

        #region Delete
        /// <summary>
        ///     Deletes given entity from data storage.
        /// </summary>
        /// <typeparam name="T"> Type derriving from Entity class.  </typeparam>
        void Delete<T>(T entity) where T : Entity;
        #endregion Delete

        #region Update
        /// <summary>
        ///     Updates given entity in data storage.
        /// </summary>
        /// <typeparam name="T"> Type derriving from Entity class. . </typeparam>
        void Update<T>(T entity) where T : Entity;
        #endregion Update

    }
}
