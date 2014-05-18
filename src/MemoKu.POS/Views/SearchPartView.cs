using System.Windows.Forms;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Views
{
    public partial class SearchPartView : Form, ISearchPartView
    {
        private static SearchPartView _instance;
        private IMainController m_ctrl;
        public SearchPartView()
        {
            InitializeComponent();
        }

        public static SearchPartView Instance
        {
            get
            {
                if (_instance.IsNull())
                    _instance = new SearchPartView();
                return _instance;
            }
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        private void SearchPartView_KeyDown(object sender, KeyEventArgs e)
        {
            m_ctrl.OnKeyDown(sender, e);
        }

        public void SetController(IMainController m_controller)
        {
            this.m_ctrl = m_controller;
        }
    }
}
