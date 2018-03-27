using System.Collections.Generic;

public class Box<TItem> : IBox<TItem>
{
    private Stack<TItem> itemStack;

    public Box()
    {
        this.itemStack = new Stack<TItem>();
    }

    public int Count => this.itemStack.Count;

    public void Add(TItem item) => this.itemStack.Push(item);

    public TItem Remove() => this.itemStack.Pop();
}
