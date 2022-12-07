using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class Crawler<T>
    {
        private readonly Func<T, IEnumerable<T>> _nextNodes;

        public Crawler(Func<T, IEnumerable<T>> nextNodes)
        {
            _nextNodes = nextNodes;
        }

        public void Crawl(T start, Func<T, bool> visitFunction)
        {
            var crawlerQueue = new Queue<T>();
            crawlerQueue.Enqueue(start);

            while (crawlerQueue.Count > 0)
            {
                var current = crawlerQueue.Dequeue();
                if (!visitFunction(current))
                    return;

                foreach (var next in _nextNodes(current))
                    crawlerQueue.Enqueue(next);
            }
        }
    }
}
