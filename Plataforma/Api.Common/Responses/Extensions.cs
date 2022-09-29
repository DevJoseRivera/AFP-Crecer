using Library.Clients.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Common.Responses
{
    public static class Extensions
    {
        public static IActionResult ToOkResult(this IResponse response, bool? isFailed = null, string? message = null)
        {
            response.IsFailed = isFailed;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult ToOkResult<T>(this ISingleResponse<T> response, bool? isFailed = null, string? message = null)
        {
            response.IsFailed = isFailed;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult ToOkResult<T>(this IListResponse<T> response, bool? isFailed = null, string? message = null)
        {
            response.IsFailed = isFailed;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult ToCreatedResult(this IResponse response, string? message = null)
        {
            response.IsFailed = false;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }

        public static IActionResult ToNotFoundResult(this IResponse response, bool? isFailed = null, string? message = null)
        {
            response.IsFailed = isFailed;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        public static IActionResult ToInternalServerError(this IResponse response, string? message = null)
        {
            response.IsFailed = true;

            if (string.IsNullOrEmpty(message))
                response.Message = message;

            return new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
