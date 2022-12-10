namespace _0
{
    public class Dictionary2D<TKey1, TKey2, TValue>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        private Dictionary<TKey1, Dictionary<TKey2, TValue>> _dictionary = new Dictionary<TKey1, Dictionary<TKey2, TValue>>();
        private readonly Func<TKey1, TKey2, TValue>? _constructValue;

        public Dictionary2D() { }

        public Dictionary2D(Func<TKey1, TKey2, TValue> constructValue)
        {
            _constructValue = constructValue;
        }

        private void EnsureKeyExists(TKey1 key1, TKey2 key2)
        {
            if (!_dictionary.ContainsKey(key1))
            {
                _dictionary[key1] = new Dictionary<TKey2, TValue>();
            }

            if (!_dictionary[key1].ContainsKey(key2))
            {
                _dictionary[key1][key2] = _constructValue != null ? _constructValue(key1, key2) : default;
            }
        }

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get
            {
                EnsureKeyExists(key1, key2);
                return _dictionary[key1][key2];
            }

            set
            {
                EnsureKeyExists(key1, key2);
                _dictionary[key1][key2] = value;
            }
        }

        public int Width { get { return _dictionary.Count; } }

        public int Height { get { return _dictionary.Max(x => x.Value.Count); } }

        public IEnumerable<TValue> AsEnumerable()
        {
            foreach (var kvp in _dictionary)
            {
                foreach (var k2p in kvp.Value)
                {
                    yield return k2p.Value;
                }
            }
        }
    }
}