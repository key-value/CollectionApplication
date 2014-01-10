using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISite
{
    public class LabelEventArgs : EventArgs
    {
        private string _args = string.Empty;
        public LabelEventArgs()
        {
        }
        public LabelEventArgs(string args)
        {
            _args = args;
        }
        public LabelEventArgs(string labelText, int updateType)
        {
            LabelText = labelText;
            UpdateType = updateType;
        }
        public string Args
        {
            get { return _args; }
        }

        public int UpdateType { get; set; }
        public string LabelText { get; set; }
    }
}
