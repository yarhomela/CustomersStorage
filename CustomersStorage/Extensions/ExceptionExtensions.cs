using Newtonsoft.Json;

namespace CustomersStorage.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ToResponseMessage(this Exception error)
        {
            var resultObject = new ErrorResponseView
            {
                Error = error.Message
            };

            var output = JsonConvert.SerializeObject(resultObject);

            return output;
        }
    }

    public class ErrorResponseView
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
