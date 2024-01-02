using System;
using System.Collections.Generic;

namespace ProyectoIPO_Lab2324
{
    public class Album
    {
        public String Name { set; get; }
        public String Author { set; get; }
        public Uri Cover { set; get; }
        public String Genre { set; get; }
        public List<string> Songs { set; get; }
        public String LaunchYear { set; get; }
        public String RecordLabel { set; get; }
        public String Format { set; get; }
        public String Country { set; get; }
        public String Likes { set; get; }
        public String Puntuation { set; get; }
        public String Pvp { set; get; }
        public String Stock { set; get; }

        public Album()
        {
            Name = "";
            Author = "";
            Cover = null;
            Genre = "";
            LaunchYear = "";
            Songs = new List<string>();
            RecordLabel = "";
            Format = "";
            Country = "";
            Likes = "";
            Puntuation = "";
            Pvp = "";
            Stock = "";
        }
    }
}
