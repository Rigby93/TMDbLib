using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace TMDbLib.Objects.People
{
    public class Person
    {
        public bool Adult { get; set; }
        public List<string> AlsoKnownAs { get; set; }
        public string Biography { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ProfilePath { get; set; }
        public Credits Credits { get; set; }
        public ProfileImages Images { get; set; }
        public ChangesContainer Changes { get; set; }

        public TMDbDate BirthDayDate
        {
            get
            {
                if (Birthday == null)
                    return null;

                return new TMDbDate(Birthday);
            }
        }

        public TMDbDate DeathdayDate
        {
            get
            {
                if (Deathday == null)
                    return null;

                return new TMDbDate(Deathday);
            }
        }
    }
}