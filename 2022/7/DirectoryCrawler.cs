using _0;

namespace _7
{
    public class DirectoryCrawler
    {
        private ElfTermDirectory _rootDirectory;

        public DirectoryCrawler(ElfTermDirectory rootDirectory)
        {
            _rootDirectory = rootDirectory;
        }

        public IEnumerable<ElfTermFileSystemObject> Find(Func<ElfTermDirectory, bool> searchFunction)
        {
            var results = new List<ElfTermFileSystemObject>();
            var crawler = new Crawler<ElfTermDirectory>(x => x.Objects.OfType<ElfTermDirectory>());
            crawler.Crawl(_rootDirectory, x =>
            {
                if (searchFunction(x)) { results.Add(x); }
                return true;
            });
            return results;
        }
    }
}