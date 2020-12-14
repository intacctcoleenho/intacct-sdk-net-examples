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
using System.Threading.Tasks;
using Intacct.SDK.Rest;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Intacct.Examples
{
    public class RestGettingStarted
    {
        public static void Run(ILogger logger)
        { 
            RestRequestHandler restHandler  = new RestRequestHandler(Bootstrap.getToken());

            Task<RestRequestHandler.Customer> task = restHandler.GetCustomerAsync("v0/objects/customer/12");
            task.Wait();

            RestRequestHandler.Customer customer = task.Result;

            PrettyPrintCustomer(customer);
        }
        
        private static void PrettyPrintCustomer(RestRequestHandler.Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine($"Customer Name: {customer.Name}\tTotal Due: " +
                              $"{customer.TotalDue}\tOn hold?: {customer.OnHold}");
        }

    }
    
    
}