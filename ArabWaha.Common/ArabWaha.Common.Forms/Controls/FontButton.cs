using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ArabWaha.Common.Forms.Controls
{
    public class FontButton : Button
    {
        public string Family { get; set; }
        public string FontFile { get; set; }

        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (!string.IsNullOrEmpty(base.Text) && base.Text.StartsWith("0x"))
                {
                    int num = int.Parse(base.Text.Substring(2), NumberStyles.AllowHexSpecifier);
                    base.Text = ((char)num).ToString();
                }
            }
        }

    }
}
