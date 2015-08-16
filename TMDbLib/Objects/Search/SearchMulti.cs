using System;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Search
{
    public class SearchMulti
    {
        public int Id { get; set; }

        public string Title { set { Name = value; } get { return Name; } }
        public string Name { get; set; }

        public string BackdropPath { set { PosterPath = value; } get { return PosterPath; } }
        public string PosterPath { get; set; }

        public SearchMediaType Type { get; set; }
        public double Popularity { get; set; }

        public SearchTv AsTvShow { get; set; }
        public SearchMovie AsMovie { get; set; }
        public SearchPerson AsPerson { get; set; }

        // Individual fields not found in all three Media Types
        //public string OriginalName { get; set; }
        //public string OriginalTitle { set { OriginalName = value; } }
        //public DateTime? FirstAirDate { get; set; }
        //public double VoteAverage { get; set; }
        //public int VoteCount { get; set; }
        //public bool Adult { get; set; }
        //public DateTime? ReleaseDate { get; set; }
        //public List<string> OriginCountry { get; set; }

        public string MediaType
        {
            set
            {
                if (SearchMediaType.Movie.GetDescription().Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    Type = SearchMediaType.Movie;
                else if (SearchMediaType.TVShow.GetDescription().Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    Type = SearchMediaType.TVShow;
                else if (SearchMediaType.Person.GetDescription().Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    Type = SearchMediaType.Person;
                else
                    Type = SearchMediaType.Unknown;
            }
        }
    }
}
