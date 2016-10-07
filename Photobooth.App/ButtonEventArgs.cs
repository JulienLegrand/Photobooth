using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photobooth.App
{
    public class ButtonEventArgs : EventArgs
    {
        private string buttonName;

        public ButtonEventArgs(string buttonName)
        {
            this.buttonName = buttonName;
        }

        public string ButtonName
        {
            get { return this.buttonName; }
        }
    }
}
