using System;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CmScreens {
    public class ShellViewModel : Conductor<IScreen>.Collection.AllActive, IShell
    {
        private readonly IWindowManager m_windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            if (windowManager == null) throw new ArgumentNullException(nameof(windowManager));
            m_windowManager = windowManager;
        }

        private string m_ticker;
        public string Ticker
        {
            get { return m_ticker; }
            set
            {
                if (value == m_ticker) return;
                m_ticker = value;
                NotifyOfPropertyChange(() => Ticker);
                CanAddScreen = !string.IsNullOrEmpty(m_ticker);
            }
        }

        private bool m_canAddScreen = false;
        public bool CanAddScreen
        {
            get { return m_canAddScreen; }
            set
            {
                if (value == m_canAddScreen) return;
                m_canAddScreen = value;
                NotifyOfPropertyChange(() => CanAddScreen);
            }
        }

        public void AddScreen()
        {
            var item = new MyScreenViewModel {Ticker = Ticker, DisplayName = $"{Ticker} Screen"};
            ActivateItem(item);
            m_windowManager.ShowWindow(item);
        }

        public void ScreenClosing(IScreen screen)
        {
            if (!IsActive)
            {
                return;
            }

            Items.Remove(screen);
        }
    }
}