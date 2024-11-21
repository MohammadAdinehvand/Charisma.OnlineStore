
using Charisma.OnlineStore.Abstractions.Domain;
using Charisma.OnlineStore.Api.Response;
using Charisma.OnlineStore.Application.Exceptions;
using System.Text.Json;

namespace Charisma.OnlineStore.Api.Middleware
{
    public sealed class ExceptionHandlingMiddleware 
    {
        private readonly RequestDelegate _next;
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        private static readonly string ContentType = "application/json";


        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                await HandleValidationException(context, e);
            }
            catch (Application.Exceptions.ApplicationException e)
            {
                await HandleApplicationException(context, e);
            }
            catch (DomainException e)
            {
                await HandleDomainException(context, e);
            }
        }
        private static async Task HandleValidationException(HttpContext httpContext, ValidationException validationException)
        {
            var messages = new List<Message>();
            var errors = GetErrors(validationException);

            messages.AddRange(errors.Select(i => new Message($"{i.Key} : {i.Value[0]}", MessageCode.Error)));

            var response = ApiResponse.Error(GetStatusCode(validationException), messages);

            httpContext.Response.ContentType = ContentType;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
        private static async Task HandleApplicationException(HttpContext httpContext, Application.Exceptions.ApplicationException applicationException)
        {
            var response = ApiResponse.Error(GetStatusCode(applicationException),
            [
                new(applicationException.Message,MessageCode.Error)
            ]);
            httpContext.Response.ContentType = ContentType;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
        private static async Task HandleDomainException(HttpContext httpContext, DomainException domainException)
        {
            var response = ApiResponse.Error(GetStatusCode(domainException), domainException.Messages.Select(x => new Message(x, MessageCode.Error)).ToList());
            httpContext.Response.ContentType = ContentType;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }

        private static int GetStatusCode(Exception exception) =>
                                                            exception switch
                                                            {
                                                                DomainException => StatusCodes.Status400BadRequest,
                                                                Application.Exceptions.ApplicationException => StatusCodes.Status400BadRequest,
                                                                _ => StatusCodes.Status500InternalServerError
                                                            };


        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.ErrorsDictionary;
            }
            return errors;
        }
    }
}
