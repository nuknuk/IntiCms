using IntiCms.BusinessLogic;

namespace IntiCms.Web
{
    public class EntryService
    {
        public static readonly EntryService Instance = new EntryService();

        private EntryService()
        {
            // TODO: initialize components using your favorite technique. DI? Config? Other?
            Adapter = new MongoDbEntryAdapter("mongodb://localhost", "test");
        }

        public MongoDbEntryAdapter Adapter { get; set; }
    }
}