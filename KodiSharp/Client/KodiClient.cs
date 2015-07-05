using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KodiSharp
{
    public class KodiClient
    {
        // ===========================================================================
        // = Public Properties
        // ===========================================================================
        
        public KodiVideoLibrary Video { get; set; }

        // ===========================================================================
        // = Private Fields
        // ===========================================================================
        
        private KodiClientConnectionDetails _connectionDetails;
        private RestClient _restClient;

        // ===========================================================================
        // = Construction
        // ===========================================================================

        public KodiClient(KodiClientConnectionDetails connectionDetails)
        {
            _connectionDetails = connectionDetails;
            _restClient = new RestClient(_connectionDetails.Uri);

            Video = new KodiVideoLibrary(this);
        }

        // ===========================================================================
        // = Internal Methods
        // ===========================================================================

        internal async Task<TResponse> ExecuteCommandAsync<TRequestArgs, TResponse>(KodiCommand<TRequestArgs, TResponse> command)
            where TRequestArgs : class
            where TResponse : class
        {
            var body = new KodiRequestBody(command.MethodName, command.RequestArguments);

            var request = new RestRequest("jsonrpc");
            request.Method = HttpMethod.Post;
            request.Credentials = new NetworkCredential(_connectionDetails.UserName, _connectionDetails.Password);
            request.AddJsonBody(body);

            var response = await _restClient.Execute<KodiResponseWrapper<TResponse>>(request);

            if (!response.IsSuccess)
                throw new Exception(String.Format("Request failed. Response: {0}: {1}", response.StatusCode, response.StatusDescription));

            return response.Data.Result;
        }
    }
}
