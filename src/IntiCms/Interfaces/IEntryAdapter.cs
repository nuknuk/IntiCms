using System.Linq;

using IntiCms.ValueObjects;

namespace IntiCms.Interfaces
{
    public interface IEntryAdapter
    {
        Entry One(string slug);

        IQueryable<Entry> All();

        void Save(Entry entry);

        void Delete(string slug);
    }
}