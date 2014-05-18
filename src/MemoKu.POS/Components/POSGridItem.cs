using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MemoKu.POS.Components
{
    public partial class POSGridItem : PanelEx
    {
        #region Subitem label
        const string NUMBER_LABEL = "numberLabel";
        const string NAME_LABEL = "nameLabel";
        const string NAME_PANEL = "namePanel";
        const string AMOUNT_PANEL = "amountPanel";
        const string QTY_LABEL = "qtyLabel";
        const string PRICE_LABEL = "priceLabel";
        const string AMOUNT_LABEL = "amountLabel";
        const string NAME_DISCOUNT_NOTE = "nameDiscountNote";
        const string AMOUNT_DISCOUNT_NOTE = "amountDiscountNote";
        const string MULTI_UNIT_NOTE_LABEL = "multiUnitNote";
        const string PACKAGE_NOTE_LABEL = "packageNote";
        const string CARGO_NOTE_LABEL = "cargoNote";
        const string NAME_SUB_ITEM_PREFIX = "nameSubItem";
        const string AMOUNT_SUB_ITEM_PREFIX = "amountSubItem";
        #endregion

        #region Grid formating

        #region Color

        readonly Color SELECTION_START_COLOR = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(79)))), ((int)(((byte)(84)))));
        readonly Color SELECTION_END_COLOR = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
        readonly Color DEFAULT_START_COLOR = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(79)))), ((int)(((byte)(84)))));
        readonly Color DEFAULT_END_COLOR = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
        #endregion

        #region Font
        const string FONT_NAME = "Tahoma";
        const int FONT_SIZE = 10;
        const int BIG_FONT_SIZE = 14;
        #endregion

        #region Margin & padding
        const int ITEM_HEIGHT = 20;
        int SUB_ITEM_HEIGHT = 0;
        const int SELECTION_NAME_LABEL_HEIGHT = 35;
        const int SELECTION_AMOUNT_LABEL_HEIGHT = 35;
        const int DEFAULT_NAME_LABEL_HEIGHT = 27;
        const int DEFAULT_AMOUNT_LABEL_HEIGHT = 23;
        const int SELECTION_HEIGHT_ADD = 10;
        const int RIGHT_ITEM_PADING = 5;
        readonly System.Windows.Forms.Padding DEFAULT_PADDING = new System.Windows.Forms.Padding(0, 6, 0, 0);
        readonly System.Windows.Forms.Padding SELECTION_PADDING = new System.Windows.Forms.Padding(0, 10, 0, 0);
        readonly System.Windows.Forms.Padding DEFAULT_ITEM_LABEL_PADDING = new System.Windows.Forms.Padding(0, 0, 0, 0);
        #endregion

        #endregion

        GridPOS grid;
        Object rowDataSource = null;
        DataProperyMapper dataPropMapper = new DataProperyMapper();
        IPOSGridItemStyle style = new SimplePOSGridItemStyle(new DataProperyMapper());

        private POSGridItem()
        {
            SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
        }

        #region Public access
        public POSGridItem(GridPOS grid)
            : this()
        {
            this.grid = grid;
            InitItem();
        }
        public POSGridItem SetDataPropertyMapper(DataProperyMapper dataPropMapper)
        {
            this.dataPropMapper = dataPropMapper;
            return this;
        }
        public POSGridItem SetGridItemStyle(IPOSGridItemStyle style)
        {
            this.style = style;
            return this;
        }
        public POSGridItem SetDataSource(Object dataSource)
        {
            this.rowDataSource = dataSource;
            this.style.SetDataSource(dataSource);
            ReadIDFromRowDataSource();
            ReadNameFromRowDataSource();
            ReadQtyFromRowDataSource();
            ReadPriceFromRowDataSource();
            ReadAmountFromRowDataSource();
            ReadDiscountNoteFromRowDataSource();
            SetMultiUnitNote();
            //SetPackageNote();
            //SetCargoNote();
            return this;
        }
        public void SetDefaultStyle()
        {
            this.Style.BackColor1.Color = DEFAULT_START_COLOR;
            this.Style.BackColor2.Color = DEFAULT_END_COLOR;
            this.Style.BorderWidth = 1;
            this.Style.CornerDiameter = 3;
            this.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.Padding = DEFAULT_PADDING;

            foreach (Control ctrl in Controls)
                ctrl.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);

            Label amountDiscNoteLabel = FindAmountDiscountNoteLabel();
            if (amountDiscNoteLabel != null)
                amountDiscNoteLabel.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);

            Label nameLabel = FindNameLabel();
            if (nameLabel != null)
            {
                nameLabel.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);
                FindNameLabel().Height = DEFAULT_NAME_LABEL_HEIGHT;
            }

            Label amountLabel = FindAmountLabel();
            if (amountLabel != null)
            {
                amountLabel.Font = new Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);
                FindAmountLabel().Height = DEFAULT_AMOUNT_LABEL_HEIGHT;
            }
            this.Height = ITEM_HEIGHT + SUB_ITEM_HEIGHT;
        }
        public void SetSelectionStyle()
        {
            this.Style.BackColor1.Color = SELECTION_START_COLOR;
            this.Style.BackColor2.Color = SELECTION_END_COLOR;
            this.Style.BorderWidth = 1;
            this.Style.CornerDiameter = 3;
            this.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(60)))));
            this.CanvasColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.Padding = SELECTION_PADDING;

            foreach (Control ctrl in Controls)
                ctrl.Font = new Font(FONT_NAME, BIG_FONT_SIZE, FontStyle.Bold);

            Label amountDiscNoteLabel = FindAmountDiscountNoteLabel();
            if (amountDiscNoteLabel != null)
                amountDiscNoteLabel.Font = new Font(FONT_NAME, BIG_FONT_SIZE - 2, FontStyle.Bold);

            Label nameLabel = FindNameLabel();
            if (nameLabel != null)
            {
                nameLabel.Font = new Font(FONT_NAME, BIG_FONT_SIZE, FontStyle.Bold);
                nameLabel.Height = SELECTION_NAME_LABEL_HEIGHT;
            }

            Label amountLabel = FindAmountLabel();
            if (amountLabel != null)
            {
                amountLabel.Font = new Font(FONT_NAME, BIG_FONT_SIZE, FontStyle.Bold);
                amountLabel.Height = SELECTION_AMOUNT_LABEL_HEIGHT;
            }

            this.Height = ITEM_HEIGHT + SUB_ITEM_HEIGHT + SELECTION_HEIGHT_ADD;
        }
        public Object GetRowDataSource()
        {
            return rowDataSource;
        }
        public void ResizeItemWidth()
        {
            this.Width = ItemWidth;
            foreach (Control ctrl in Controls)
            {
                switch (ctrl.Name)
                {
                    case NAME_PANEL:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.NAME * (ItemWidth - ColumnWidth.NUMBER)));
                        break;
                    case QTY_LABEL:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.QTY * (ItemWidth - ColumnWidth.NUMBER)));
                        break;
                    case PRICE_LABEL:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.PRICE * (ItemWidth - ColumnWidth.NUMBER)));
                        break;
                    case AMOUNT_PANEL:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.AMOUNT * (ItemWidth - ColumnWidth.NUMBER)));
                        break;
                    default:
                        break;
                }
            }
        }
        public void SetNumber(int number)
        {
            Label numberLabel = FindNumberLabel();
            if (numberLabel != null)
                numberLabel.Text = number.ToString();
        }

        public static POSGridItem Create(GridPOS grid)
        {
            return new POSGridItem(grid);
        }

        #endregion

        #region Private members
        private void InitItem()
        {
            SetLayout();
            CreateAmountLabel();
            CreatePriceLabel();
            CreateQtyLabel();
            CreateNameLabel();
            CreateNumberLabel();
        }
        private void SetLayout()
        {
            SetMargin();
            SetWidthAndHeight();
            SetStyle();
        }
        private void SetMargin()
        {
            this.Padding = DEFAULT_PADDING;
            this.Margin = new System.Windows.Forms.Padding(1);
        }
        private void SetWidthAndHeight()
        {
            this.Width = ItemWidth;
            this.Height = ITEM_HEIGHT;
        }
        private void SetStyle()
        {
            this.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.Style.BackColor1.Color = DEFAULT_START_COLOR;
            this.Style.BackColor2.Color = DEFAULT_END_COLOR;
            this.Style.GradientAngle = 90;
            this.Style.Border = DevComponents.DotNetBar.eBorderType.Sunken;
            this.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Style.CornerDiameter = 5;
        }
        private int ItemWidth
        {
            get
            {
                return grid.ItemPanelWidth - grid.ItemPanelWidthOffset - this.Margin.Left - this.Margin.Right;
            }
        }
        private bool AmountPanelOverflow()
        {
            Panel namePanel = FindNamePanel();
            Panel amountPanel = FindAmountPanel();
            return amountPanel.Controls.Count > namePanel.Controls.Count;
        }
        private bool NamePanelOverflow()
        {
            Panel namePanel = FindNamePanel();
            Panel amountPanel = FindAmountPanel();
            return namePanel.Controls.Count > amountPanel.Controls.Count;
        }
        private void ReadIDFromRowDataSource()
        {
            PropertyInfo idProp = rowDataSource.GetType().GetProperty(dataPropMapper.Id);
            if (idProp != null)
                base.Name = idProp.GetGetMethod().Invoke(rowDataSource, null).ToString();
        }
        private void ReadAmountFromRowDataSource()
        {
            Label amountLabel = FindAmountLabel();
            if (amountLabel == null) return;
            amountLabel.Text = style.GetAmount();
        }
        private void ReadPriceFromRowDataSource()
        {
            Label priceLabel = FindPriceLabel();
            if (priceLabel == null) return;
            priceLabel.Text = style.GetPrice();
        }
        private void ReadQtyFromRowDataSource()
        {
            Label qtyLabel = FindQtyLabel();
            if (qtyLabel == null) return;
            qtyLabel.Text = style.GetQty();
        }
        private void ReadNameFromRowDataSource()
        {
            PropertyInfo nameProp = rowDataSource.GetType().GetProperty(dataPropMapper.Name);
            PropertyInfo partCodeProp = rowDataSource.GetType().GetProperty(dataPropMapper.PartCode);
            if (nameProp == null) return;
            Label nameLabel = FindNameLabel();
            if (nameLabel != null)
            {
                nameLabel.Text = nameProp.GetGetMethod().Invoke(rowDataSource, null).ToString();
                //nameLabel.Text = nameLabel.Text + " (" + partCodeProp.GetGetMethod().Invoke(rowDataSource, null).ToString() + ")";
            }
        }
        private void ReadDiscountNoteFromRowDataSource()
        {
            if (style.NoDiscount())
                RemoveDiscountNote();
            else
            {
                SetNameDiscountNote(style.GetNameDiscountNote());
                SetAmountDiscountNote(style.GetAmountDiscountNote());
            }
        }
        #endregion

        #region State mutator
        private void AddAmountSubItem(Label amountSubItemLabel)
        {
            Panel amountPanel = FindAmountPanel();
            if (amountPanel == null) return;

            amountPanel.Controls.Add(amountSubItemLabel);
            amountSubItemLabel.BringToFront();

            if (AmountPanelOverflow())
            {
                this.Height += amountSubItemLabel.Height;
                amountPanel.Height += amountSubItemLabel.Height;
                SUB_ITEM_HEIGHT += amountSubItemLabel.Height;
            }
        }
        private void AddNameSubItem(Label nameSubItemLabel)
        {
            Panel namePanel = FindNamePanel();
            if (namePanel == null) return;

            namePanel.Controls.Add(nameSubItemLabel);
            nameSubItemLabel.BringToFront();

            if (NamePanelOverflow())
            {
                this.Height += nameSubItemLabel.Height;
                namePanel.Height += nameSubItemLabel.Height;
                SUB_ITEM_HEIGHT += nameSubItemLabel.Height;
            }
        }
        private void AddNameSubItem(string subItemContent)
        {
            AddNameSubItem(CreateNameSubItemLabel(subItemContent));
        }
        private void AddAmountSubItem(string subItemContent)
        {
            AddAmountSubItem(CreateAmountSubItemLabel(subItemContent));
        }
        private void AddNameSubItemWithColor(Color color, string subItemContent)
        {
            Label nameSubItemLabel = CreateNameSubItemLabel(subItemContent);
            nameSubItemLabel.ForeColor = color;
            AddNameSubItem(nameSubItemLabel);
        }
        private void AddAmountSubItemWithColor(Color color, string subItemContent)
        {
            Label amountSubItemLabel = CreateAmountSubItemLabel(subItemContent);
            amountSubItemLabel.ForeColor = color;
            AddAmountSubItem(amountSubItemLabel);
        }
        private void SetAmountDiscountNote(string discountAmountNote)
        {
            Label amountDiscNoteLabel = FindAmountDiscountNoteLabel();
            if (amountDiscNoteLabel == null)
            {
                amountDiscNoteLabel = CreateAmountSubItemLabel("");
                amountDiscNoteLabel.Name = AMOUNT_DISCOUNT_NOTE;
                amountDiscNoteLabel.ForeColor = Color.Red;
                amountDiscNoteLabel.Font = new Font(FONT_NAME, BIG_FONT_SIZE - 2, FontStyle.Bold);
                amountDiscNoteLabel.Padding = new System.Windows.Forms.Padding(
                    DEFAULT_ITEM_LABEL_PADDING.Left,
                    DEFAULT_ITEM_LABEL_PADDING.Top,
                    RIGHT_ITEM_PADING,
                    DEFAULT_ITEM_LABEL_PADDING.Bottom);
                AddAmountSubItem(amountDiscNoteLabel);
            }
            amountDiscNoteLabel.Text = discountAmountNote;
        }
        private void SetNameDiscountNote(string discountNote)
        {
            Label nameDiscNoteLabel = FindNameDiscountNoteLabel();
            if (nameDiscNoteLabel == null)
            {
                nameDiscNoteLabel = CreateNameSubItemLabel("");
                nameDiscNoteLabel.Name = NAME_DISCOUNT_NOTE;
                nameDiscNoteLabel.ForeColor = Color.Red;
                AddNameSubItem(nameDiscNoteLabel);
            }
            nameDiscNoteLabel.Text = discountNote;
            Panel namePanel = FindNamePanel();
            EnsureDiscountNoteOnTopOfMultiUnitNote();
        }
        private void RemoveDiscountNote()
        {
            Label nameDiscountNoteLabel = FindNameDiscountNoteLabel();
            if (nameDiscountNoteLabel != null)
                FindNamePanel().Controls.Remove(nameDiscountNoteLabel);

            Label amountDiscountNoteLabel = FindAmountDiscountNoteLabel();
            if (amountDiscountNoteLabel != null)
                FindAmountPanel().Controls.Remove(amountDiscountNoteLabel);

            if ((nameDiscountNoteLabel != null) || (amountDiscountNoteLabel != null))
            {
                SUB_ITEM_HEIGHT -= nameDiscountNoteLabel.Height;
                this.Height -= nameDiscountNoteLabel.Height;
            }
        }
        private void RemoveMultiUnitLabels(string[] multiUnitNotes)
        {
            Panel namePanel = FindNamePanel();
            List<Control> multiUnitLabelToRemove = new List<Control>();
            foreach (Control ctrl in namePanel.Controls)
            {
                if (ctrl.Name.Contains(MULTI_UNIT_NOTE_LABEL))
                    multiUnitLabelToRemove.Add(ctrl);
            }
            if (multiUnitNotes.Length < multiUnitLabelToRemove.Count)
            {
                foreach (Control ctrl in multiUnitLabelToRemove)
                {
                    namePanel.Controls.Remove(ctrl);
                    this.Height -= ctrl.Height;
                    SUB_ITEM_HEIGHT -= ctrl.Height;
                }
            }
        }
        public void SetMultiUnitNote()
        {
            string[] multiUnitNotes = style.GetMultiUnitNotes();
            RemoveMultiUnitLabels(multiUnitNotes);
            for (int i = 1; i <= multiUnitNotes.Length; i++)
            {
                string labelName = string.Format("{0}{1}", MULTI_UNIT_NOTE_LABEL, i.ToString());
                Label multiUnitLabel = FindMultiUnitNoteLabel(labelName);
                if (multiUnitLabel == null)
                {
                    multiUnitLabel = CreateNameSubItemLabel("");
                    multiUnitLabel.Name = labelName;
                    multiUnitLabel.ForeColor = Color.Blue;
                    AddNameSubItem(multiUnitLabel);
                }
                multiUnitLabel.Text = multiUnitNotes[i - 1];
            }
            EnsureDiscountNoteOnTopOfMultiUnitNote();
        }
        public void SetPackageNote()
        {
            string[] packageNotes = style.GetPackageNotes();
            RemovePackageNoteLabels(packageNotes);
            for (int i = 1; i <= packageNotes.Length; i++)
            {
                string labelName = string.Format("{0}{1}", PACKAGE_NOTE_LABEL, i.ToString());
                Label packageNoteLabel = FindPackageNoteLabel(labelName);
                if (packageNoteLabel == null)
                {
                    packageNoteLabel = CreateNameSubItemLabel("");
                    packageNoteLabel.Name = labelName;
                    packageNoteLabel.ForeColor = Color.Green;
                    AddNameSubItem(packageNoteLabel);
                }
                packageNoteLabel.Text = packageNotes[i - 1];
            }
            EnsureDiscountNoteOnTopOfMultiUnitNote();
        }
        private void RemovePackageNoteLabels(string[] packageNotes)
        {
            Panel namePanel = FindNamePanel();
            List<Control> packageNoteLabelToRemove = namePanel.Controls.Cast<Control>().
                Where(ctrl => ctrl.Name.Contains(PACKAGE_NOTE_LABEL)).ToList();
            if (packageNotes.Length < packageNoteLabelToRemove.Count)
            {
                foreach (Control ctrl in packageNoteLabelToRemove)
                {
                    namePanel.Controls.Remove(ctrl);
                    this.Height -= ctrl.Height;
                    SUB_ITEM_HEIGHT -= ctrl.Height;
                }
            }
        }
        private void EnsureDiscountNoteOnTopOfMultiUnitNote()
        {
            Panel namePanel = FindNamePanel();
            Label nameLabel = FindNameLabel();
            Label nameDiscNoteLabel = FindNameDiscountNoteLabel();
            if (nameLabel != null)
                namePanel.Controls.SetChildIndex(nameLabel, namePanel.Controls.Count - 1);
            if (nameDiscNoteLabel != null)
                namePanel.Controls.SetChildIndex(nameDiscNoteLabel, namePanel.Controls.Count - 2);
        }
        #endregion

        #region Sub item finder
        private Label FindNumberLabel()
        {
            Control[] numberLabels = Controls.Find(NUMBER_LABEL, true);
            return numberLabels.Length == 0 ? null : (Label)numberLabels[0];
        }
        private Panel FindNamePanel()
        {
            Control[] childControls = Controls.Find("namePanel", false);
            return childControls.Length == 0 ? null : (Panel)childControls[0];
        }
        private Label FindNameDiscountNoteLabel()
        {
            Control[] nameDiscNotes = Controls.Find(NAME_DISCOUNT_NOTE, true);
            return nameDiscNotes.Length == 0 ? null : (Label)nameDiscNotes[0];
        }
        private Label FindAmountDiscountNoteLabel()
        {
            Control[] amountDiscNotes = Controls.Find(AMOUNT_DISCOUNT_NOTE, true);
            return amountDiscNotes.Length == 0 ? null : (Label)amountDiscNotes[0];
        }
        private Label FindMultiUnitNoteLabel(string labelName)
        {
            Panel namePanel = FindNamePanel();
            Control[] multiUnitLabels = namePanel.Controls.Find(labelName, false);
            return multiUnitLabels.Length == 0 ? null : (Label)multiUnitLabels[0];
        }
        private Label FindPackageNoteLabel(string labelName)
        {
            Panel namePanel = FindNamePanel();
            Control[] packageNoteLabels = namePanel.Controls.Find(labelName, false);
            return packageNoteLabels.Length == 0 ? null : (Label)packageNoteLabels[0];
        }
        private Label FindNameLabel()
        {
            Control[] nameLabels = Controls.Find(NAME_LABEL, true);
            return nameLabels.Length == 0 ? null : (Label)nameLabels[0];
        }
        private Label FindQtyLabel()
        {
            Control[] qtyLabels = Controls.Find(QTY_LABEL, true);
            return qtyLabels.Length == 0 ? null : (Label)qtyLabels[0];
        }
        private Label FindPriceLabel()
        {
            Control[] priceLabels = Controls.Find(PRICE_LABEL, true);
            return priceLabels.Length == 0 ? null : (Label)priceLabels[0];
        }
        private Label FindAmountLabel()
        {
            Control[] amountLabels = Controls.Find(AMOUNT_LABEL, true);
            return amountLabels.Length == 0 ? null : (Label)amountLabels[0];
        }
        private Panel FindAmountPanel()
        {
            Control[] amountPanels = Controls.Find(AMOUNT_PANEL, true);
            return amountPanels.Length == 0 ? null : (Panel)amountPanels[0];
        }
        #endregion

        #region Sub item factory
        private void CreateNumberLabel()
        {
            Label numberLabel = CreateItemLabel(NUMBER_LABEL, (grid.Count() + 1).ToString(), ContentAlignment.TopCenter);
            numberLabel.Width = ColumnWidth.NUMBER;
            this.Controls.Add(numberLabel);
        }
        private void CreateNameLabel()
        {
            Label nameLabel = CreateItemLabel(NAME_LABEL, "", ContentAlignment.TopLeft);
            nameLabel.AutoSize = false;
            nameLabel.Dock = DockStyle.Top;
            nameLabel.BorderStyle = BorderStyle.None;
            Panel namePanel = CreateNamePanel();

            namePanel.Controls.Add(nameLabel);
            this.Controls.Add(namePanel);
        }
        private POSPanel CreateNamePanel()
        {
            POSPanel namePanel = new POSPanel();
            namePanel.Name = NAME_PANEL;
            namePanel.Dock = DockStyle.Left;
            namePanel.BackColor = Color.Transparent;
            namePanel.Width = Convert.ToInt32(Math.Floor(ColumnWidth.NAME * (ItemWidth - ColumnWidth.NUMBER)));
            return namePanel;
        }
        private void CreateQtyLabel()
        {
            Label qtyLabel = CreateItemLabel("qtyLabel", "0", ContentAlignment.TopRight);
            qtyLabel.Width = Convert.ToInt32(Math.Floor(ColumnWidth.QTY * (ItemWidth - ColumnWidth.NUMBER)));
            this.Controls.Add(qtyLabel);
        }
        private void CreatePriceLabel()
        {
            Label priceLabel = CreateItemLabel(PRICE_LABEL, "0", ContentAlignment.TopRight);
            priceLabel.Width = Convert.ToInt32(Math.Floor(ColumnWidth.PRICE * (ItemWidth - ColumnWidth.NUMBER)));
            this.Controls.Add(priceLabel);
        }
        private void CreateAmountLabel()
        {
            Label amountLabel = CreateItemLabel(AMOUNT_LABEL, "0", ContentAlignment.TopRight);
            amountLabel.AutoSize = false;
            amountLabel.Dock = DockStyle.Top;
            amountLabel.Padding = new System.Windows.Forms.Padding(
                DEFAULT_PADDING.Left,
                DEFAULT_PADDING.Top,
                RIGHT_ITEM_PADING,
                DEFAULT_PADDING.Bottom);
            amountLabel.BorderStyle = BorderStyle.None;

            Panel amountPanel = CreateAmountPanel();
            amountPanel.Controls.Add(amountLabel);
            this.Controls.Add(amountPanel);
        }
        private POSPanel CreateAmountPanel()
        {
            POSPanel amountPanel = new POSPanel();
            amountPanel.Name = AMOUNT_PANEL;
            amountPanel.Dock = DockStyle.Left;
            amountPanel.BackColor = Color.Transparent;
            amountPanel.Width = Convert.ToInt32(Math.Floor(ColumnWidth.AMOUNT * (ItemWidth - ColumnWidth.NUMBER)));
            amountPanel.BorderStyle = BorderStyle.None;
            return amountPanel;
        }
        private Label CreateItemLabel(string name, string text, ContentAlignment alignment)
        {
            Label lbl = new Label();
            lbl.Name = name;
            lbl.Text = text;
            lbl.TextAlign = alignment;
            lbl.Dock = DockStyle.Left;
            lbl.Padding = DEFAULT_PADDING;
            lbl.Font = new Font(FONT_NAME, FONT_SIZE);
            lbl.BorderStyle = BorderStyle.None;
            lbl.ForeColor = Color.White;
            return lbl;
        }
        private int nameSubItemIndex = 0;
        private Label CreateNameSubItemLabel(string subItemContent)
        {
            Label lbl = new Label();
            lbl.Font = new Font(FONT_NAME, FONT_SIZE);
            lbl.Name = NAME_SUB_ITEM_PREFIX + (++nameSubItemIndex).ToString();
            lbl.Dock = DockStyle.Top;
            lbl.Text = subItemContent;
            lbl.BorderStyle = BorderStyle.None;
            lbl.AutoSize = false;
            lbl.Padding = DEFAULT_ITEM_LABEL_PADDING;
            return lbl;
        }
        private int amountSubItemIndex = 0;
        private Label CreateAmountSubItemLabel(string subItemContent)
        {
            Label lbl = new Label();
            lbl.Font = new Font(FONT_NAME, FONT_SIZE);
            lbl.Name = AMOUNT_SUB_ITEM_PREFIX + (++amountSubItemIndex).ToString();
            lbl.Dock = DockStyle.Top;
            lbl.Text = subItemContent;
            lbl.BorderStyle = BorderStyle.None;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleRight;
            lbl.Padding = new System.Windows.Forms.Padding(
                DEFAULT_ITEM_LABEL_PADDING.Left,
                DEFAULT_ITEM_LABEL_PADDING.Top,
                RIGHT_ITEM_PADING,
                DEFAULT_ITEM_LABEL_PADDING.Bottom);
            return lbl;
        }
        #endregion
    }
}
