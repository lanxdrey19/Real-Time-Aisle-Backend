using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phase2api.Services
{
    public interface IEntriesServices
    {
        public List<Entry> GetEntries();

        public Entry AddEntry(Entry theirEntry);

        public Entry UpdateEntry(string id, Entry theirEntry);

        public string DeleteEntry(string id);
    }
}
