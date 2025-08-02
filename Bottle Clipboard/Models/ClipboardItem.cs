using System;

namespace ClipTagger.Models
{
    public class ClipboardItem
    {
        public string Content { get; set; }
        public string Tags { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
