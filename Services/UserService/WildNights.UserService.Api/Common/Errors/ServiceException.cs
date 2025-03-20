﻿namespace WildNights.UserService.Api.Common.Errors;

public class ServiceException(int statusCode, string message) : Exception
{
    public int StatusCode { get; } = statusCode;

    public string ErrorMessage { get; } = message;
}
