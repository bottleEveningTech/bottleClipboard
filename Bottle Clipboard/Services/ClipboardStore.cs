using ClipTagger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bottle_Clipboard.Services
{
    public class ClipboardStore
    {
        public ObservableCollection<ClipboardItem> Items { get; } = new();
        public static ClipboardStore Instance { get; } = new ClipboardStore();
    }
}

