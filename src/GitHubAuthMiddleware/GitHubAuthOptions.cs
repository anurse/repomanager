﻿using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Security.OAuth;

namespace GitHubAuth
{
    public class GitHubAuthOptions : OAuthAuthenticationOptions<IGitHubAuthNotifications>
    {
        public GitHubAuthOptions()
        {
            AuthenticationType = GitHubAuthDefaults.AuthenticationType;
            Caption = AuthenticationType;
            CallbackPath = new PathString("/signin-github");
            AuthorizationEndpoint = GitHubAuthDefaults.AuthorizationEndpoint;
            TokenEndpoint = GitHubAuthDefaults.TokenEndpoint;
            UserInformationEndpoint = GitHubAuthDefaults.UserInformationEndpoint;
			Scope.AddScopes("User", "repo", "gist", "read:org");
        }

    }

	public static class Extension
	{
		public static void AddScopes(this ICollection<string> collection, params string[] scopes)
		{
			foreach (var scope in scopes)
			{
				collection.Add(scope);
			}
		}
	}
}