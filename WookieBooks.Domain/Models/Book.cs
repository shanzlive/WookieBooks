using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WookieBooks.Domain.Models
{
    public class Book 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public Book()
        {
        }
        public Book(int id, string title, string description, string author, string coverImage, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            CoverImage = coverImage;
            Price = price;
        }

        
    }
}
