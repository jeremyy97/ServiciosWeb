using B_Cientificas_Cliente.Models;
using B_Cientificas_Cliente.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static B_Cientificas_Cliente.Models.UserData;

namespace B_Cientificas_Cliente.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Query string parameters to fetch Linked in user information 
        /// </summary>
        private const string LinkedinUserInfoParameters = "id,first-name,last-name,maiden-name,formatted-name,phonetic-first-name,phonetic-last-name,formatted-phonetic-name,headline,location,picture-url,industry,current-share,num-connections,num-connections-capped,summary,specialties,positions,picture-urls,site-standard-profile-request,api-standard-profile-request,public-profile-url,email-address,languages,skills";

        /// <summary>
        /// Returns login page if user is not logged in else return user profile
        /// </summary>
        /// <returns>return page</returns>
        public async Task<ActionResult> Index()
        {
            string token = (string)Session["user"];
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            else
            {
                return View("User", await GetUserFromAccessTokenAsync(token));
            }
        }

        /// <summary>
        /// Listen response from Linkedin after user authorization
        /// </summary>
        /// <param name="code">access code returned from Linkedin</param>
        /// <param name="state">A value passed by application to prevent Cross-site request forgery attack</param>
        /// <param name="error">A code indicating the type of error</param>
        /// <param name="error_description">A URL-encoded textual description that summarizes error</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SaveLinkedinUser(string code, string state, string error, string error_description)
        {
            if (string.IsNullOrEmpty(code))
            {
                return View("Error");
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.linkedin.com/")
            };
            var requestUrl = $"oauth/v2/accessToken?grant_type=authorization_code&code={code}&redirect_uri={AppConfig.Get("Linkedin.RedirectUrl")}&client_id={AppConfig.Get("Linkedin.ClientID")}&client_secret={AppConfig.Get("Linkedin.SecretKey")}";
            var response = await httpClient.GetAsync(requestUrl);
            var token = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
            Session["user"] = token.Access_token;
            return View("User", await GetUserFromAccessTokenAsync(token.Access_token));
        }

        /// <summary>
        /// Used to sign out user
        /// </summary>
        /// <returns>return Login page</returns>
        [HttpGet]
        public ActionResult SignOut()
        {
            Session["user"] = null;
            return View("Index");
        }

        /// <summary>
        /// To get user information from access token received from linked in
        /// </summary>
        /// <param name="token">access token</param>
        /// <returns>user data</returns>
        private async Task<UserInfo> GetUserFromAccessTokenAsync(string token)
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.linkedin.com")
            };
            var url = $"/v1/people/~:({LinkedinUserInfoParameters})?oauth2_access_token={token}&format=json";
            var response = await apiClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
        }
    }
}
