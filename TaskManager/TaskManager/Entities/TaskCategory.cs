using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Category groups numerous tasks in one package. One task has only one category.
    /// </summary>
    public class TaskCategory : Entity
    {
        /// <summary>
        ///     Name of the category.
        /// </summary>
        public string Name { get; set; }

    }
}
