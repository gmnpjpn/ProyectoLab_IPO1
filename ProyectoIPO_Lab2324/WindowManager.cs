using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO_Lab2324
{
    public static class WindowManager
    {
        public static LoginWindow LoginWindowInstance { get; set; }
        public static LandingWindow LandingWindowInstance { get; set; }
        public static UserWindow UserWindowInstance { get; set; }
        public static ContactWindow ContactWindowInstance { get; set; }
        public static FaqsWindow FaqsWindowInstance { get; set; }
        public static ShoppingCartWindow ShoppingCartWindowInstance { get; set;}
        public static ArtistWindow ArtistWindowInstance { get; set; }
    }
}
