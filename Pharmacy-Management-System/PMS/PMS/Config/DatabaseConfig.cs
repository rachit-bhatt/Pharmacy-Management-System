using System.Xml.Linq;

namespace PMS.Config
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;

        public static DatabaseConfig Load(string path)
        {
            var xml = XDocument.Load(path);
            var root = xml.Element(nameof(DatabaseConfig));
            return new DatabaseConfig
            {
                ConnectionString = root?.Element(nameof(ConnectionString))?.Value,
                DatabaseName = root?.Element(nameof(DatabaseName))?.Value,
                CollectionName = root?.Element(nameof(CollectionName))?.Value
            };
        }
    }
}