using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_2_Poleev
{
    struct Song
    {
        public string Author;
        public string Title;
        public string Filename;

        public Song(string author, string title, string filename)
        {
            Author = author;
            Title = title;
            Filename = filename;
        }

    }
}
