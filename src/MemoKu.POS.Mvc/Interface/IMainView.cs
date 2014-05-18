using System;
using MemoKu.POS.Reporting.Models;

namespace MemoKu.POS.Mvc.Interface
{
    public interface IMainView
    {
        string txtInputTextBox { get; }
        void SetController(IMainController mainController);
        void LogOut();
        void FocusToInputTextBox();
        void SetInfo(IModeInformation informationView);
        void AddOrUpdateItem(Guid itemId);
        void DeleteSelectedItem();
        Guid GetItemSelected();
        void SetCompanyProfile(CompanyProfile cp);
        void FocusNextGridItem();
        void FocusPreviousGridItem();
        void FocusSelectedGridItemToTop();
        void Clear();
    }
}
