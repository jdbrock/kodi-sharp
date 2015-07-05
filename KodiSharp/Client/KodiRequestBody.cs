using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    internal class KodiRequestBody
    {
        [JsonProperty("id")]      public String RequestId { get; set; }
        [JsonProperty("method")]  public String MethodName { get; private set; }
        [JsonProperty("jsonrpc")] public String JsonRpcVersion { get; private set; }
        [JsonProperty("params")]  public Object Arguments { get; set; }

        public KodiRequestBody(String methodName, Object arguments)
        {
            MethodName = methodName;
            Arguments = arguments;

            RequestId = Guid.NewGuid().ToString();
            JsonRpcVersion = "2.0";
        }
    }
}
