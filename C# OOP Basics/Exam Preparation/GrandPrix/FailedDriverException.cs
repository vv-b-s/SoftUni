using System;

public class FailedDriverException : ArgumentException
{
    public FailedDriverException(string message) : base(message) { }
}