namespace LGU.Entities
{
    public delegate void EntityCollectionEventHandler(object sender, EntityCollectionEventArgs e);
    public delegate void EntityCollectionEventHandler<T>(object sender, EntityCollectionEventArgs<T> e);
    public delegate void EntityCollectionEventHandler<T, TIdentifier>(object sender, EntityCollectionEventArgs<T, TIdentifier> e) where T : IEntity<TIdentifier>;
}