using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WookieBooks.Api.Controllers.Requests
{
    public class UpdateBookRequest
    {
        [Required(ErrorMessage = "Please enter the Id.")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Title.")]
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the Description.")]
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please mention the Author.")]
        [JsonPropertyName("Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please select a Cover Image.")]
        [JsonPropertyName("CoverImage")]
        public string CoverImage { get; set; }
        [JsonPropertyName("Price")]
        [Required(ErrorMessage = "Please enter the Price.")]
        public decimal Price { get; set; }
    }
}
