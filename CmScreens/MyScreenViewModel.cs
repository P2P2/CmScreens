using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CmScreens
{
    public class MyScreenViewModel : Screen, IMyScreen
    {
        private string m_ticker;
        public string Ticker
        {
            get { return m_ticker; }
            set
            {
                if (value == m_ticker) return;
                m_ticker = value;
                NotifyOfPropertyChange(() => Ticker);
            }
        }

        public void OnClose(CancelEventArgs eventArgs)
        {
            var shell = Parent as IShell;
            shell?.ScreenClosing(this);
        }
    }
}
