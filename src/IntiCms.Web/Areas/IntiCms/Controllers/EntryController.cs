using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using IntiCms.BusinessLogic;
using IntiCms.Interfaces;
using IntiCms.ValueObjects;

namespace IntiCms.Web.Areas.IntiCms.Controllers
{
    public class EntryController : ApiController
    {
        public EntryController()
        {
            //TODO: use configuration 
            EntryAdapter = EntryService.Instance.Adapter;
        }

        public IEntryAdapter EntryAdapter { get; set; }

        // GET api/entry
        public IEnumerable<Entry> Get()
        {
            return EntryAdapter.All().OrderBy(e => e.Created);
        }

        // GET api/entry/5
        public Entry Get(string id)
        {
            return EntryAdapter.One(id);
        }

        // POST api/entry
        public void Post([FromBody]Entry value)
        {
            ensureSlug(value);

            EntryAdapter.Save(value);
        }

        // PUT api/entry/5
        public void Put(int id, [FromBody] Entry value)
        {
            ensureSlug(value);

            EntryAdapter.Save(value);
        }

        private static void ensureSlug(Entry value)
        {
            value.Slug = value.Slug.FixSlug();
        }

        // DELETE api/entry/5
        public void Delete(string id)
        {
            EntryAdapter.Delete(id);
        }
    }
}