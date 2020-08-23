using System;
using System.Collections.Generic;

namespace TaskManager
{
    public static class NameValidator
    {
        internal static readonly string IllegalSigns;

        static NameValidator()
        {
            IllegalSigns = "!@#$%^&*()+=~`[]{}<>\\|_.";//TO-DO - move to app settings file
        }

        internal static bool Validate(string name)
        {
            return name.IndexOfAny(IllegalSigns.ToCharArray()) == -1;
        }
    }
}