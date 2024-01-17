using System.Net;
using System.Text.Json;
namespace SchoolKidzSFCRMAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
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
            if(!Directory.Exists("C:\\Users\\Ajith\\source\\repos\\SchoolKidzSFCRMAPI\\SchoolKidzSFCRMAPI\\Log\\")) {
                Directory.CreateDirectory("C:\\Users\\Ajith\\source\\repos\\SchoolKidzSFCRMAPI\\SchoolKidzSFCRMAPI\\Log\\");
            }
            FileStream fs = new FileStream($"C:\\Users\\Ajith\\source\\repos\\SchoolKidzSFCRMAPI\\SchoolKidzSFCRMAPI\\Log\\{DateTime.Today.Month}-{DateTime.Today.Day}-{DateTime.Today.Year}.txt", FileMode.Append,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLineAsync($"Exception on {DateTime.Now}:\n"+exception.ToString());
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
