using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Store;

namespace Kaio.Core
{
    public class LuceneContext
    {

        public static Lucene.Net.Util.Version CurrentVersion
        {
            get { return Lucene.Net.Util.Version.LUCENE_30; }
        }

        private static FSDirectory _directoryTemp;
        public static FSDirectory Directory
        {
            get
            {

                var _dir = HttpContext.Current != null
                               ? Path.Combine(HttpRuntime.AppDomainAppPath, "LuceneIndex")
                               : "LuceneIndex";

                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_dir));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_dir, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }



        public static Query ParseQuery(string searchQuery, QueryParser parser)
        {
            Query _query;
            try
            {
                _query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                _query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return _query;
        }

        public static void Remove(string id)
        {
            // init lucene
            var _analyzer = new StandardAnalyzer(CurrentVersion);
            using (var _writer = new IndexWriter(Directory, _analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // remove older index entry
                var _searchQuery = new TermQuery(new Term("Id", id));
                _writer.DeleteDocuments(_searchQuery);
                _analyzer.Close();
                _writer.Dispose();
            }
        }
        public static bool Clear()
        {
            try
            {
                var _analyzer = new StandardAnalyzer(CurrentVersion);
                using (var _writer = new IndexWriter(Directory, _analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    // remove older index entries
                    _writer.DeleteAll();
                    // close handles
                    _analyzer.Close();
                    _writer.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void Optimize()
        {
            var _analyzer = new StandardAnalyzer(CurrentVersion);
            using (var _writer = new IndexWriter(Directory, _analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                _analyzer.Close();
                _writer.Optimize();
                _writer.Dispose();
            }
        }


        public static void Add(IEnumerable<LuceneIndexObject> objects)
        {
            // init lucene
            var _analyzer = new StandardAnalyzer(CurrentVersion);
            using (var _writer = new IndexWriter(Directory, _analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entries if any)
                foreach (var _obj in objects) Add(_obj, _writer);

                // close handles
                _analyzer.Close();
                _writer.Dispose();
            }
        }

        public static void Add(LuceneIndexObject obj)
        {
            var _analyzer = new StandardAnalyzer(CurrentVersion);
            using (var _writer = new IndexWriter(Directory, _analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                Add(obj, _writer);
                _analyzer.Close();
                _writer.Dispose();
            }
        }

        public static void Add(LuceneIndexObject obj, IndexWriter writer)
        {
            // remove older index entry
            var _searchQuery = new TermQuery(new Term("Id", obj.Id));
            writer.DeleteDocuments(_searchQuery);

            // add new index entry
            var _doc = new Document();

            // add lucene fields mapped to db fields
            _doc.Add(new Field("Id", obj.Id, Field.Store.YES, Field.Index.NOT_ANALYZED));
            _doc.Add(new Field("Image", obj.Id, Field.Store.YES, Field.Index.NOT_ANALYZED));
            _doc.Add(new Field("Name", obj.Name, Field.Store.YES, Field.Index.ANALYZED));
            _doc.Add(new Field("Html", obj.Html, Field.Store.YES, Field.Index.ANALYZED));

            // add entry to index
            writer.AddDocument(_doc);
        }

        public static LuceneIndexObject Info(Document doc)
        {
            return new LuceneIndexObject
            {
                Id = doc.Get("Id"),
                Name = doc.Get("Name"),
                Image = doc.Get("Image"),
                Html = doc.Get("Html")
            };
        }


      

        public static IEnumerable<LuceneIndexObject> Search(string searchQuery, string searchField = "", int limit = 500)
        {

            var _terms = searchQuery.Trim().Replace("-", " ").Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            searchQuery = string.Join(" ", _terms);

            // validation
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<LuceneIndexObject>();

            // set up lucene searcher
            using (var _searcher = new IndexSearcher(Directory, false))
            {

                var _analyzer = new StandardAnalyzer(CurrentVersion);
                // search by single field
                if (!string.IsNullOrEmpty(searchField))
                {
                    var _parser = new QueryParser(CurrentVersion, searchField, _analyzer);
                    var _query = ParseQuery(searchQuery, _parser);
                    var _hits = _searcher.Search(_query, limit).ScoreDocs;
                    var _results = MapLuceneToDataList(_hits, _searcher);
                    _analyzer.Close();
                    _searcher.Dispose();
                    return _results;
                }
                // search by multiple fields (ordered by RELEVANCE)
                else
                {
                    var _parser = new MultiFieldQueryParser(CurrentVersion, new[] { "Id", "Name", "Html" }, _analyzer);
                    var _query = ParseQuery(searchQuery, _parser);
                    var _hits = _searcher.Search(_query, null, limit, Sort.INDEXORDER).ScoreDocs;
                    var _results = MapLuceneToDataList(_hits, _searcher);
                    _analyzer.Close();
                    _searcher.Dispose();
                    return _results;
                }
            }
        }


        private static IEnumerable<LuceneIndexObject> MapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
            return hits.Select(hit => Info(searcher.Doc(hit.Doc))).ToList();
        }

      /*  public string GeneratePreviewText(Query q, string text)
        {
            var scorer = new QueryScorer(q);
            var formatter = new SimpleHTMLFormatter(highlightStartTag, highlightEndTag);
            var highlighter = new Highlighter(formatter, scorer);
           // highlighter.SetTextFragmenter(new SimpleFragmenter(fragmentLength));
            TokenStream stream = new StandardAnalyzer(CurrentVersion).TokenStream(new StringReader(text));
            return highlighter.GetBestFragments(stream, text, fragmentCount, fragmentSeparator);
        }*/
    }
}
