﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO_Lab2324
{
    public class Artist
    {
        public string ArtisticName { get; set; }
        public string RealName { get; set; }
        public List<String> GroupComponents { get; set; }
        public string BirthDay { get; set; }
        public string GroupCreationDate { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Instagram { get; set; }
        public string X_Twitter { get; set; }
        public string Likes { get; set; }
        public string ArtistImage { get; set; }
        public List<String> AlbumList { get; set; }

        public Artist()
        {
            ArtisticName = "";
            RealName = "";
            GroupComponents = new List<String>();
            BirthDay = "";
            GroupCreationDate = "";
            Description = "";
            Genre = "";
            Instagram = "";
            X_Twitter = "";
            Likes = "";
            ArtistImage = "";
            AlbumList = new List<String>();
        }

    }
}
