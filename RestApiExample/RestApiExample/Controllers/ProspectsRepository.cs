using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace RestApiExample.Controllers
{
    public class ProspectsRepository
    {
        readonly List<Prospect> _prospects;

        public ProspectsRepository()
        {
            _prospects = new List<Prospect>
                             {
                                 new Prospect {Id = 1, Name = "Prospect 1"}, 
                                 new Prospect {Id = 2, Name = "Prospect 2"}, 
                                 new Prospect {Id = 3, Name = "Prospect 3"}
                             };
        }

        public Prospect Add(Prospect prospect)
        {
            _prospects.Add(prospect);
            return _prospects.Last();
        }

        public void Delete(Prospect prospect)
        {
            _prospects.Remove(prospect);
        }

        public IEnumerable<Prospect> FindAll(Predicate<Prospect> match)
        {
            return _prospects.FindAll(match);
        }
    }
}