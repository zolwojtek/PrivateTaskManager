using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Entities
{
    /// <summary>
    ///     Base abstract class for entities used in application.
    ///     It is useful as a constrain  in generic methods uisng Entities classes.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        ///     Uniq id (within the same group) for entity.
        /// </summary>
        protected uint id;
    }
}
