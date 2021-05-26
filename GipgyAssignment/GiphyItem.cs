using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GipgyAssignment
{
    public class GiphyItem
    {
        public GiphyItem(string title, string url)
        {
            Title = title;
            Url = url;
        }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}