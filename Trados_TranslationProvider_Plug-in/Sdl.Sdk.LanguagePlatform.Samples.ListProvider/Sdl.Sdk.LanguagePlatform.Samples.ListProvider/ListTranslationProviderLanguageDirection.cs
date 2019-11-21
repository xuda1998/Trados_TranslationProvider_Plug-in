using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.IO;
using Sdl.Core.Globalization;
using System.Threading.Tasks;
using System.Net;


namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    class ListTranslationProviderLanguageDirection : ITranslationProviderLanguageDirection
    {
        #region ITranslationProviderLanguageDirection Members
        private ListTranslationProvider _provider;
        private LanguagePair _languageDirection;
        private ListTranslationOptions _options;  
        private TranslationUnit _inputTu;
        public ListTranslationProviderLanguageDirection(ListTranslationProvider provider, LanguagePair languages)  //构造函数 
        {
            #region "Instantiate"
            _provider = provider;
            _languageDirection = languages;
            _options = _provider.Options;

            #endregion
        }

        public static string Post(string url, string content)     //将待翻译文本以post形式发送到后端，并返回翻译结果
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream()) 
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }


        private String Bit_Translation(String sourcetext)  //调用翻译方法或者翻译引擎，或直接查找本地文件。
        {
            string requestData = sourcetext;          // 发送的数据
            string url = "http://127.0.0.1:5000/test";  // 服务器地址

            string result = Post(url, requestData);

            //StreamReader transfile = new StreamReader("E://test.txt");  //test.txt为测试文件，文件中仅包含翻译结果
            //String ans = transfile.ReadLine();
            return result;
        }

        public SearchResults SearchSegment(SearchSettings settings, Segment segment)            //搜索方法 
        {
            SearchResults results = new SearchResults();
            results.SourceSegment = segment.Duplicate();
            var newseg = segment.Duplicate();
    
     
            Segment translation = new Segment(_languageDirection.TargetCulture);//设置目标语言
            String sourcetext = newseg.ToPlain();//获取原字段的纯文本
            String transtext = Bit_Translation(sourcetext); //调用翻译方法

            translation.Add(transtext);        //存入翻译文本 --------------测试
            results.Add(CreateSearchResult(segment, translation,newseg.ToPlain()));//创建searchresults实例

            return results;
        }

        private SearchResult CreateSearchResult(Segment searchSegment, Segment translation, string sourceSegment)     //构建搜索结果
        {
            #region "TranslationUnit"
            TranslationUnit tu = new TranslationUnit();
            tu.SourceSegment = searchSegment.Duplicate();
            tu.TargetSegment = translation;
            #endregion

            tu.ResourceId = new PersistentObjectToken(tu.GetHashCode(), Guid.Empty);

            int score = 100;
            tu.Origin = TranslationUnitOrigin.MachineTranslation;


            SearchResult searchResult = new SearchResult(tu);
            searchResult.ScoringResult = new ScoringResult();
            searchResult.ScoringResult.BaseScore = score;

            tu.ConfirmationLevel = ConfirmationLevel.Draft;

            return searchResult;
        }


        public SearchResults[] SearchSegments(SearchSettings settings, Segment[] segments)
        {
            var results = new SearchResults[segments.Length];
            for (var p = 0; p < segments.Length; ++p)
            {
                results[p] = SearchSegment(settings, segments[p]);
            }
            return results;
        }

        public SearchResults[] SearchSegmentsMasked(SearchSettings settings, Segment[] segments, bool[] mask)
        {
            if (segments == null)
            {
                throw new ArgumentNullException("segments in SearchSegmentsMasked");
            }
            if (mask == null || mask.Length != segments.Length)
            {
                throw new ArgumentException("mask in SearchSegmentsMasked");
            }

            var results = new SearchResults[segments.Length];
            for (var p = 0; p < segments.Length; ++p)
            {
                if (mask[p])
                {
                    results[p] = SearchSegment(settings, segments[p]);
                }
                else
                {
                    results[p] = null;
                }
            }
            return results;
        }

        public SearchResults SearchText(SearchSettings settings, string segment)
        {
            var currentSegment = new Segment(_languageDirection.SourceCulture);
            currentSegment.Add(segment);
            return SearchSegment(settings, currentSegment);
        }

        public SearchResults SearchTranslationUnit(SearchSettings settings, TranslationUnit translationUnit)
        {
            //need to use the tu confirmation level in searchsegment method
            _inputTu = translationUnit;
            return SearchSegment(settings, translationUnit.SourceSegment);
        }

        public SearchResults[] SearchTranslationUnits(SearchSettings settings, TranslationUnit[] translationUnits)
        {
            var results = new SearchResults[translationUnits.Length];
            for (var p = 0; p < translationUnits.Length; ++p)
            {
                //need to use the tu confirmation level in searchsegment method
                _inputTu = translationUnits[p];
                results[p] = SearchSegment(settings, translationUnits[p].SourceSegment); //changed this to send whole tu
            }
            return results;
        }

        public SearchResults[] SearchTranslationUnitsMasked(SearchSettings settings, TranslationUnit[] translationUnits, bool[] mask)
        {
            // bug LG-15128 where mask parameters are true for both CM and the actual TU to be updated which cause an unnecessary call for CM segment
            var results = new List<SearchResults>();
            var i = 0;
            foreach (var tu in translationUnits)
            {
                if (mask == null || mask[i])
                {
                    var result = SearchTranslationUnit(settings, tu);
                    results.Add(result);
                }
                else
                {
                    results.Add(null);
                }
                i++;
            }
            return results.ToArray();
        }

        public System.Globalization.CultureInfo SourceLanguage => _languageDirection.SourceCulture;

        public System.Globalization.CultureInfo TargetLanguage => _languageDirection.TargetCulture;

        public ITranslationProvider TranslationProvider => _provider;


        #region the useless 
        public ImportResult UpdateTranslationUnit(TranslationUnit translationUnit)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] UpdateTranslationUnits(TranslationUnit[] translationUnits)
        {
            throw new NotImplementedException();
        }


        public ImportResult[] AddOrUpdateTranslationUnits(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddOrUpdateTranslationUnitsMasked(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings, bool[] mask)
        {
            ImportResult[] result = { AddTranslationUnit(translationUnits[translationUnits.GetLength(0) - 1], settings) };
            return result;
        }

        public ImportResult AddTranslationUnit(TranslationUnit translationUnit, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddTranslationUnits(TranslationUnit[] translationUnits, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddTranslationUnitsMasked(TranslationUnit[] translationUnits, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        #endregion
        public bool CanReverseLanguageDirection { get; } = false;
        #endregion
    }
}
