using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Describes a state of a to-be-done task.
    /// </summary>
    public enum TaskExecution
    {
        Pending,
        Done,
        NotDone,
        Canceled
    }
}
