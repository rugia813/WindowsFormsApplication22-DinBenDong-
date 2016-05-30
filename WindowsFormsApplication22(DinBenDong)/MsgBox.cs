using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication22_DinBenDong_
{
    internal partial class MsgBox : Form
    {
        int strech = 1;
        protected override void WndProc(ref Message m)  //make the form draggable
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        private void setColor()
        {
            this.BackColor = ColorScheme.main;
            panel1.BackColor = ColorScheme.background;
            btnCancel.BackColor = ColorScheme.secondary;
            btnConfirm.BackColor = ColorScheme.main;
            lblCaption.BackColor = ColorScheme.main;
            button1.BackColor = ColorScheme.main;
            button1.FlatAppearance.BorderColor = ColorScheme.main;
        }
        public MsgBox()
        {
            InitializeComponent();
        }
        public MsgBox(string text, string caption)
        {
            InitializeComponent();
            setColor();
            lblCaption.Text = caption;
            lblText.Text = text;
            DialogResult result = new DialogResult();
            this.btnConfirm.Click += (sender, e) => { result = DialogResult.OK; this.Close(); };
            btnCancel.Visible = false;

            strech = text.Split(new char[] { '\n' }).Count() * 10;
            this.Height += strech;
            btnCancel.Location = new Point(btnCancel.Location.X, btnCancel.Location.Y + strech);
            btnConfirm.Location = new Point(btnConfirm.Location.X, btnConfirm.Location.Y + strech);
            panel1.Height += strech;
            lblText.Height += strech;
        }
        public MsgBox(string text, string caption, MessageBoxButtons mbb)
        {
            InitializeComponent();
            setColor();
            lblCaption.Text = caption;
            lblText.Text = text;
            DialogResult result = new DialogResult();
            this.btnConfirm.Click += (sender, e) => { result = DialogResult.OK; this.Close(); };
            btnCancel.Click += (sender, e) => { result = DialogResult.Cancel; this.Close(); };
            if (mbb == MessageBoxButtons.OKCancel)
            {
                btnConfirm.Location = new Point(28,117);
            }
        }
    }
    public static class RmsgBox
    {
        public static DialogResult Show(string title, string description)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new MsgBox(title, description))
            {
                return form.ShowDialog();
            }
        }
        public static DialogResult Show(string title, string description, MessageBoxButtons mbb)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new MsgBox(title, description, mbb))
            {
                return form.ShowDialog();
            }
        }
    }
}
