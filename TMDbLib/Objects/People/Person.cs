using System.Collections.Generic;
using RestSharp.Deserializers;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace TMDbLib.Objects.People
{
    public class Person
    {
        public bool Adult { get; set; }
        public List<string> AlsoKnownAs { get; set; }
        public string Biography { get; set; }
        [DeserializeAs(Name = "Birthday")]
        public string BirthdayString { get; set; }
        [DeserializeAs(Name = "Deathday")]
        public string DeathdayString { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ProfilePath { get; set; }
        public Credits Credits { get; set; }
        public ProfileImages Images { get; set; }
        public ChangesContainer Changes { get; set; }

        public TMDbDate Birthday
        {
            get
            {
                if (BirthdayString == null)
                    return null;

                return new TMDbDate(BirthdayString);
            }
        }

        public TMDbDate Deathday
        {
            get
            {
                if (DeathdayString == null)
                    return null;

                return new TMDbDate(DeathdayString);
            }
        }
    }
}