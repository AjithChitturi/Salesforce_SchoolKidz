using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using SchoolKidzSFCRMAPI.Middlewares.SecurityMiddleware;
using System.Net;
using System.Text.Json;
namespace SchoolKidzSFCRMAPI.Middlewares.ExceptionHandling
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly FilepathOption _options;
        private SecurityHandler _handler ;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IOptions<FilepathOption> FilepathOption)
        {
            _next = next;
            _logger = logger;
            _options = FilepathOption.Value;
            _handler = new SecurityHandler();
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                //string authHeader = httpContext.Request.Headers["Authorization"];
                //if (httpContext.Request.Path != "/swagger/index.html" && httpContext.Request.Path!="/swagger/v1/swagger.json")
                //{
                //    if (authHeader!= null && authHeader.StartsWith("Bearer"))
                //    {

                //        string token = authHeader.Substring("Bearer ".Length).Trim();
                //        try
                //        {
                //            _handler.Decryptor(token);
                //        }
                //        catch
                //        {
                //            httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //            throw new Exception("Invalid Authorization");
                //        }
                //    }
                //    else { throw new Exception("Invalid Authorization"); }
                //}
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandlingExceptionAsync(httpContext, ex);
            }
        }
        public async Task HandlingExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogInformation(exception.Message);
            if (!Directory.Exists(_options.Logging))
            {
                Directory.CreateDirectory(_options.Logging);
            }
            FileStream fs = new FileStream($"{_options.Logging}{DateTime.Today.Month}-{DateTime.Today.Day}-{DateTime.Today.Year}.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            await sw.WriteLineAsync($"Exception on {DateTime.Now}:\n" + exception.ToString());
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
