using AsignacionDeTareas2.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AsignacionDeTareas2.Models
{
    public class AutorizationMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public readonly IServiceProvider _service;

        private readonly string _secretkey;

        public AutorizationMiddleware(IConfiguration configuration, IServiceProvider provider, RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            _service = provider;
            _secretkey = configuration.GetSection("Jwt").GetSection("Key").ToString();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _service.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbcontext>();

                var root = context.Request.Path;

                var excludePath = new List<string> { "/Users/Login", "/Users/CreateUser" };

                var result = excludePath.Contains(root);

                if (excludePath.Contains(root))
                {
                    await _requestDelegate(context);
                    return;
                }

                var authorization = context.Request.Headers.Where(u => u.Key == "authorizacion").FirstOrDefault();

                if (!context.Request.Headers.TryGetValue("authorizacion", out var authorizationHeader))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Authorization header is missing.");
                    return;
                }

                var token = authorizationHeader.ToString();

                if (string.IsNullOrEmpty(token))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token is missing or invalid.");
                    return;
                }

                var userId = JwtDecoder.DecodeJwt(token, "identificador de usuario");

                if (string.IsNullOrEmpty(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized. User ID is missing.");
                    return;
                }

                var user = await dbcontext.Users
                                          .Include(u => u.Rol)
                                          .ThenInclude(r => r.Operacion)
                                          .ThenInclude(or => or.OperationsRol)
                                          .FirstOrDefaultAsync(u => u.idUser == int.Parse(userId));

                if (user == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized. User not found.");
                    return;
                }

                var route = context.Request.Path.Value.ToLower();
                var method = context.Request.Method.ToLower();

                var requiredOperation = method switch
                {
                    "post" => "Crear",
                    "put" => "Actualizar",
                    "delete" => "Eliminar",
                    "get" => "Ver",
                    _ => string.Empty
                };

                if (string.IsNullOrEmpty(requiredOperation) ||
                    !user.Rol.Operacion.Any(or => or.OperationsRol.NameOperationRol.ToLower() == requiredOperation.ToLower()))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden. You don't have permission to perform this action.");
                    return;
                }
                await _requestDelegate(context);
            }
        }
    }
}
