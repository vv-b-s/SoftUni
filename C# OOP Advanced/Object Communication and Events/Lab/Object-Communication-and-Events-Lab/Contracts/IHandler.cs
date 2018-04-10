using System;
using System.Collections.Generic;
using System.Text;


public enum LogType { ATTACK, MAGIC, ERROR, EVENT}
public interface IHandler
{
    void Handle(LogType type, string message);

    void SetSuccessor(IHandler successor);
}
