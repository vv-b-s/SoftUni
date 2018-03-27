using System;

public interface IScale<T> where T: IComparable<T>
{
    T GetHeavier();
}