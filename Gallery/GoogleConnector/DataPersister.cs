namespace GoogleConnector
{
    using System.Net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Script.Serialization;

    using GoogleConnector.BindingModel;
    using GoogleConnector.GoogleDtos;

    public static class DataPersister
    {
        private const string baseUrl = "https://ajax.googleapis.com/ajax/services/search/images?v=1.0";

        private static string GenerateUrl(string question, Size size, int? maxImages)
        {
            var url = baseUrl;

            if (!string.IsNullOrEmpty(question))
            {
                url += "&q=" + question.Replace(" ", "%20");
            }

            if (!string.IsNullOrEmpty(size.ToString()))
            {
                url += "&imgsz=" + size;
            }

            if (maxImages != null)
            {
                url += "&rsz=" + maxImages;
            }

            return url;
        }
        
        private static string GetJson(string url)
        {
            string json = String.Empty;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            return json;
        }

        private static IEnumerable<GoogleImageResultDto> ParseJsonResponse(string json)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var response = ser.Deserialize<GoogleApiImagesDto>(json);

            if (int.Parse(response.responseStatus) != 200)
            {
                return null;
            }

            return response.responseData.results;
        }

        public static IEnumerable<string> GetImageUrls(IBindingModel searchQuery)
        {
            var search = (GoogleImageSearch)searchQuery;
            var response = ParseJsonResponse(GetJson(GenerateUrl(search.SearchText, search.ImageSize, search.MaxImages)));

            if (response == null)
            {
                return new List<string>();
            }

            return response.Select(image => image.url).ToList();
        }
    }
}
