using System;//
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MemoKu.POS.Components
{
    public partial class GridPOS : UserControl
    {
        const int SCROLLBAR_WIDTH = 18;
        int selectedIndex = 0;
        DataProperyMapper dataPropertyMapper = new DataProperyMapper();
        IPOSGridItemStyle gridItemStyle = new SimplePOSGridItemStyle(new DataProperyMapper());

        public GridPOS()
        {
            InitializeComponent();
        }

        public void SetTotalItems(double qty, double total)
        {
            posGridFooter.UpdateFooter(totalItems, qty, total);
        }

        private int totalItems
        {
            get { return this.itemPanel.Controls.Count; }
        }

        public int ItemPanelWidth
        {
            get { return itemPanel.Width; }
        }

        public int ItemPanelWidthOffset
        {
            get
            {
                int result = itemPanel.Margin.Left + itemPanel.Margin.Right + itemPanel.Padding.Left + itemPanel.Padding.Right;

                if (itemPanel.VerticalScroll.Visible)
                    result += SCROLLBAR_WIDTH;
                return result;
            }
        }

        public int Count()
        {
            return this.itemPanel.Controls.Count;
        }

        public void AddOrUpdateItem(object item)
        {
            POSGridItem gridItem = FindItem(item);
            if (gridItem == null)
                CreateNewItem(item);
            else
            {
                gridItem.SetDataSource(item);
                BringUpdatedItemToTopIfUpdatedItemNotEqualToSelectedItem(item, gridItem);
            }
        }

        public void DeleteSelectedItem()
        {
            if (this.itemPanel.Controls.Count == 0) return;
            POSGridItem item = (POSGridItem)itemPanel.Controls[selectedIndex];
            itemPanel.Controls.Remove(item);
            if (itemPanel.Controls.Count == 0) return;
            if (itemPanel.Controls.Count == selectedIndex)
                selectedIndex--;
            item = (POSGridItem)itemPanel.Controls[selectedIndex];
            item.SetSelectionStyle();
            Reindex();
            //ItemDeleted();
        }

        private void CreateNewItem(object item)
        {
            SetDefaultStyle();

            POSGridItem gridItem = POSGridItem.Create(this).
                SetDataPropertyMapper(this.dataPropertyMapper).
                SetGridItemStyle(this.gridItemStyle).
                SetDataSource(item);

            this.itemPanel.Controls.Add(gridItem);
            SortItems();
            SetSelectionStyle();
            this.itemPanel.VerticalScroll.Value = 0;
            ItemAdded();
        }

        private void BringUpdatedItemToTopIfUpdatedItemNotEqualToSelectedItem(object item, POSGridItem updatedGridItem)
        {
            if (!GetSelectedItemRowDataSource().Equals(item))
            {
                SetDefaultStyle();
                this.itemPanel.Controls.SetChildIndex(updatedGridItem, 0);
                this.selectedIndex = 0;
                SetSelectionStyle();
                Reindex();
            }
        }

        public Guid GetSelectedItemRowDataSource()
        {
            return Guid.Empty;//GetSelectedItem().GetRowDataSource();
        }

        public POSGridItem GetSelectedItem()
        {
            if (itemPanel.Controls.Count == 0) return null;

            POSGridItem selectedItem = (POSGridItem)itemPanel.Controls[selectedIndex];
            return selectedItem;
        }

        public void MoveNextItem()
        {
            if (ReachBottom()) return;
            SetDefaultStyle();
            selectedIndex++;
            SetSelectionStyle();
            scrollDown();
        }

        public void MovePreviousItem()
        {
            if (ReachTop())
                return;
            SetDefaultStyle();
            selectedIndex--;
            SetSelectionStyle();
            scrollUp();
        }

        public void MoveSelectedItemToTop()
        {
            POSGridItem selectedItem = GetSelectedItem();
            if (selectedItem == null || selectedIndex == 0) return;
            SetDefaultStyle();
            itemPanel.Controls.SetChildIndex(selectedItem, 0);
            this.selectedIndex = 0;
            this.itemPanel.VerticalScroll.Value = 0;
            SetSelectionStyle();
            Reindex();
        }

        public void Clear()
        {
            itemPanel.Controls.Clear();
        }

        private void Reindex()
        {
            int itemCount = itemPanel.Controls.Count;
            foreach (POSGridItem item in itemPanel.Controls)
            {
                item.SetNumber(itemCount--);
            }
        }

        private void SortItems()
        {
            int itemCount = this.itemPanel.Controls.Count;
            this.itemPanel.Controls.SetChildIndex(itemPanel.Controls[itemCount - 1], 0);
            this.selectedIndex = 0;
        }

        private void SetSelectionStyle()
        {
            POSGridItem item = (POSGridItem)this.itemPanel.Controls[selectedIndex];
            item.SetSelectionStyle();
        }

        private void SetDefaultStyle()
        {
            if (this.itemPanel.Controls.Count > 0)
            {
                POSGridItem item = (POSGridItem)this.itemPanel.Controls[selectedIndex];
                item.SetDefaultStyle();
            }
        }

        private POSGridItem FindItem(object item)
        {
            PropertyInfo idProp = item.GetType().GetProperty(dataPropertyMapper.Id);
            if (idProp == null) return null;
            string id = idProp.GetGetMethod().Invoke(item, null).ToString();
            Control[] itemFounds = Controls.Find(id, true);
            return itemFounds.Length == 0 ? null : (POSGridItem)itemFounds[0];
        }

        private void ItemAdded()
        {
            PadRightHeader();
            PadRightFooter();
        }

        private void PadRightHeader()
        {
            posGridHeader.PadRight(itemPanel.VerticalScroll.Visible ? SCROLLBAR_WIDTH : 0);
        }

        private void PadRightFooter()
        {
            posGridFooter.PadRight(itemPanel.VerticalScroll.Visible ? SCROLLBAR_WIDTH : 0);
        }

        private bool ReachBottom()
        {
            return selectedIndex == itemPanel.Controls.Count - 1;
        }

        private void scrollDown()
        {
            if (itemPanel.Controls.Count == 0) return;
            itemPanel.ScrollControlIntoView(itemPanel.Controls[selectedIndex]);
        }

        private bool ReachTop()
        {
            return selectedIndex == 0;
        }

        private void scrollUp()
        {
            if (itemPanel.Controls.Count == 0) return;
            itemPanel.ScrollControlIntoView(itemPanel.Controls[selectedIndex]);
        }
    }
}
