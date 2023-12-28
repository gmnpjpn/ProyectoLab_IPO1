using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO_Lab2324
{
    public class GlobalData
    {
        public static List<Album> FavoritesList { get; set; }
        public static List<Album> AlbumList { get; set; }
        public static String Username { get; set; }
        public static String CurrentDateTime { get; set; }
    
        static GlobalData()
        {
            FavoritesList = new List<Album>();
            AlbumList = new List<Album>();
        }
    }
}
