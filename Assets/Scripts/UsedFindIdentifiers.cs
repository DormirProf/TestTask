using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class UsedFindIdentifiers
    {
        private List<string> _identifiers = new List<string>();

        public void AddIdentifier(string identifier)
        {
            _identifiers.Add(identifier);
        }

        public void ClearIdentifiers()
        {
            _identifiers.Clear();
        }
        
        public bool HasIdentifier(string identifier)
        {
            return _identifiers.Any(searchIdentifier => identifier == searchIdentifier);
        }
    }
}