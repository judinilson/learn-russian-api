using System;
using System.Globalization;

namespace learn_Russian_API.Helpers
{
    /// <summary>
    /// custom exception call for throwing application specific exceptions(for validation)
    /// that can be caught and handled within the application
    /// </summary>
    public class AppException:Exception
    {
        public AppException():base() {}
        
        public AppException(string message): base(message){}
        
        public AppException(string message, params object[] args)
            :base(string.Format(CultureInfo.CurrentCulture,message,args))
        {}
    }
}