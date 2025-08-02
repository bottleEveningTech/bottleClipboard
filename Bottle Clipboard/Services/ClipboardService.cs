using ClipTagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Bottle_Clipboard.Services
{
    public class ClipboardService
    {
        private string _lastContent = "";
        private DispatcherTimer _timer;

        public void Start()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => CheckClipboard();
            _timer.Start();
        }

        private void CheckClipboard()
        {
            try
            {
                if (System.Windows.Clipboard.ContainsText())
                {
                    string content = System.Windows.Clipboard.GetText();
                    if (!string.IsNullOrWhiteSpace(content) && content != _lastContent)
                    {
                        _lastContent = content;
                        ClipboardStore.Instance.Items.Insert(0, new ClipboardItem
                        {
                            Content = content,
                            Tags = "",
                            Timestamp = DateTime.Now
                        });
                    }
                }
            }
            catch
            {
                // Clipboard access might fail due to threading, permissions, etc.
            }
        }
    }
}
