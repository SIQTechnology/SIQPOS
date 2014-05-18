using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MemoKu.POS.Components
{
    public partial class POSGridHeader : PanelEx
    {
        const string NUMBER_TEXT = " No.  ";
        const string NAME_TEXT = " Nama Barang ";
        const string QTY_TEXT = " Qty  ";
        const string PRICE_TEXT = " Harga  ";
        const string AMOUNT_TEXT = " Total  ";

        const string NUMBER_NAME = "numberLabel";
        const string NAME_NAME = "nameLabel";
        const string QTY_NAME = "qtyLabel";
        const string PRICE_NAME = "priceLabel";
        const string AMOUNT_NAME = "amountLabel";

        const int FONT_SIZE = 10;
        const string FONT_NAME = "Tahoma";
        readonly Color FONT_COLOR = Color.White;

        public POSGridHeader()
        {
            SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            CreateColumnHeader();
            ArrangeColumnHeader();
            SetStyle();
            this.Resize += new EventHandler(POSGridColumnHeader_Resize);
        }

        void POSGridColumnHeader_Resize(object sender, EventArgs e)
        {
            ArrangeColumnHeader();
        }

        private void ArrangeColumnHeader()
        {
            foreach (Control ctrl in Controls)
            {
                switch (ctrl.Name)
                {
                    case NAME_NAME:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.NAME * (this.Width - ColumnWidth.NUMBER)));
                        break;
                    case QTY_NAME:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.QTY * (this.Width - ColumnWidth.NUMBER)));
                        break;
                    case PRICE_NAME:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.PRICE * (this.Width - ColumnWidth.NUMBER)));
                        break;
                    case AMOUNT_NAME:
                        ctrl.Width = Convert.ToInt32(Math.Floor(ColumnWidth.AMOUNT * (this.Width - ColumnWidth.NUMBER)));
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetStyle()
        {
            this.Style.GradientAngle = 90;
            this.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.Style.CornerDiameter = 3;
            this.Style.BorderWidth = 1;
            this.Style.Border = eBorderType.None;
            this.Style.BorderSide = eBorderSide.None;
            this.Margin = new System.Windows.Forms.Padding(0);
        }

        private void CreateColumnHeader()
        {
            Label numberLabel = CreateNumberColumnHeader();
            Label nameLabel = CreateNameColumnHeader();
            Label qtyLabel = CreateQtyColumnHeader();
            Label priceLabel = CreatePriceColumnHeader();
            Label amountLabel = CreateAmountColumnHeader();

            Controls.Add(amountLabel);
            Controls.Add(priceLabel);
            Controls.Add(qtyLabel);
            Controls.Add(nameLabel);
            Controls.Add(numberLabel);

            ArrangeColumnHeader();
        }
        private Label CreateLabel(string name, string text)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.AutoSize = false;
            label.Dock = System.Windows.Forms.DockStyle.Left;
            label.Font = new System.Drawing.Font(FONT_NAME, FONT_SIZE, System.Drawing.FontStyle.Regular);
            label.BorderStyle = BorderStyle.None;
            label.ForeColor = FONT_COLOR;
            return label;
        }
        private Label CreateNumberColumnHeader()
        {
            Label numberLabel = CreateLabel(NUMBER_NAME, NUMBER_TEXT);
            numberLabel.TextAlign = ContentAlignment.MiddleCenter;
            numberLabel.Width = 50;
            return numberLabel;
        }

        private Label CreateNameColumnHeader()
        {
            Label nameLabel = CreateLabel(NAME_NAME, NAME_TEXT);
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;
            return nameLabel;
        }

        private Label CreateQtyColumnHeader()
        {
            Label qtyLabel = CreateLabel(QTY_NAME, QTY_TEXT);
            qtyLabel.TextAlign = ContentAlignment.MiddleRight;
            return qtyLabel;
        }

        private Label CreatePriceColumnHeader()
        {
            Label priceLabel = CreateLabel(PRICE_NAME, PRICE_TEXT);
            priceLabel.TextAlign = ContentAlignment.MiddleRight;
            return priceLabel;
        }

        private Label CreateAmountColumnHeader()
        {
            Label amountLabel = CreateLabel(AMOUNT_NAME, AMOUNT_TEXT);
            amountLabel.TextAlign = ContentAlignment.MiddleRight;
            return amountLabel;
        }

        private Label FindQtyLabel()
        {
            Control[] qtyLabels = Controls.Find(QTY_NAME, true);
            return qtyLabels.Length == 0 ? null : (Label)qtyLabels[0];
        }
        private Label FindPriceLabel()
        {
            Control[] priceLabels = Controls.Find(PRICE_NAME, true);
            return priceLabels.Length == 0 ? null : (Label)priceLabels[0];
        }
        private Label FindAmountLabel()
        {
            Control[] amountLabels = Controls.Find(AMOUNT_NAME, true);
            return amountLabels.Length == 0 ? null : (Label)amountLabels[0];
        }

        public void PadRight(int padsize)
        {
            PadRightQtyLabel(padsize);
            PadRightPriceLabel(padsize);
            PadRightAmountLabel(padsize);
        }

        private void PadRightQtyLabel(int padsize)
        {
            Label qtyLabel = FindQtyLabel();
            if (qtyLabel != null)
                qtyLabel.Padding = new System.Windows.Forms.Padding(
                    qtyLabel.Padding.Left,
                    qtyLabel.Padding.Top,
                    padsize - 5,
                    qtyLabel.Padding.Bottom);
        }
        private void PadRightPriceLabel(int padsize)
        {
            Label priceLabel = FindPriceLabel();
            if (priceLabel != null)
                priceLabel.Padding = new System.Windows.Forms.Padding(
                    priceLabel.Padding.Left,
                    priceLabel.Padding.Top,
                    padsize - 5,
                    priceLabel.Padding.Bottom);
        }
        private void PadRightAmountLabel(int padsize)
        {
            Label amountLabel = FindAmountLabel();
            if (amountLabel != null)
                amountLabel.Padding = new System.Windows.Forms.Padding(
                    amountLabel.Padding.Left,
                    amountLabel.Padding.Top,
                    padsize - 3,
                    amountLabel.Padding.Bottom);
        }
    }
}
