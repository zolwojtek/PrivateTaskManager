using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Category groups numerous tasks in one package. One task has only one category.
    /// </summary>
    public class TaskCategory : Entity, IEquatable<TaskCategory>
    {
        /// <summary>
        ///     Name of the category.
        /// </summary>
        public string Name { get; set; }

        public IEnumerable<Task> Tasks { get; } = new List<Task>();

        public bool Equals(TaskCategory other)
        {
            return other?.Name.Equals(this.Name) ?? false;
        }
    }
}
