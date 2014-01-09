using System;
using System.Windows.Forms;

namespace ApplicationUtility
{
    public static class ControlUtility
    {
        public static void SetTextBoxText(this Control control, string textStr)
        {
            if (control == null)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<string>(control.SetTextBoxText), textStr);
            }
            else
            {
                control.Text = textStr;
            }
        }
        public static void UpdateCheckedState(this CheckBox checkBox, bool resualt)
        {
            if (checkBox == null)
            {
                return;
            }
            if (checkBox.InvokeRequired)
            {
                checkBox.Invoke(new Action<bool>(checkBox.UpdateCheckedState), resualt);
            }
            else
            {
                checkBox.Checked = resualt;
            }
        }
        public static void UpdateIncrement(this ProgressBar progressBar, int resualt)
        {
            if (progressBar == null)
            {
                return;
            }
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action<int>(progressBar.UpdateIncrement), resualt);
            }
            else
            {
                if (resualt < 0)
                {
                    resualt = progressBar.Step;
                }
                progressBar.Increment(resualt);
            }
        }

        public static void SetMaximum(this ProgressBar progressBar, int resualt)
        {
            if (progressBar == null)
            {
                return;
            }
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action<int>(progressBar.SetMaximum), resualt);
            }
            else
            {
                progressBar.Maximum = resualt;
            }
        }

        public static void SetValue(this ProgressBar progressBar, int resualt)
        {
            if (progressBar == null)
            {
                return;
            }
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action<int>(progressBar.SetValue), resualt);
            }
            else
            {
                progressBar.Value = resualt;
            }
        }

        public static void ClearTag(this Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(control.ClearTag));
            }
            else
            {
                control.Tag = null;
            }
        }
    }
}