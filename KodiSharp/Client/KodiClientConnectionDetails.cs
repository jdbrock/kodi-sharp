using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiClientConnectionDetails
    {
        public String HostName { get; set; }
        public Int32 Port { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public String Uri
        {
            get
            {
                return String.Format("http://{0}:{1}", HostName, Port);
            }
        }

        public KodiClientConnectionDetails(String hostname, Int32 port, String userName, String password)
        {
            HostName = hostname;
            Port     = port;
            UserName = userName;
            Password = password;
        }
    }
}
