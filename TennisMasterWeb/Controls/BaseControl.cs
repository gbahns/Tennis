using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Tennis.Controls
{
	public class BaseControl : System.Web.UI.UserControl
	{
		bool TryEnable(WebControl c, bool enabled)
		{
			if (c == null || c is Button)
				return false;
			c.Enabled = enabled;
			return true;
		}

		bool TryEnable(SetScoreControl c, bool enabled)
		{
			if (c == null)
				return false;
			c.Enabled = enabled;
			return true;
		}

		internal bool Enabled
		{
			//get { return !Form1.Disabled; }
			set
			{
				foreach (Control c in Controls)
				{
					if (TryEnable(c as WebControl, value)) continue;
					if (TryEnable(c as SetScoreControl, value)) continue;
				}
			}
		}

	}
}
