using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Bahns.Web.UI.WebControls
{
	public class LabeledStaticBox : CompositeControl
	{
		Label label = new Label();
		Label textBox = new Label();

		bool autoColon = true;

		public LabeledStaticBox()
		{
			//defaults
			//label.Width = new Unit("140px");
			label.CssClass = "Label";

			//textBox.Width = new Unit("80px");
			textBox.CssClass = "Value";
		}

		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			//base.RenderBeginTag(writer);
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
			//base.RenderEndTag(writer);
		}

		public string Label
		{
			get { return label.Text; }
			set
			{
				label.Text = value;
				//label.Width = new Unit(value.Length > 0 ? "120px" : "0");
				if (value.Length > 0 && autoColon)
					label.Text += ":";
			}
		}

		[Bindable(true), Category("Appearance"), DefaultValue(""), Localizable(true)]
		public string Text
		{
			get
			{
				String s = (String)ViewState["Text"];
				return ((s == null) ? String.Empty : s);
			}

			set
			{
				ViewState["Text"] = value;
			}
		}

		/*public bool Enabled
		{
			get { return textBox.Enabled; }
			set { textBox.Enabled = value; }
		}*/


		public bool ReadOnly
		{
			get { return true; }
			set
			{
				//always readonly by definition
			}
		}

		/*public TextBoxMode TextMode
		{
			get { return textBox.TextMode; }
			set { textBox.TextMode = value; }
		}*/

		public override Unit Height
		{
			get { return base.Height; }
			set { base.Height = textBox.Height = value; }
		}

		public Unit TextWidth
		{
			get { return textBox.Width; }
			set { textBox.Width = value; }
		}

		public Unit LabelWidth
		{
			get { return label.Width; }
			set { label.Width = value; }
		}

		public bool AutoColon
		{
			get { return autoColon; }
			set { autoColon = value; }
		}

		protected override void CreateChildControls()
		{
			Controls.Clear();
			CreateControlHierarchy();
			ClearChildViewState();
		}

		private void AddLiteral(string s)
		{
			Literal literal = new Literal();
			literal.Text = s;
			Controls.Add(literal);
		}

		protected virtual void CreateControlHierarchy()
		{
			textBox.Text = this.Text;

			Controls.Add(label);
			AddLiteral(" ");
			Controls.Add(textBox);
		}
	}
}