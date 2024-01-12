using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO_Lab2324
{
    class Faq
    {
        public string Title { set ; get; }
        public string ListTitle { set ; get; }
        public string Content { set ; get; }

        public Faq()
        {
            Title = "";
            ListTitle = "";
            Content = "";
        }
    }
}
