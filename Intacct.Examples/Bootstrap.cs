/*
 * Copyright 2020 Sage Intacct, Inc.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using System;
using System.IO;
using Intacct.SDK;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Intacct.Examples
{
    public static class Bootstrap
    {

        public static ILogger Logger(string loggerName)
        {
            ILogger logger = (new NLogLoggerFactory()).CreateLogger(loggerName);

            return logger;
        }

        public static OnlineClient Client(ILogger logger)
        {
            ClientConfig clientConfig = new ClientConfig()
            {
                ProfileFile = Path.Combine(Directory.GetCurrentDirectory(), "credentials.ini"),
                Logger = logger,
            };
            OnlineClient client = new OnlineClient(clientConfig);
            
            return client;
        }

        public static String getToken()
        {
            return
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjbGllbnRJZCI6ImQ0ZjJiNmIzMTgxNzRiOWE2MGE3LklOVEFDQ1QuYXBwLnNhZ2UuY29tIiwic2Vzc2lvbklkIjoidTExSWNFbk9aTzhhLVVaUFhLWDI5U0NwN3h2OVJnLi4iLCJlbmRwb2ludCI6Imh0dHBzOlwvXC9kZXYwOS5pbnRhY2N0LmNvbVwvdXNlcnNcL2Nob1wvc3JjLmFwaWludGdcL2FwaSIsImNueUlkIjoidXRiX3NpbXBsZV9tdjEifQ.FBu0dvD4x9KyKusAuQJq2GtGsNPu8WWy0StiwOhUibM";
        }
    }
}