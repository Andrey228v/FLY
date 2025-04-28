using System;

public interface IUserInput 
{
    public event Action Jumped;
    public event Action Attacked;
}
