using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MemoKu.POS.Components
{
    public partial class POSGridFooter : PanelEx
    {
        const int FONT_SIZE = 11;
        const string FONT_NAME = "Tahoma";
        const string TOTAL_LABEL = "totalNoteLabel";
        const string COUNTER_LABEL = "counterLabel";
        const string CHANGE_LABEL = "changelabel";

        public POSGridFooter()
        {
            SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            SetStyle();
            CreateCounteLabel();
            CreateChangeLabel();
            CreateTotalNoteLabel();
        }

        private void SetStyle()
        {
            Style.GradientAngle = 90;
            Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            Style.CornerDiameter = 3;
            Style.BorderWidth = 1;
            Style.Border = eBorderType.SingleLine;
            Style.BorderSide = eBorderSide.None;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Height = 50;
        }

        private void CreateCounteLabel()
        {
            Label counterLabel = new Label();
            counterLabel.Name = COUNTER_LABEL;
            counterLabel.Text = "Item : 0      Qty: 0";
            counterLabel.Dock = DockStyle.Left;
            counterLabel.Padding = new System.Windows.Forms.Padding(5);
            counterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            counterLabel.Font = new System.Drawing.Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);
            counterLabel.ForeColor = Color.White;
            counterLabel.AutoSize = true;
            counterLabel.BorderStyle = BorderStyle.None;
            Controls.Add(counterLabel);
        }

        private void CreateTotalNoteLabel()
        {
            Label totalNoteLabel = new Label();
            totalNoteLabel.Name = TOTAL_LABEL;
            totalNoteLabel.Text = "Total:     0";
            totalNoteLabel.Dock = DockStyle.Fill;
            totalNoteLabel.Padding = new System.Windows.Forms.Padding(5);
            totalNoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            totalNoteLabel.Font = new System.Drawing.Font(FONT_NAME, FONT_SIZE, FontStyle.Regular);
            totalNoteLabel.ForeColor = Color.White;
            Controls.Add(totalNoteLabel);
            totalNoteLabel.BringToFront();
        }

        private void CreateChangeLabel()
        {
            Label counterLabel = new Label();
            counterLabel.Name = CHANGE_LABEL;
            counterLabel.Text = "";
            counterLabel.Dock = DockStyle.Left;
            counterLabel.Padding = new System.Windows.Forms.Padding(5, 14, 5, 5);
            counterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            counterLabel.Font = new System.Drawing.Font(FONT_NAME, FONT_SIZE, FontStyle.Bold);
            counterLabel.ForeColor = Color.White;
            counterLabel.AutoSize = true;
            Controls.Add(counterLabel);
            counterLabel.BringToFront();
            counterLabel.BorderStyle = BorderStyle.None;
        }

        public void SetTotal(decimal total)
        {
            Label totalLabel = FindTotalLabel();
            if (totalLabel != null)
                totalLabel.Text = "TOTAL:     " + total.ToString("N");
        }
        public void SetTotal(string total)
        {
            Label totalLabel = FindTotalLabel();
            if (totalLabel != null)
                totalLabel.Text = "TOTAL:     " + total;
        }
        public void SetChange(string change)
        {
            Label changeLabel = FindChangeLabel();
            if (changeLabel != null)
            {
                if (change.Trim() == string.Empty)
                    changeLabel.Text = "";
                else
                    changeLabel.Text = "KEMBALI:     " + change;
            }
        }
        public void UpdateFooter(int totalItems, double qty, double total, string change = "")
        {
            Label counterLabel = FindCounterLabel();
            Label totalLabel = FindTotalLabel();
            Label changeLabel = FindChangeLabel();

            if (counterLabel != null)
                counterLabel.Text = string.Format("Item : {0}      Qty: {1}", totalItems.ToString("N0"), qty.ToString());

            if (totalLabel != null)
                totalLabel.Text = "TOTAL:     " + total.ToString("N");

            if (changeLabel != null)
            {
                if (change.Trim() == string.Empty)
                    changeLabel.Text = "";
                else
                    changeLabel.Text = "KEMBALI:     " + change;
            }
        }

        Label FindTotalLabel()
        {
            Control[] totalLabels = Controls.Find(TOTAL_LABEL, true);
            return totalLabels.Length == 0 ? null : (Label)totalLabels[0];
        }
        Label FindCounterLabel()
        {
            Control[] totalLabels = Controls.Find(COUNTER_LABEL, true);
            return totalLabels.Length == 0 ? null : (Label)totalLabels[0];
        }
        Label FindChangeLabel()
        {
            Control[] changeLabels = Controls.Find(CHANGE_LABEL, true);
            return changeLabels.Length == 0 ? null : (Label)changeLabels[0];
        }

        public void PadRight(int padsize)
        {
            Label totalLabel = FindTotalLabel();
            if (totalLabel != null)
            {
                totalLabel.Padding = new System.Windows.Forms.Padding(
                    totalLabel.Padding.Left,
                    totalLabel.Padding.Top,
                    padsize == 0 ? 5 : padsize - 3,
                    totalLabel.Padding.Bottom);
            }
        }
        public void ShowDetail(Action<Control> displayDetailSummary)
        {
            displayDetailSummary(FindTotalLabel());
        }
        public IntPtr POSGridFooterHandler
        {
            get { return this.Handle; }
        }
    }
}
