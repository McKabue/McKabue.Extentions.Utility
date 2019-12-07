using System;

namespace McKabue.Extentions.Utility
{
    public static class Exceptions
    {
        /// <summary>
        /// https://stackoverflow.com/a/3876512
        /// </summary>
        /// <returns></returns>
        public static Exception InnerException(this Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }
    }
}