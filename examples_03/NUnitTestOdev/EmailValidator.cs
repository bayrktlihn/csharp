using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestOdev
{
    public class EmailValidator : IValidator
    {
        public String Name { get; set; }
        
        public bool Valid()
        {

            if (Name == null)
                throw new ArgumentNullException();

            var client = new RestClient($"https://emailvalidation.abstractapi.com/v1/?api_key=6d81c3e147054d04b7acd0bf6e2c3207&email={Name}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            String content = response.Content;

            JObject result = JObject.Parse(content);

            return (bool)result["is_valid_format"]["text"];
        }

    }
}
