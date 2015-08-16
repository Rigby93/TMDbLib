using System.ComponentModel;

namespace TMDbLib.Objects.Search
{
    public enum SearchQueryType
    {
        Undefined,

        /// <summary>
        /// Standard search type
        /// </summary>
        [Description("phrase")]
        Phrase,

        /// <summary>
        /// More "autocomplete-like" searching
        /// </summary>
        [Description("ngram")]
        Ngram
    }
}