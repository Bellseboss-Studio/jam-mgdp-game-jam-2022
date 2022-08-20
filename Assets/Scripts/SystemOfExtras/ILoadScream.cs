using System;

public interface ILoadScream
{
    void Open(Action action);
    void Close(Action action);
}