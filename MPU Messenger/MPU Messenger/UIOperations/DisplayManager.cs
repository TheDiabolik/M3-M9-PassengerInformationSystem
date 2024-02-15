using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPUMessenger
{
    internal class DisplayManager
    {
        public static void ToolStripStatusLabelInvoke(ToolStripStatusLabel toolStripAppStatus, string text)
        {
            toolStripAppStatus.ToolStripStatusInvokeAction(t =>
            {
                t.Text = text;
            });
        }

        public static void ToolStripStatusLabelInvoke(ToolStripStatusLabel toolStripAppStatus, string text, Color color)
        {
            toolStripAppStatus.ToolStripStatusInvokeAction(t =>
            {
                t.Text = text;
                t.BackColor = color;
            });
        }

        public static void TextBoxInvoke(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
                textBox.Invoke((MethodInvoker)delegate
                {
                    textBox.Text = text;
                });
            else
            {
                textBox.Text = text;
            }
        } 

        public static void RichTextBoxInvoke(RichTextBox richTextBox, string text)
        {
            if (richTextBox.InvokeRequired)
                richTextBox.Invoke((MethodInvoker)delegate
                {
                    richTextBox.AppendText(text + "\n", Color.Black);
                });
            else
            {
                richTextBox.AppendText(text + "\n", Color.Black);
            }
        }

        public static void RichTextBoxWithAppendLineInvoke(RichTextBox richTextBox, string text, Color color)
        {
            if (richTextBox.InvokeRequired)
                richTextBox.Invoke((MethodInvoker)delegate
                {
                    richTextBox.AppendText("****************************************************"+ "\n", color);
                    richTextBox.AppendText(text + "\n", color);
                    richTextBox.AppendText("****************************************************" + "\n", color);
                });
            else
            {
                richTextBox.AppendText("****************************************************"+ "\n", color);
                richTextBox.AppendText(text + "\n", color);
                richTextBox.AppendText("****************************************************" + "\n", color);
            }
        }

        public static void RichTextBoxInvoke(RichTextBox richTextBox, string infoText, Color selectionColor)
        {
            try
            {

                if (!richTextBox.IsHandleCreated || richTextBox.IsDisposed)
                    return;

                if (richTextBox.InvokeRequired)
                    richTextBox.Invoke((MethodInvoker)delegate
                    {

                        richTextBox.SelectionColor = selectionColor;
                        richTextBox.AppendText("****************************************************" + "\n");
                        richTextBox.AppendText(infoText + "\n");
                        richTextBox.AppendText("****************************************************" + "\n");

                    });
                else
                {
                    richTextBox.SelectionColor = selectionColor;
                    richTextBox.AppendText("****************************************************" + "\n");
                    richTextBox.AppendText(infoText + "\n");
                    richTextBox.AppendText("****************************************************" + "\n");
                }
            }
            catch
            {
            }
        }
        public static void PanelInvoke(Panel panel, Color backColor)
        {
            if (panel.InvokeRequired)
                panel.Invoke((MethodInvoker)delegate
                {
                    panel.BackColor = backColor;
                });
            else
            {
                panel.BackColor = backColor;
            }
        }
        public static void PictureBoxInvoke(PictureBox pictureBox, Bitmap bitmap)
        {
            if (pictureBox.InvokeRequired)
                pictureBox.Invoke((MethodInvoker)delegate
                {
                    pictureBox.Image = bitmap;
                });
            else
            {
                pictureBox.Image = bitmap;
            }
        }
        public static void SetDoubleBuffered(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}
