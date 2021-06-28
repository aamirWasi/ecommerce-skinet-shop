using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request you've made",
                401 => "Authoriged,you're not",
                404 => "Resource found,it was not",
                500 => "Errors are the path to the dark side.Errors lead to anger.Anger leads to hate.Hate leads to career change",
                _ => null
            };
        }
    }
}
