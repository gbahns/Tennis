using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/*
 * resulting HTML looks like this:
 * <span id="YourId">
 *	<input id="YourId$textBox"/>
 *	<img id="YourId_img"/>
 *	<div id="YourId$div">
 *		<iframe id="YourId_iframe"/>
 *		<table>
 *		.
 *		.
 *		.
 *		</table>
 *  </div>
 * </span>
*/
namespace Bahns.Web.UI.WebControls
{
	public enum CalendarStyle { Dynamic, Static };
	public enum AutoCloseMode { SingleClick, DoubleClick, None };

	[DefaultProperty("Text")]
	[ToolboxData("<{0}:DatePicker runat=server></{0}:DatePicker>")]
	public class DatePicker : CompositeControl// WebControl
	{
		TextBox textBox = new TextBox();

		#region Constructor
		public DatePicker()
		{
			textBox.ID = "textBox";
			textBox.Width = new Unit("90px");
			textBox.Style[HtmlTextWriterStyle.VerticalAlign] = "bottom";

			Width = new Unit("64px");
			CssClass = "DatePicker";
		}
		#endregion

		#region Overrides
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			textBox.Attributes["onchange"] = "calendars['" + this.ClientID + "'].onTextChanged();";
			/*image.Attributes["onclick"] = string.Format("calendars['{0}'].show();", this.ClientID);
			image.Attributes["onmouseleave"] = string.Format("calendars['{0}'].checkfocus();", this.ClientID);*/

			//allowHide="<%=CalendarStyle==CalendarStyle.Dynamic%>"
			//div.Attributes["allowHide"] = (CalendarStyle == CalendarStyle.Dynamic).ToString();
			
			if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "DatePicker"))
			{
				Page.ClientScript.RegisterClientScriptInclude(
				   this.GetType(), "DatePicker",
				   Page.ClientScript.GetWebResourceUrl(this.GetType(), "Bahns.Web.UI.WebControls.Resources.DatePicker.js")
				   );
			}

			if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), ClientID))
			{
				Page.ClientScript.RegisterStartupScript(this.GetType(), ClientID,
					string.Format("calendar = new Calendar('{0}', '{1}', '{2}');", ClientID, calendarStyle, autoCloseMode), true);
			}
		}

		protected override object SaveViewState()
		{
			return textBox.Text;
		}

		protected override void LoadViewState(object savedState)
		{
			textBox.Text = (string)savedState;
		}

		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			//base.RenderBeginTag(writer);
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
			//base.RenderEndTag(writer);
		}
		#endregion

		#region Private Data
		string relpath = "../";
		//bool bDisabled = false;
		//string width = "64px";
		string tooltip = "";
		string checkfunc = "CheckDatePickerDate";
		//string cssClass = "DatePicker";
		CalendarStyle calendarStyle = CalendarStyle.Dynamic;
		AutoCloseMode autoCloseMode = AutoCloseMode.SingleClick;

		string prevMonthImage = "";
		string nextMonthImage = "";
		string prevYearImage = "";
		string nextYearImage = "";

		//internal string[] months = { "Jan", "Feb", "March", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
		protected string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
		protected string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
		protected int dayDisplayLength = 1;
		protected int monthDisplayLength = 0;
		#endregion

		#region Properties

		[Bindable(true), Category("Appearance"), DefaultValue("")]
		public string Text
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		/*public DateTime Value
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}*/

		[Bindable(true), Category("Appearance"), Description("relative Path to images"), DefaultValue("../")]
		public string RelPath
		{
			get { return relpath; }
			set { relpath = value; }
		}

		[Bindable(true), Category("Appearance"), Description("Tooltip"), DefaultValue("")]
		public string Tooltip
		{
			get { return tooltip; }
			set { tooltip = value; }
		}

		/*[Bindable(true), Category("Appearance"), Description("Width in Pixel incl. 'px'"), DefaultValue("64px")]
		public string Width
		{
			get { return width; }
			set { width = value; }
		}*/

		[Bindable(true), Category("Appearance"), Description("JavaScript-Function to validate user input"), DefaultValue("CheckDatePickerDate")]
		public string CheckFunc
		{
			get { return checkfunc; }
			set { checkfunc = value; }
		}

		//[Bindable(true), Category("Appearance"), DefaultValue(false)]
		//public bool Disabled
		//{
		//    get { return bDisabled; }
		//    set { bDisabled = value; }
		//}

		[Bindable(true), Category("Appearance"), Description("Number of characters to display for each day of the week in the header."), DefaultValue("1")]
		public int DayDisplayLength
		{
			get { return dayDisplayLength; }
			set { dayDisplayLength = value; }
		}

		[Bindable(true), Category("Appearance"), Description("Number of characters to display for each month in the month list."), DefaultValue("0")]
		public int MonthDisplayLength
		{
			get { return monthDisplayLength; }
			set { monthDisplayLength = value; }
		}

		/*[Bindable(true), Category("Appearance"), Description("CSS class name to use for the control's appearance."), DefaultValue("DatePicker")]
		public string CssClass
		{
			get { return cssClass; }
			set { cssClass = value; }
		}*/

		[Bindable(true), Category("Appearance"), Description("Specifies whether the calendar should always be visible."), DefaultValue("Dynamic")]
		public CalendarStyle CalendarStyle
		{
			get { return calendarStyle; }
			set { calendarStyle = value; }
		}

		[Bindable(true), Category("Appearance"), Description("Specifies whether the calendar should auto-hide when a date is selected."), DefaultValue("SingleClick")]
		public AutoCloseMode AutoCloseMode
		{
			get { return autoCloseMode; }
			set { autoCloseMode = value; }
		}

		public string MainDivStyle
		{
			get
			{
				return CalendarStyle == CalendarStyle.Dynamic ? "display: none; position: absolute;" : "";
			}
		}

		/*public string DayClickEvents
		{
			get
			{
				switch (autoCloseMode)
				{
					case AutoCloseMode.DoubleClick:
						return string.Format("onclick=\"calendars['{0}'].selectDay(this);\" ondblclick=\"calendars['{0}'].hide();\"", this.ClientID);
					case AutoCloseMode.SingleClick:
						return string.Format("onclick=\"calendars['{0}'].selectDay(this); calendars['{0}'].hide();\"", this.ClientID);
					default:
						return "";
				}


				//return "onclick="calendars['<%=this.ClientID%>'].selectDay(this);" ondblclick="calendars['<%=this.ClientID%>'].hide();" ";
			}
		}*/

		internal string MonthText(int i)
		{
			return monthDisplayLength == 0 ? months[i] : months[i].Substring(0, monthDisplayLength);
		}

		internal string DayText(int i)
		{
			return dayDisplayLength == 0 ? days[i] : days[i].Substring(0, dayDisplayLength);
		}

		public string PrevMonthImage
		{
			get { return prevMonthImage; }
			set { prevMonthImage = value; }
		}

		public string NextMonthImage
		{
			get { return nextMonthImage; }
			set { nextMonthImage = value; }
		}

		public string PrevYearImage
		{
			get { return prevYearImage; }
			set { prevYearImage = value; }
		}

		public string NextYearImage
		{
			get { return nextYearImage; }
			set { nextYearImage = value; }
		}
		#endregion

		protected override void CreateChildControls()
		{
			Controls.Clear();
			CreateControlHierarchy();
			//ClearChildViewState();
		}

		private void AddLiteral(string s)
		{
			Literal literal = new Literal();
			literal.Text = s;
			Controls.Add(literal);
		}

		protected virtual void CreateControlHierarchy()
		{
			Controls.Add(textBox);
		}

		private string PrevMonthContent
		{
			get
			{
				if (PrevMonthImage.Length > 0)
					return "<img src='DatePickerImages/"+PrevMonthImage+"' >";
				else
					return "&lt;";
			}
		}

		private string NextMonthContent
		{
			get
			{
				if (NextMonthImage.Length > 0)
					return "<img src='DatePickerImages/"+NextMonthImage+"' >";
				else
					return "&gt;";
			}
		}

		private string MonthOptions
		{
			get
			{
				StringBuilder s = new StringBuilder();
				for (int i=0; i<months.Length; i++)
				{
					s.AppendFormat("<option value='{0}'>{1}</option>",i,MonthText(i));
				}
				return s.ToString();
			}
		}

		private string YearOptions
		{
			get
			{
				StringBuilder s = new StringBuilder();
				for (int i=2003; i<=2009; i++)
				{
					s.AppendFormat("<option value='{0}'>{0}</option>",i);
				}
				return s.ToString();
			}
		}

		private string DayHeaders
		{
			get
			{
				StringBuilder s = new StringBuilder();
				for (int i=0; i<days.Length; i++)
				{
					s.AppendFormat("<th>{0}</th>",DayText(i));
				}
				return s.ToString();
			}
		}

		private string DayRows
		{
			get
			{
				StringBuilder s = new StringBuilder();
				//add 6 rows to the calendar with 7 columns
				for (int j=0; j<6; j++)
				{
					s.Append("<tr>");
					for (int i = 0; i < 7; i++)
					{
						//use an <a> tag inside the <td> to workaround IE6's inability to apply styles
						//to the td:hover pseudo-element
						s.AppendFormat(@"<td><a id='{0}${1}${2}' href='javascript:void(0);' onclick='calendars[""{0}""].onDayClick(this);' ondblclick='calendars[""{0}""].onDayDoubleClick();' style='display:block;'/>&nbsp;</td>", ClientID, j, i);
						//<!-- <td id='{0}$<%=j%>$<%=i%>' onclick='calendars[""{0}""].selectDay(this)' ondblclick='calendars[""{0}""].hide();' >&nbsp</td> -->
					}
					s.Append("</tr>");
				}
				return s.ToString();
			}
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			textBox.RenderControl(output);
			//base.RenderContents(output);

			//we may need to include the image but hidden
			//in order to support enabling in the browser
			//also if the mode is static then I guess the calendar should be displayed
			//but disabled

			if (!Enabled)
				return;

			string imgurl = Page.ClientScript.GetWebResourceUrl(this.GetType(),
				"Bahns.Web.UI.WebControls.Resources.calendar4.gif");

			//<input id='{0}$textBox' size='15' style='vertical-align: bottom;' value='{3}'/>
			string text = string.Format(@"<img id='{0}_image' src='" + imgurl + @"'
	style='vertical-align: top; margin-top: 3px; position:relative; left:-18px;'
	onclick='calendars[""{0}""].show();'
	/>
<div id='{0}' style='{1}' ondeactivate='calendars[""{0}""].checkhide();' >
<iframe id='{0}_iframe' style='display: block; position: absolute; width: 100px; height: 100px; background-color: Red; border-width: 0; border-style: none; z-index: 100;'></iframe>
<table cellspacing='0' cellpadding='0' class='{2}' style='z-index: 200;' >
	<thead>
		<tr >
			<td colspan='7'>
				<table cellspacing='0' cellpadding='0' width='100%' border='0'>
					<tr >
						<td title='Previous Month' class='NavButton' onclick='calendars[""{0}""].prevMonth();' ondblclick='calendars[""{0}""].prevMonth(); false;'>
							" + PrevMonthContent + @"
						</td>
						<td title='Month' class='MonthSelector'>
							<select id='{0}$calendarMonth' onchange='calendars[""{0}""].onMonthChanged();'>
								" + MonthOptions + @"
							</select>
						</td>
						<td title='Year' class='YearSelector'>
							<select id='{0}$calendarYear' onchange='calendars[""{0}""].onYearChanged();'>
								" + YearOptions + @"
							</select>
						</td>
						<td title='Next Month' class='NavButton' onclick='calendars[""{0}""].nextMonth();' ondblclick='calendars[""{0}""].nextMonth();'>
							" + NextMonthContent + @"
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</thead>
	<tbody class='Body'>
		<tr>
			" + DayHeaders + @"
		</tr>
		" + DayRows + @"
	</tbody>
</table>
</div>
", ClientID, MainDivStyle, CssClass, Text);

			output.Write(text);
		}

	}
}
