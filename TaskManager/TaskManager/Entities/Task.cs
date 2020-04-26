using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Generic to-do task defined by a user. 
    /// </summary>
    public class Task
    {
        /// <summary>
        ///     Description of the task.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///     Approximated duration of heaving the task done in minutes.
        /// </summary>
        public uint Duration { get; set; }
        /// <summary>
        ///     Defines the maximum number of successful draw for the task per day.
        /// </summary>
        public uint RepeatsPerDay { get; set; }
        /// <summary>
        ///     Defines whether task is or is not in inactive mode (exists in database but is not taken into consideration during draws).
        ///     To not be confused with active days in schedule - this property is superior and defines task in general terms.
        ///     e.g. user may want to keep the task in database but form spome reasons do not want it to appear in the nearest future.
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        ///     Containing category for the task.
        /// </summary>
        public TaskCategory Category { get; set; }

        /// <summary>
        ///     Defines whether the task is active on days of the week.
        /// </summary>
        public WeeklySchedule Schedule { get; set; }
    }
}
