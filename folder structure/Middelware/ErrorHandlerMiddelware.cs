namespace folder_structure.Middelware
{
    public class ErrorHandlerMiddelware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //log exception 
                // send email 
              await context.Response.WriteAsync("sorry something went wrong");
            }

        }

    }
}
