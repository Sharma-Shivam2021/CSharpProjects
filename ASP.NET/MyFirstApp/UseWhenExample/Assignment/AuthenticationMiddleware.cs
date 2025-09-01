using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace UseWhenExample.Assignment
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            /* My Method
            //if (httpContext.Request.Method == "GET")
            //{
            //    await httpContext.Response.WriteAsync("No Response\n");
            //    return;
            //}
            //if(httpContext.Request.Method == "POST")
            //{
            //    using var reader = new StreamReader(httpContext.Request.Body, leaveOpen: true);
            //    string? requestBody = await reader.ReadToEndAsync();
            //    if(string.IsNullOrEmpty(requestBody))
            //    {
            //        httpContext.Response.StatusCode = 400;
            //        await httpContext.Response.WriteAsync("Invalid input for 'email'\nInvalid input for 'password'");
            //        return;
            //    }
            //    if (!string.IsNullOrEmpty(requestBody))
            //    {
            //        var fields = requestBody.Split("&");
            //        if (fields.Length<2 || fields[0]=="" || fields[1]=="")
            //        {
            //            var name = fields[0].Split("=");
            //            if (name[0] == "email")
            //            {
            //                httpContext.Response.StatusCode = 400;
            //                await httpContext.Response.WriteAsync("Invalid input for 'password'");
            //                return;
            //            }
            //            if (name[0]=="password")
            //            {
            //                httpContext.Response.StatusCode = 400;
            //                await httpContext.Response.WriteAsync("Invalid input for 'email'");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            var name = fields[0].Split("=");
            //            var emailText = name[1];
            //            var name2 = fields[1].Split("=");
            //            var passwordText = name2[1];

            //            if (emailText=="admin@example.com" && passwordText == "admin1234")
            //            {
            //                httpContext.Response.StatusCode = 200;
            //                await httpContext.Response.WriteAsync("Successful Login");
            //                return;
            //            }
            //            else
            //            {
            //                httpContext.Response.StatusCode = 400;
            //                await httpContext.Response.WriteAsync("Invalid Login");
            //                return;
            //            }

            //        }
            //            httpContext.Response.StatusCode = 400;
            //        await httpContext.Response.WriteAsync("Invalid Input");
            //        return;
            //    }
            //    return;
            //}
            */

            /*Instructor Method*/
            if (httpContext.Request.Path == "/" && httpContext.Request.Method == "POST")
            {
                // Read response body as stream
                StreamReader reader = new StreamReader(httpContext.Request.Body);
                string body = await reader.ReadToEndAsync();

                // Parse the request body from string into Dictionary
                Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

                string? email = null, password = null;
                // read email if submitted
                if (queryDict.ContainsKey("email"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'email'\n");
                }

                // read password if submitted
                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'password'\n");
                }

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    //valid email and password as per the requirement specification
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    bool isValidLogin;

                    if (email == validEmail && password == validPassword)
                    {
                        isValidLogin = true;
                    }
                    else
                    {
                        isValidLogin = false;
                    }
                    //send response
                    if (isValidLogin)
                    {
                        await httpContext.Response.WriteAsync("Successful login\n");
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("Invalid login\n");
                    }
                }

            }
            else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
