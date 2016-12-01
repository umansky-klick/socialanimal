using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace SocialAnimal.Twitter.Web.Services
{
	public class TwitterSearchService
	{
		private string _consumerKey = System.Configuration.ConfigurationManager.AppSettings["apiKey"];
		private string _consumerSecret = System.Configuration.ConfigurationManager.AppSettings["apiSecret"];
		private string _accessTokenSecret = System.Configuration.ConfigurationManager.AppSettings["accessTokenSecret"];
		private string _accessToken = System.Configuration.ConfigurationManager.AppSettings["accessToken"];
		public IEnumerable<string> SearchUsers(string name)
		{

			var service = new TwitterService(_consumerKey, _consumerSecret);
			service.AuthenticateWith(_accessToken, _accessTokenSecret);

			var results = service.SearchForUser(new SearchForUserOptions() { Q = name });
			return results.Select(t => t.ScreenName);

		}
	}
}