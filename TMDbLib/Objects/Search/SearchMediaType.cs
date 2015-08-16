using System.ComponentModel;

namespace TMDbLib.Objects.Search
{
    public enum SearchMediaType
    {
        Unknown,

        [Description("movie")]
        Movie,

        [Description("tv")]
        TVShow,

        [Description("person")]
        Person
    }
}