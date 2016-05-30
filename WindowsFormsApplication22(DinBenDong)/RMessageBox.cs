using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication22_DinBenDong_
{
    class RMessageBox 
    {        
        public static DialogResult ShowDialog(string text, string caption)
        {
            DialogResult result = new DialogResult();
            Form prompt = new Form();
            prompt.BackColor = System.Drawing.SystemColors.Menu;
            prompt.ClientSize = new System.Drawing.Size(368, 194);
            prompt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            prompt.Margin = new System.Windows.Forms.Padding(5);
            prompt.StartPosition = FormStartPosition.CenterParent;
            prompt.ShowIcon = false;
            prompt.ResumeLayout(false);

            Label captionLabel = new Label();
            captionLabel.BackColor = System.Drawing.Color.Green;
            captionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            captionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            captionLabel.Location = new System.Drawing.Point(0, 0);
            captionLabel.Size = new System.Drawing.Size(369, 30);
            captionLabel.TabIndex = 0;
            captionLabel.Text = caption;
            captionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Button btnX = new Button();
            btnX.BackColor = System.Drawing.Color.Green;
            btnX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnX.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnX.Font = new System.Drawing.Font("微軟正黑體", 16F);
            btnX.Location = new System.Drawing.Point(332, -5);
            btnX.Margin = new System.Windows.Forms.Padding(0);
            btnX.Size = new System.Drawing.Size(38, 35);
            btnX.TabIndex = 1;
            btnX.Text = "×";
            btnX.UseVisualStyleBackColor = false;

            Label textLabel = new Label();
            textLabel.Location = new System.Drawing.Point(1, 32);
            textLabel.Name = "label2";
            textLabel.Size = new System.Drawing.Size(369, 21);
            textLabel.TabIndex = 2;
            textLabel.Text = text;
            textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Panel panel1 = new Panel();
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Location = new System.Drawing.Point(0, 28);
            panel1.Size = new System.Drawing.Size(369, 169);
            panel1.TabIndex = 4;

            panel1.ResumeLayout(false);

            Button confirmation = new Button();
            confirmation.BackColor = System.Drawing.Color.Green;
            confirmation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            confirmation.Location = new System.Drawing.Point(92, 90);
            confirmation.Size = new System.Drawing.Size(189, 37);
            confirmation.TabIndex = 3;
            confirmation.Text = "確定";
            confirmation.UseVisualStyleBackColor = false;

            Button cancel = new Button() { Text = "取消", Left = 150, Width = 95, Top = 80, Height = 40 };
            confirmation.Click += (sender, e) => { result = DialogResult.OK; prompt.Close(); };
            confirmation.BackColor = System.Drawing.Color.Green;
            confirmation.FlatStyle = FlatStyle.Flat;

            cancel.Click += (sender, e) => { result = DialogResult.Cancel; prompt.Close(); };
            confirmation.BackColor = System.Drawing.Color.Green;
            cancel.FlatStyle = FlatStyle.Flat;

            panel1.Controls.Add(textLabel);
            
            prompt.ShowInTaskbar = false;
            prompt.Controls.Add(panel1);
            prompt.Controls.Add(btnX);
            panel1.Controls.Add(confirmation);
            prompt.Controls.Add(captionLabel);
            //prompt.Controls.Add(cancel);
            prompt.ShowDialog();
            return result;
        }
    }
}
