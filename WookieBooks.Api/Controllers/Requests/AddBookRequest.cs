using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WookieBooks.Api.Controllers.Requests
{
    public class AddBookRequest
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }
        [JsonPropertyName("CoverImage")]
        public string CoverImage { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
    }
}
