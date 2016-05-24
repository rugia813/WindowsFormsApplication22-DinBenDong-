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
            prompt.Width = 265;
            prompt.Height = 160;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 20, Top = 10, Text = text };
            TextBox inputBox = new TextBox() { Left = 20, Top = 35, Width = 200 };
            inputBox.Font = new System.Drawing.Font("微軟正黑體", 16);
            Button confirmation = new Button() { Text = "Ok", Left = 20, Width = 80, Top = 80 };
            Button cancel = new Button() { Text = "cancel", Left = 140, Width = 80, Top = 80 };
            confirmation.Click += (sender, e) => { result = inputBox.Text; prompt.Close(); };
            cancel.Click += (sender, e) => { result = ""; prompt.Close(); };
            prompt.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return result;
        }
    }
}
