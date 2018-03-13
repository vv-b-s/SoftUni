public abstract class IdentifiableObject : IIdentifiable
{
    private string id;

    protected IdentifiableObject(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }
}