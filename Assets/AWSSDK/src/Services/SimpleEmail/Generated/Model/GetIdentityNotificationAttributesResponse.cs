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

/*
 * Do not modify this file. This file is generated from the email-2010-12-01.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.SimpleEmail.Model
{
    /// <summary>
    /// Describes whether an identity has Amazon Simple Notification Service (Amazon SNS)
    /// topics set for bounce, complaint, and/or delivery notifications, and specifies whether
    /// feedback forwarding is enabled for bounce and complaint notifications.
    /// </summary>
    public partial class GetIdentityNotificationAttributesResponse : AmazonWebServiceResponse
    {
        private Dictionary<string, IdentityNotificationAttributes> _notificationAttributes = new Dictionary<string, IdentityNotificationAttributes>();

        /// <summary>
        /// Gets and sets the property NotificationAttributes. 
        /// <para>
        /// A map of Identity to IdentityNotificationAttributes.
        /// </para>
        /// </summary>
        public Dictionary<string, IdentityNotificationAttributes> NotificationAttributes
        {
            get { return this._notificationAttributes; }
            set { this._notificationAttributes = value; }
        }

        // Check to see if NotificationAttributes property is set
        internal bool IsSetNotificationAttributes()
        {
            return this._notificationAttributes != null && this._notificationAttributes.Count > 0; 
        }

    }
}