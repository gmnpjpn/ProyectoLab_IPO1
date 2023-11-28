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
        public string Content { set ; get; }

        public Faq(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
