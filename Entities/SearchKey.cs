using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Entities
{
    public class SearchKey
    {
        private SearchKey()
        {
        }


        public SearchKey(string word)
        {
            Word = word;
        }

        public int Id { get; set; }
        public string Word { get; set; }
    }
}