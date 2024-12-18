using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class UsedFindIdentifiers : MonoBehaviour
    {
        private List<string> _identifiers = new List<string>();
        
        private void OnDisable()
        {
            _identifiers.Clear();
        }

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