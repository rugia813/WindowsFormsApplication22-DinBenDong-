using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication22_DinBenDong_
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            string result = "";
            Form prompt = new Form();
            prompt.Width = 240;
            prompt.Height = 150;
            prompt.Text = caption;
            Label lblCaption = new Label();
            lblCaption.BackColor = ColorScheme.main;
            lblCaption.Size = new System.Drawing.Size(260, 20);
            lblCaption.Text = caption;
            lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Label textLabel = new Label() { Left = 20, Top = 35, Text = text };
            textLabel.Size = new System.Drawing.Size(160, 25);
            textLabel.BackColor = ColorScheme.background;
            TextBox inputBox = new TextBox() { Left = 20, Top = 60, Width = 200 };
            inputBox.Font = new System.Drawing.Font("微軟正黑體", 16);
            Button confirmation = new Button() { Text = "Ok", Left = 20, Width = 80, Top = 105 };
            Button cancel = new Button() { Text = "cancel", Left = 140, Width = 80, Top = 105 };
            confirmation.Click += (sender, e) => { result = inputBox.Text; prompt.Close(); };
            confirmation.BackColor = ColorScheme.main;
            confirmation.FlatStyle = FlatStyle.Flat;
            cancel.Click += (sender, e) => { result = ""; prompt.Close(); };
            cancel.FlatStyle = FlatStyle.Flat;
            prompt.FormBorderStyle = FormBorderStyle.None;
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.BackgroundImage = global::WindowsFormsApplication22_DinBenDong_.Properties.Resources.bg;
            prompt.BackgroundImageLayout = ImageLayout.Stretch;
            prompt.Controls.Add(lblCaption);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return result;
        }
    }
}
