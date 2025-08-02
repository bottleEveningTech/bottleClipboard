using Bottle_Clipboard.Services;
using System;
using System.Windows;
using System.Windows.Forms;

namespace Bottle_Clipboard
{
    public partial class App : System.Windows.Application
    {
        private NotifyIcon _trayIcon;
        private ClipboardService _clipboardService;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _trayIcon = new NotifyIcon
            {
                Icon = System.Drawing.SystemIcons.Information,
                Visible = true,
                Text = "Bottle_Clipboard"
            };

            var menu = new ContextMenuStrip();
            menu.Items.Add("Open", null, (s, ev) => System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.Activate();
            }));
            menu.Items.Add("Exit", null, (s, ev) =>
            {
                _trayIcon.Visible = false;
                System.Windows.Application.Current.Shutdown(); // from System.Windows
            });
            _trayIcon.ContextMenuStrip = menu;

            _clipboardService = new ClipboardService();
            _clipboardService.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _trayIcon?.Dispose();
            base.OnExit(e);
        }
    }
}
