﻿//----------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Identity.Core;
using Microsoft.Identity.Core.Cache;
using Microsoft.IdentityModel.Clients.ActiveDirectory.Internal.OAuth2;

namespace Microsoft.IdentityModel.Clients.ActiveDirectory.Internal.Flows
{
    internal class AcquireTokenOnBehalfHandler : AcquireTokenHandlerBase
    {
        private readonly UserAssertion _userAssertion;

        public AcquireTokenOnBehalfHandler(
            IServiceBundle serviceBundle, 
            RequestData requestData, 
            UserAssertion userAssertion)
            : base(serviceBundle, requestData)
        {
            _userAssertion = userAssertion ?? throw new ArgumentNullException(nameof(userAssertion));
            DisplayableId = userAssertion.UserName;

            string assertionHashInput = 
                (userAssertion.Subassertions == null) ? userAssertion.Assertion : userAssertion.Assertion + "|" + userAssertion.Subassertions;

            CacheQueryData.AssertionHash = PlatformProxyFactory
                                           .GetPlatformProxy()
                                           .CryptographyManager
                                           .CreateSha256Hash(assertionHashInput);

            RequestContext.Logger.Verbose(string.Format(CultureInfo.InvariantCulture,
                "Username provided in user assertion - " + string.IsNullOrEmpty(DisplayableId)));

            SupportADFS = true;
        }

        protected internal /* internal for test only */ override async Task<AdalResultWrapper> SendTokenRequestAsync()
        {
            AdalResultWrapper resultEx = await base.SendTokenRequestAsync().ConfigureAwait(false);
            if (resultEx != null)
            {
                resultEx.UserAssertionHash = CacheQueryData.AssertionHash;
            }

            return resultEx;
        }

        protected override void AddAdditionalRequestParameters(DictionaryRequestParameters requestParameters)
        {
            requestParameters[OAuthParameter.GrantType] = OAuthGrantType.JwtBearer;
            requestParameters[OAuthParameter.Assertion] = _userAssertion.Assertion;
            requestParameters[OAuthParameter.Subassertions] = _userAssertion.Subassertions;
            requestParameters[OAuthParameter.RequestedTokenUse] = OAuthRequestedTokenUse.OnBehalfOf;
            requestParameters[OAuthParameter.Scope] = OAuthValue.ScopeOpenId;
        }
    }
}
