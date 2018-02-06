using System;

namespace LuizalabsEmployeeManager.Helpers
{
    public class Guard
    {
        public static void ForNullOrEmptyDefaultMessage(string value, string propName)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(propName + " is required!");
        }

        public static void ForNullOrEmpty(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(errorMessage);
        }

        public static void StringLength(string propName, string stringValue, int maximum)
        {
            StringLength(stringValue, maximum, "The maximum characters for " + propName + " are " + maximum + "!");
        }

        public static void StringLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Length;
            if (length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void StringLength(string stringValue, int minimum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Length;
            if (length < minimum || length > maximum)
            {
                throw new Exception(message);
            }
        }
    }
}
