using phase2api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phase2api.Services
{
    public class EntriesService : IEntriesService
    {

        private List<Entry> _entryItems;

        public EntriesService()
        {
            _entryItems = new List<Entry>();
        }

        public Entry AddEntry(Entry theirEntry)
        {
            _entryItems.Add(theirEntry);
            return theirEntry;
        }

        public string DeleteEntry(string id)
        {
            for (var index = 0; index < _entryItems.Count; index++)
            {
                if (_entryItems[index].EntryId.Equals(id))
                {
                    _entryItems.RemoveAt(index);
                }
            }
            return id;
        }

        public List<Entry> GetEntries()
        {
            return _entryItems;
        }

        public Entry UpdateEntry(string id, Entry theirEntry)
        {
            for (var index = 0; index < _entryItems.Count; index++)
            {
                if (_entryItems[index].EntryId.Equals(id) )
                {
                    _entryItems[index] = theirEntry;
                }
            }
            return theirEntry;
        }
    }
}
