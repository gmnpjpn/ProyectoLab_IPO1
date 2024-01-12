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
        public static List<Artist> ArtistList { get; set; }
        public static List<Album> ShoppingCartList { get; set; }
        public static List<Album> OrdersHistoryList { get; set; }
        public static String Username { get; set; }
        public static String CurrentDateTime { get; set; }
        public static int counterLanding { get; set; } = 0;
        public static double totalPrice { get; set; } = 0.0;
    
        static GlobalData()
        {
            FavoritesList = new List<Album>();
            AlbumList = new List<Album>();
            ArtistList = new List<Artist>();
            ShoppingCartList = new List<Album>();
            OrdersHistoryList = new List<Album>();
        }
    }
}
