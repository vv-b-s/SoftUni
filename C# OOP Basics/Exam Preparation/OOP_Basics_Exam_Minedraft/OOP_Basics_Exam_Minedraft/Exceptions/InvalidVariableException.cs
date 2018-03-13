using System;

public class InvalidVariableException : ArgumentException
{
    public InvalidVariableException(string abstractTypeName, string variableName):
        base($"{abstractTypeName} is not registered, because of it's {variableName}"){}
}