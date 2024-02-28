using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoxOfficeApp.Data.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
    }
}