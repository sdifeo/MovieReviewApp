using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReviewApp.Models
{
    internal class MovieSearch
    {
        public Result[] Results { get; set; }
    }

    internal class Result
    {
        public string Release_Date { get; set; }
        public string Poster_Path { get; set; }
        public string Overview { get; set; }
    }
}
