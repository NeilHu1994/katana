﻿// <copyright file="TwitterAuthenticationOptions.cs" company="Microsoft Open Technologies, Inc.">
// Copyright 2011-2013 Microsoft Open Technologies, Inc. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;

using Microsoft.Owin.Security.DataProtection;

namespace Microsoft.Owin.Security.Twitter
{
    /// <summary>
    /// Options for the Twitter authentication middleware.
    /// </summary>
    public class TwitterAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterAuthenticationOptions"/> class.
        /// </summary>
        public TwitterAuthenticationOptions()
            : base("Twitter")
        {
            Caption = "Twitter";
            CallbackUrlPath = "/signin-twitter";
            AuthenticationMode = AuthenticationMode.Passive;

            this.BackChannelTimeout = 60 * 1000; // 60 seconds

            this.PinnedCertificateValidator = new PinnedCertificateValidator(
                new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "62f3c89771da4ce01a91fc13e02b6057b4547a1d", // VeriSign Class 3 Secure Server CA - G2
                    "85371ca6e550143dce2803471bde3a09e8f8770f", // VeriSign Class 3 Public Primary Certification Authority - G2

                    "5deb8f339e264c19f6686f5f8f32b54a4c46b476", // VeriSign Class 3 Secure Server CA - G3
                    "4eb6d578499b1ccf5f581ead56be3d9b6744a5e5", // VeriSign Class 3 Public Primary Certification Authority - G5
                });
        }

        /// <summary>
        /// Gets or sets the consumer key used to communicate with Twitter.
        /// </summary>
        /// <value>The consumer key used to communicate with Twitter.</value>
        public string ConsumerKey { get; set; }
        
        /// <summary>
        /// Gets or sets the consumer secret used to sign requests to Twitter.
        /// </summary>
        /// <value>The consumer secret used to sign requests to Twitter.</value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with Twitter.
        /// </summary>
        /// <value>
        /// The back channel timeout in milliseconds.
        /// </value>
        public int BackChannelTimeout { get; set; }

        /// <summary>
        /// Gets or sets the a pinned certificate validator to use to validate the endpoints used
        /// in back channel communications belong to twitter.
        /// </summary>
        /// <value>
        /// The pinned certificate validator.
        /// </value>
        /// <remarks>If this property is null then the default certificate checks are performed,
        /// validating the subject name and if the signing chain is a trusted party.</remarks>
        public PinnedCertificateValidator PinnedCertificateValidator { get; set; }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        public string CallbackUrlPath { get; set; }
        public string SignInAsAuthenticationType { get; set; }

        public IDataProtector DataProtection { get; set; }
        public ITwitterAuthenticationProvider Provider { get; set; }
    }
}