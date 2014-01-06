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
    }
}