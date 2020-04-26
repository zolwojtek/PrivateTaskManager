using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Represents an event of drawing and completion of a task.
    /// </summary>
    public class ToDoEvent
    {
        /// <summary>
        ///     Task event refers to.
        /// </summary>
        public Task Task { get; set; }
        /// <summary>
        ///     The date of drawing a task.
        /// </summary>
        public DateTime DrawingDate { get; set; }
        /// <summary>
        ///     The date of completion/closing the drawn task (does not need to be done).
        /// </summary>
        public DateTime CompletionDate { get; set; }
        /// <summary>
        ///     The state of task completion.
        /// </summary>
        public TaskExecution TaskExecution { get; set; }
    }
}
