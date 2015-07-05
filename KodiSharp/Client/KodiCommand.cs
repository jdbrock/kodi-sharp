using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KodiSharp
{
    public class KodiCommand<TRequestArgs, TResponse>
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================
        
        public String MethodName { get; private set; }
        public TRequestArgs RequestArguments { get; private set; }
        public Type ResponseType { get; private set; }

        // ===========================================================================
        // = Construction
        // ===========================================================================
        
        public KodiCommand(String methodName, TRequestArgs requestArgs)
        {
            MethodName = methodName;
            RequestArguments = requestArgs;
            ResponseType = typeof(TResponse);
        }
    }
}
