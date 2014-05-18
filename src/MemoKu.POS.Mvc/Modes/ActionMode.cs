using MemoKu.POS.Domain.Services;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Reporting;
using StructureMap;

namespace MemoKu.POS.Mvc.Modes
{
    public abstract class ActionMode
    {
        private readonly ShoppingCartService shoppingCartService = ObjectFactory.GetInstance<ShoppingCartService>();
        private readonly IPOSSettingRepository posSettingRepository = ObjectFactory.GetInstance<IPOSSettingRepository>();
        private IModeInformation informationView;
        public ActionMode(IModeInformation informationView)
        {
            this.informationView = informationView;
        }

        public IModeInformation GetInfomation
        {
            get { return informationView; }
        }

        protected ShoppingCartService ShoppingCartService { get { return shoppingCartService; } }
        public virtual void InitializeView() { }
        public virtual void OnKeyEscapePress() { }
        public virtual void OnKeyEnterPress(string txtInputTextBox) { }
        public virtual void OnKeyUpPress() { }
        public virtual void OnKeyDownPress() { }
        public virtual void OnKeyDeletePress() { }
        public virtual void OnKeySpacePress() { }
        public virtual void OnKeyF2Press() { }
        public virtual void OnKeyF3Press() { }
        public virtual void OnKeyF9Press() { }
    }
}
