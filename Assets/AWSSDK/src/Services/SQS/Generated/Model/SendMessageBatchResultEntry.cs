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
 * Do not modify this file. This file is generated from the sqs-2012-11-05.normal.json service model.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.SQS.Model
{
    /// <summary>
    /// Encloses a message ID for successfully enqueued message of a <a>SendMessageBatch</a>.
    /// </summary>
    public partial class SendMessageBatchResultEntry
    {
        private string _id;
        private string _md5OfMessageAttributes;
        private string _md5OfMessageBody;
        private string _messageId;

        /// <summary>
        /// Gets and sets the property Id. 
        /// <para>
        /// An identifier for the message in this batch.
        /// </para>
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        // Check to see if Id property is set
        internal bool IsSetId()
        {
            return this._id != null;
        }

        /// <summary>
        /// Gets and sets the property MD5OfMessageAttributes. 
        /// <para>
        /// An MD5 digest of the non-URL-encoded message attribute string. This can be used to
        /// verify that Amazon SQS received the message batch correctly. Amazon SQS first URL
        /// decodes the message before creating the MD5 digest. For information about MD5, go
        /// to <a href="http://www.faqs.org/rfcs/rfc1321.html">http://www.faqs.org/rfcs/rfc1321.html</a>.
        /// </para>
        /// </summary>
        public string MD5OfMessageAttributes
        {
            get { return this._md5OfMessageAttributes; }
            set { this._md5OfMessageAttributes = value; }
        }

        // Check to see if MD5OfMessageAttributes property is set
        internal bool IsSetMD5OfMessageAttributes()
        {
            return this._md5OfMessageAttributes != null;
        }

        /// <summary>
        /// Gets and sets the property MD5OfMessageBody. 
        /// <para>
        /// An MD5 digest of the non-URL-encoded message body string. This can be used to verify
        /// that Amazon SQS received the message correctly. Amazon SQS first URL decodes the message
        /// before creating the MD5 digest. For information about MD5, go to <a href="http://www.faqs.org/rfcs/rfc1321.html">http://www.faqs.org/rfcs/rfc1321.html</a>.
        /// </para>
        /// </summary>
        public string MD5OfMessageBody
        {
            get { return this._md5OfMessageBody; }
            set { this._md5OfMessageBody = value; }
        }

        // Check to see if MD5OfMessageBody property is set
        internal bool IsSetMD5OfMessageBody()
        {
            return this._md5OfMessageBody != null;
        }

        /// <summary>
        /// Gets and sets the property MessageId. 
        /// <para>
        /// An identifier for the message.
        /// </para>
        /// </summary>
        public string MessageId
        {
            get { return this._messageId; }
            set { this._messageId = value; }
        }

        // Check to see if MessageId property is set
        internal bool IsSetMessageId()
        {
            return this._messageId != null;
        }

    }
}