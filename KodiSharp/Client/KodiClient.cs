﻿using RestSharp;
using RestSharp.Authenticators;
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

        public KodiMovieLibrary Movies { get; set; }
        public KodiTvLibrary TV { get; set; }

        // ===========================================================================
        // = Private Fields
        // ===========================================================================
        
        private KodiClientConnectionDetails _connectionDetails;
        private RestClient _restClient;

        // ===========================================================================
        // = Construction
        // ===========================================================================

        public KodiClient(String hostName, Int32 port = 8080, String userName = "xbmc", String password = null)
            : this(new KodiClientConnectionDetails(hostName, port, userName, password)) { }

        public KodiClient(KodiClientConnectionDetails connectionDetails)
        {
            _connectionDetails = connectionDetails;
            _restClient = new RestClient(_connectionDetails.Uri);

            _restClient.Authenticator = new HttpBasicAuthenticator(
                _connectionDetails.UserName, 
                _connectionDetails.Password
            );

            Movies = new KodiMovieLibrary(this);
            TV = new KodiTvLibrary(this);
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
            request.Method = Method.Post;
            request.AddJsonBody(body);

            var response = await _restClient.ExecuteAsync<KodiResponseWrapper<TResponse>>(request);

            if (!response.IsSuccessful)
                throw new Exception(String.Format("Request failed. Response: {0}: {1}", response.StatusCode, response.StatusDescription));

            return response.Data.Result;
        }
    }
}
