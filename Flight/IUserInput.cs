﻿public interface IUserInput
{
    string ReadLine();
}
public class ConsoleUserInput : IUserInput
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}
