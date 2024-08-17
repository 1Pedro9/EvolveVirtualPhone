using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PhoneVM.Model;

namespace PhoneVM.Controller
{
    internal class WindowProperties
    {

        private readonly Window _window;
        public WindowProperties(Window _w) 
        {
            this._window = _w;
        }

        public void close()
        {
            Environment.Exit(0);
        }

        public void close_window(Member member)
        {
            MainWindow main = new MainWindow();
            main.setMember(member);
            main.Show();

            _window.Close();
        }

        public void maximise()
        {
            _window.Topmost = !_window.Topmost;
        }

        public void minimise()
        {
            _window.WindowState = WindowState.Minimized;
        }
    }
}
