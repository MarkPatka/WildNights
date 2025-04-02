﻿namespace WildNights.UserService.Domain.Common.Errors.Abstract;

public abstract class Error(ErrorType type, string message) 
    : Exception(message)
{
    public ErrorType Type { get; private set; } = type;
}
