using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.AspNetCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result)
        {
            return new ApiResult()
            {
                IsSuccess = result.Status == OperationResultStatus.Success,
                MetaData = new MetaData()
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapOperationStatus(),
                }
            };
        }

        protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData?> result,
            HttpStatusCode statusCode = HttpStatusCode.OK, string? locationUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;

            if (isSuccess)
            {
                HttpContext.Response.StatusCode = (int)statusCode;

                if (!string.IsNullOrWhiteSpace(locationUrl))
                    HttpContext.Response.Headers.Add("Location", locationUrl);
                
            }

            return new ApiResult<TData?>()
            {
                IsSuccess = result.Status == OperationResultStatus.Success,
                Data = isSuccess? result.Data : default,
                MetaData = new MetaData()
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapOperationStatus(),
                }
            };
        }

        protected ApiResult<TData> QueryResult<TData>(TData result)
        {
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                Data = result,
                MetaData = new MetaData()
                {
                    Message = "عملیات موفقیت امیز بود",
                    StatusCode = ApiStatusCode.Success,
                }
            };
        }
    }

    public static class EnumHelper
    {
        public static ApiStatusCode MapOperationStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return ApiStatusCode.Success;

                case OperationResultStatus.NotFound:
                    return ApiStatusCode.NotFound;

                case OperationResultStatus.Error:
                    return ApiStatusCode.LogicError;

                default:
                    return ApiStatusCode.ServerError;
            }
        }
    }
}
