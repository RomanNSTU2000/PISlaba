using System;
using System.Collections.Generic;
using System.Linq;
using PISlaba1.Models;

namespace PISlaba1.Storage
{
    public class MemCache : IStorage<Lab1Data>
    {
        private object _sync = new object();
        private List<Lab1Data> _memCache = new List<Lab1Data>();
        public Lab1Data this[Guid id] 
        { 
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectLabDataException($"No LabData with id {id}");

                    return _memCache.Single(x => x.Ids == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectLabDataException("Cannot request LabData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Ids = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Lab1Data> All => _memCache.Select(x => x).ToList();

        public void Add(Lab1Data value)
        {
            if (value.Ids != Guid.Empty) throw new IncorrectLabDataException($"Cannot add value with predefined id {value.Ids}");

            value.Ids = Guid.NewGuid();
            this[value.Ids] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Ids == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Ids == id);
            }
        }
    }
}