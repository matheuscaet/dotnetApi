namespace dotnetApi.Models
{
    public class ItemsDatabaseSettings : IItemsDatabaseSettings
    {
        public string ItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IItemsDatabaseSettings
    {
        string ItemsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}