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
using System.Text;

namespace Bahns.Web.UI.WebControls
{
	//[DefaultProperty("Text")]
	[ToolboxData("<{0}:LabeledTextBox1 runat=server></{0}:LabeledTextBox1>")]
	public class LabeledTextBox : CompositeControl
	{
		/*
		<asp:Label runat="server" ID="label" Text=" " Width="140px" CssClass="Label" />
		<asp:TextBox runat="server" ID="textBox" Width="80px" style="font-size: 8pt; font-family: Tahoma;" />
		*/
		Label _label = new Label();
		TextBox _textBox = new TextBox();

		bool _autoColon = true;
		bool _labelOnTop = false;
		bool _readOnly = false;
		int _colSpan = 0;
		int _rowSpan = 0;

		public LabeledTextBox()
		{
			//set the defaults

			_textBox.Width = new Unit("70px");
			_textBox.ID = "textBox";
			//textBox.Attributes["style"] = "font-size: 8pt; font-family: Tahoma;";
			//textBox.Font.Size = new FontUnit(8);
			//textBox.Font.Name = "Tahoma";

			_label.ID = "label";
			//_label.Width = new Unit("140px");
			_label.CssClass = "Label";
		}

		//by default the control is wrapped in a SPAN tag; this seems to cause problems
		//with the positioning of near-by controls, so the output of the wrapping tag
		//is here disabled.  perhaps we could use a DIV instead of SPAN and then remove
		//these overrides.
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			//base.RenderBeginTag(writer);
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
			//base.RenderEndTag(writer);
		}

		/*protected void Page_Load(object sender, EventArgs e)
		{
			textBox.Attributes["onchange"] = "ClearMessage();";

		}*/

		public string Label
		{
			get { return _label.Text; }
			set
			{
				_label.Text = value;
				//label.Width = new Unit(value.Length > 0 ? "120px" : "0");
				if (value.Length > 0 && _autoColon)
					_label.Text += ":";
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

		public bool ReadOnly
		{
			get { return _readOnly; }
			set
			{
				_readOnly = value;
				_textBox.ReadOnly = value;
				_textBox.Style["background"] = value ? "#e7e7e7" : "";
			}
		}

		public TextBoxMode TextMode
		{
			get { return _textBox.TextMode; }
			set { _textBox.TextMode = value; }
		}

		public string TextAlign
		{
			get { return _textBox.Style["text-align"]; }
			set { _textBox.Style["text-align"] = value; }
		}

		public override Unit Height
		{
			get { return base.Height; }
			set { base.Height = _textBox.Height = value; }
		}

		public Unit TextWidth
		{
			get { return _textBox.Width; }
			set { _textBox.Width = value; }
		}

		public Unit LabelWidth
		{
			get { return _label.Width; }
			set { _label.Width = value; }
		}

		public bool AutoColon
		{
			get { return _autoColon; }
			set { _autoColon = value; }
		}

		public bool LabelOnTop
		{
			get { return _labelOnTop; }
			set { _labelOnTop = value; }
		}

		public string LabelCssClass
		{
			get { return _label.CssClass; }
			set { _label.CssClass = value; }
		}

		public string TextCssClass
		{
			get { return _textBox.CssClass; }
			set { _textBox.CssClass = value; }
		}

		[Category("Layout"), Description("If set, wraps the controld in a TD element and applies the specified colspan value")]
		public int ColSpan
		{
			get { return _colSpan; }
			set { _colSpan = value; }
		}

		public int RowSpan
		{
			get { return _rowSpan; }
			set { _rowSpan = value; }
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

		private void AddCellBeginTag()
		{
			if (_colSpan <= 0 && _rowSpan <= 0)
				return;

			StringBuilder sb = new StringBuilder();
			sb.Append("<td width=\"1px\"");
			if (_colSpan > 0)
				sb.AppendFormat(" colspan=\"{0}\"", _colSpan);
			if (_rowSpan > 0)
				sb.AppendFormat(" rowspan=\"{0}\"", _rowSpan);
			sb.Append(">");
			AddLiteral(sb.ToString());
		}

		private void AddCellEndTag()
		{
			if (_colSpan <= 0 && _rowSpan <= 0)
				return;
			AddLiteral("</td>");
		}

		protected virtual void CreateControlHierarchy()
		{
			_textBox.Text = this.Text;

			AddCellBeginTag();
			Controls.Add(_label);
			AddLiteral(_labelOnTop ? "<br/>" : " ");
			Controls.Add(_textBox);
			//AddLiteral("<br/>");
			AddCellEndTag();
		}
	}
}