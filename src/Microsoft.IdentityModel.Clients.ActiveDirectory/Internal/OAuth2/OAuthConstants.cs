//------------------------------------------------------------------------------
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

namespace Microsoft.IdentityModel.Clients.ActiveDirectory.Internal.OAuth2
{
    internal static class OAuthParameter
    {
        public const string ResponseType = "response_type";
        public const string GrantType = "grant_type";
        public const string ClientId = "client_id";
        public const string ClientSecret = "client_secret";
        public const string ClientAssertion = "client_assertion";
        public const string ClientAssertionType = "client_assertion_type";
        public const string RefreshToken = "refresh_token";
        public const string RedirectUri = "redirect_uri";
        public const string Resource = "resource";
        public const string Code = "code";
        public const string Scope = "scope";
        public const string Assertion = "assertion";
        public const string Subassertions = "subassertions";
        public const string RequestedTokenUse = "requested_token_use";
        public const string Username = "username";
        public const string Password = "password";
        public const string State = "state";

        public const string HasChrome = "haschrome";
        public const string LoginHint = "login_hint"; // login_hint is not standard oauth2 parameter
        public const string CorrelationId = OAuthHeader.CorrelationId; // correlation id is not standard oauth2 parameter
        public const string ClientInfo = "client_info"; // non standard
        public const string Prompt = "prompt"; // prompt is not standard oauth2 parameter

        public const string ResponseMode = "response_mode";

        public const string CodeChallengeMethod = "code_challenge_method";
        public const string CodeChallenge = "code_challenge";
        public const string CodeVerifier = "code_verifier";
    }

    internal static class OAuthGrantType
    {
        public const string AuthorizationCode = "authorization_code";
        public const string RefreshToken = "refresh_token";
        public const string ClientCredentials = "client_credentials";
        public const string Saml11Bearer = "urn:ietf:params:oauth:grant-type:saml1_1-bearer";
        public const string Saml20Bearer = "urn:ietf:params:oauth:grant-type:saml2-bearer";
        public const string JwtBearer = "urn:ietf:params:oauth:grant-type:jwt-bearer";
        public const string Password = "password";
        public const string DeviceCode = "device_code";
    }

    internal static class OAuthResponseType
    {
        public const string Code = "code";
    }

    internal static class OAuthResponseMode
    {
        public const string FormPost = "form_post";
    }

    internal static class OAuthAssertionType
    {
        public const string JwtBearer = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";
    }

    internal static class OAuthRequestedTokenUse
    {
        public const string OnBehalfOf = "on_behalf_of";
    }

    internal static class OAuthHeader
    {
        public const string CorrelationId = "client-request-id";
        public const string RequestCorrelationIdInResponse = "return-client-request-id";
    }

    internal static class OAuthError
    {
        public const string LoginRequired = "login_required";
    }

    internal static class OAuthValue
    {
        public const string ScopeOpenId = "openid";
        public const string CodeChallengeMethodValue = "S256";
    }

    internal static class PromptValue
    {
        public const string Login = "login";
        public const string RefreshSession = "refresh_session";
        public const string SelectAccount = "select_account";

        // The behavior of this value is identical to prompt=none for managed users; However, for federated users, AAD
        // redirects to ADFS as it cannot determine in advance whether ADFS can login user silently (e.g. via WIA) or not.
        public const string AttemptNone = "attempt_none";
    }
}
