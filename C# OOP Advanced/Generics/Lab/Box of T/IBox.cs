public interface IBox<TItem>
{
    int Count { get; }

    void Add(TItem item);
    TItem Remove();
}