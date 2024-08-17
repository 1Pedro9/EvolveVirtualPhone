using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneVM.Core;
using PhoneVM.ViewModel.MainWindow;

namespace PhoneVM.ViewModel
{
    internal class HomeViewModel : ObservableObject
    {
        private object _discord;

        public object discord
        {
            get { return _discord; }
            set { _discord = value; }
        }

        private object _calc;
        public object calc
        {
            get { return _calc; }
            set { _calc = value; }
        }

        private object _todo;
        public object todo
        {
            get { return _todo; }
            set { _todo = value; }
        }

        private object _messenger;
        public object messenger
        {
            get { return _messenger; }
            set { _messenger = value; }
        }

        public HomeViewModel() 
        {
            DiscordVM discordVM = new DiscordVM();
            discord = discordVM;
            CalculatorVM calculatorVM = new CalculatorVM();
            calc = calculatorVM;
            TodoVM todoVM = new TodoVM();
            todo = todoVM;
            MessengerViewModel messengerViewModel = new MessengerViewModel();
            messenger = messengerViewModel;
        }
    }
}
