public interface IBox<TItem>
{
    void AddItems(params TItem[] items);
}