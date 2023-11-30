using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO_Lab2324
{
    class Album
    {
        public string Name { set; get; }
        public string Author { set; get; }
        public Uri Cover { set; get; }
        public string Genre { set; get; }
        public List<string> Songs { set; get; }
        public String LaunchYear { set; get; }

        public Album(string name, string author, Uri cover, string genre, string launchYear)
        {
            Name = name;
            Author = author;
            Cover = cover;
            Genre = genre;
            LaunchYear = launchYear;
            Songs = new List<string>();
        }
    }
}
