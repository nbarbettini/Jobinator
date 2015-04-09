using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net.Http;

namespace Jobinator.Core.WebApiConfig
{
    // Borrowed from http://www.strathweb.com/2013/06/supporting-only-json-in-asp-net-web-api-the-right-way/
    // This replaced the default Web API content negotiator with one that only returns JSON
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
}