//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//
using System;
using System.Net;
using System.Collections.Generic;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    ///    Response Unmarshaller for PutCORSConfiguration operation
    /// </summary>
    internal class PutCORSConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
    {

        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {
            PutCORSConfigurationResponse response = new PutCORSConfigurationResponse();
            

            return response;
        }

        private static PutCORSConfigurationResponseUnmarshaller _instance;

        public static PutCORSConfigurationResponseUnmarshaller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PutCORSConfigurationResponseUnmarshaller();
                }
                return _instance;
            }
        }
    
    }
}
    
