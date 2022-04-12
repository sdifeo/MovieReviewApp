using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieReviewApp.Models
{
    internal class Review
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Score { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string ReleaseDate { get; set; }
        [MaxLength(250)]
        public string PosterPath { get; set; }
        [MaxLength(250)]
        public string MovieNote { get; set; }
        [MaxLength(250)]
        public string Overview { get; set; }

    }
}
