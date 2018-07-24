using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.RequestAndResponse
{
    public class WordsRequest
    {
        [Required]
        public IEnumerable<string> Words { get; set; }
    }
}