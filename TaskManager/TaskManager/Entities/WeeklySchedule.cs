using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Defines whether a particular day in a week is active or not. In context of a task, 
    ///     activeness defines whether a task should occur in the daily task pool, tasks are to be drawn from.
    /// </summary>
    public class WeeklySchedule : Entity
    {
        /// <summary>
        ///     Defines whether Monday is the active day.
        /// </summary>
        public bool Monday { get; set; }
        /// <summary>
        ///     Defines whether Tuesday is the active day.
        /// </summary>
        public bool Tuesday { get; set; }
        /// <summary>
        ///     Defines whether Wednesday is the active day.
        /// </summary>
        public bool Wednesday { get; set; }
        /// <summary>
        ///     Defines whether Thursday is the active day.
        /// </summary>
        public bool Thursday { get; set; }
        /// <summary>
        ///     Defines whether Friday is the active day.
        /// </summary>
        public bool Friday { get; set; }
        /// <summary>
        ///     Defines whether Saturday is the active day.
        /// </summary>
        public bool Saturday { get; set; }
        /// <summary>
        ///     Defines whether Sunday is the active day.
        /// </summary>
        public bool Sunday { get; set; }
    }
}
