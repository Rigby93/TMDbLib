using System.Threading.Tasks;
using System;
using RestSharp;
using RestSharp.Deserializers;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using TMDbLib.Utilities;

namespace TMDbLib.Client
{
    public partial class TMDbClient
    {
        private RestRequest SearchBuildRequest(string method, string query, int page)
        {
            RestRequest req = new RestRequest("search/{method}");
            req.AddUrlSegment("method", method);
            req.AddParameter("query", query);

            if (page >= 1)
                req.AddParameter("page", page);

            req.DateFormat = "yyyy-MM-dd";

            return req;
        }

        public async Task<SearchContainer<SearchCompany>> SearchCompany(string query, int page = 0)
        {
            RestRequest req = SearchBuildRequest("company", query, page);

            IRestResponse<SearchContainer<SearchCompany>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchCompany>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchResultCollection>> SearchCollection(string query, int page = 0)
        {
            return await SearchCollection(query, DefaultLanguage, page);
        }

        public async Task<SearchContainer<SearchResultCollection>> SearchCollection(string query, string language, int page = 0)
        {
            RestRequest req = SearchBuildRequest("collection", query, page);

            language = language ?? DefaultLanguage;
            if (!String.IsNullOrWhiteSpace(language))
                req.AddParameter("language", language);

            IRestResponse<SearchContainer<SearchResultCollection>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchResultCollection>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchKeyword>> SearchKeyword(string query, int page = 0)
        {
            RestRequest req = SearchBuildRequest("keyword", query, page);

            IRestResponse<SearchContainer<SearchKeyword>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchKeyword>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchList>> SearchList(string query, int page = 0, bool includeAdult = false)
        {
            RestRequest req = SearchBuildRequest("list", query, page);

            req.AddParameter("include_adult", includeAdult ? "true" : "false");

            IRestResponse<SearchContainer<SearchList>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchList>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchMovie>> SearchMovie(string query, int page = 0, bool includeAdult = false, int year = 0, int primaryReleaseYear = 0, SearchQueryType searchType = SearchQueryType.Undefined)
        {
            return await SearchMovie(query, DefaultLanguage, page, includeAdult, year, primaryReleaseYear, searchType);
        }

        public async Task<SearchContainer<SearchMovie>> SearchMovie(string query, string language, int page = 0, bool includeAdult = false, int year = 0, int primaryReleaseYear = 0, SearchQueryType searchType = SearchQueryType.Undefined)
        {
            RestRequest req = SearchBuildRequest("movie", query, page);

            language = language ?? DefaultLanguage;
            if (!String.IsNullOrWhiteSpace(language))
                req.AddParameter("language", language);

            req.AddParameter("include_adult", includeAdult ? "true" : "false");

            if (year > 0)
                req.AddParameter("year", year);

            if (primaryReleaseYear > 0)
                req.AddParameter("primary_release_year", primaryReleaseYear);

            if (searchType != SearchQueryType.Undefined)
                req.AddParameter("search_type", searchType.GetDescription());

            IRestResponse<SearchContainer<SearchMovie>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchMovie>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchMulti>> SearchMulti(string query, int page = 0, bool includeAdult = false)
        {
            return await SearchMulti(query, DefaultLanguage, page, includeAdult);
        }

        public async Task<SearchContainer<SearchMulti>> SearchMulti(string query, string language, int page = 0, bool includeAdult = false)
        {
            RestRequest req = SearchBuildRequest("multi", query, page);

            language = language ?? DefaultLanguage;
            if (!String.IsNullOrWhiteSpace(language))
                req.AddParameter("language", language);

            req.AddParameter("include_adult", includeAdult ? "true" : "false");

            IRestResponse<SearchContainer<SearchMulti>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchMulti>>(req).ConfigureAwait(false);

            // Do custom parsing
            CustomDeserialization.DeserializeMultiSearchContent(resp.Data, resp.Content);
            
            return resp.Data;
        }

        public async Task<SearchContainer<SearchPerson>> SearchPerson(string query, int page = 0, bool includeAdult = false, SearchQueryType searchType = SearchQueryType.Undefined)
        {
            RestRequest req = SearchBuildRequest("person", query, page);

            req.AddParameter("include_adult", includeAdult ? "true" : "false");

            if (searchType != SearchQueryType.Undefined)
                req.AddParameter("search_type", searchType.GetDescription());

            IRestResponse<SearchContainer<SearchPerson>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchPerson>>(req).ConfigureAwait(false);
            return resp.Data;
        }

        public async Task<SearchContainer<SearchTv>> SearchTvShow(string query, int page = 0, int firstAirDateYear = 0, SearchQueryType searchType = SearchQueryType.Undefined)
        {
            return await SearchTvShow(query, DefaultLanguage, page, firstAirDateYear, searchType);
        }

        public async Task<SearchContainer<SearchTv>> SearchTvShow(string query, string language, int page = 0, int firstAirDateYear = 0, SearchQueryType searchType = SearchQueryType.Undefined)
        {
            RestRequest req = SearchBuildRequest("tv", query, page);

            language = language ?? DefaultLanguage;
            if (!String.IsNullOrWhiteSpace(language))
                req.AddParameter("language", language);

            if (firstAirDateYear > 0)
                req.AddParameter("first_air_date_year", firstAirDateYear);

            if (searchType != SearchQueryType.Undefined)
                req.AddParameter("search_type", searchType.GetDescription());

            IRestResponse<SearchContainer<SearchTv>> resp = await _client.ExecuteGetTaskAsync<SearchContainer<SearchTv>>(req).ConfigureAwait(false);
            return resp.Data;
        }
    }
}