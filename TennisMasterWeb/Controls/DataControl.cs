using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Csla;
using Csla.Validation;
using System.Text;
using TennisObjects;

namespace Tennis.Controls
{
	public abstract class DataControl<T> : BaseControl where T : BusinessBase<T>
	{
		private T obj;
		private string _id;

		protected T Object
		{
			get
			{
				if (obj == null)
					InitData();
				return obj;
			}
		}

		protected Button Edit { get { return this.Master.ButtonsPlaceHolder.FindControl("Edit") as Button; } }
		protected Button Submit { get { return this.Master.ButtonsPlaceHolder.FindControl("Submit") as Button; } }
		protected Button Cancel { get { return this.Master.ButtonsPlaceHolder.FindControl("Cancel") as Button; } }

		#region Page Overrides
		/*
		PreInit
		Init
		InitComplete
		PreLoad
		Load
		Control events (Button Click, TextChanged, etc.)
		LoadComplete
		PreRender
		SaveStateComplete
		Render
		Unload
		*/

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			_id = Request.QueryString["id"];
			if (_id == null)
				EditRequested = true;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Submit.Click += new EventHandler(Submit_Click);
			Edit.Click += new EventHandler(Edit_Click);
			Cancel.Click += new EventHandler(Cancel_Click);
		}

		protected override void OnPreRender(EventArgs e)
		{
			Page.Title += Caption;

			base.OnPreRender(e);
			Master.EditingControls.Visible = Util.CanEdit;
			this.Enabled = Editing;
			
			Edit.Visible = !EditRequested;
			Submit.Visible = Cancel.Visible = EditRequested;

			/****
			 * when displaying new item for first time
			 * we need to create the new item 
			 * and copy it to the form
			 * to populate the form with default values
			 * 
			 * when the new item is posted
			 * we need to create the new item again
			 * and then copy the data from the form over the default values
			 * 
			 * when the item is cancelled, we don't need the object at all
			 * it can be re-displayed from view state
			 * */
			//InitData();

			//we definitely need 
			if (!IsPostBack)
				InitData();
		}
		#endregion

		#region Properties
		bool _editRequested;

		public bool EditRequested
		{
			get { return _editRequested; }
			set { _editRequested = value; }
		}

		public bool Editing
		{
			get
			{
				return _editRequested && Util.CanEdit;
			}
		}

		protected Tennis.Master Master
		{
			get { return (Tennis.Master)Page.Master; }
		}

		protected virtual String CaptionPrefix
		{
			get { return _id == null ? "New" : _editRequested ? "Edit" : "View"; }
		}

		protected virtual String CaptionDesc
		{
			get { return typeof(T).Name; }
		}

		protected virtual String Caption
		{
			get { return string.Format("{0} {1}", CaptionPrefix, CaptionDesc); }
		}
		#endregion

		#region Data Object Interface
		//protected abstract void InitData();
		protected virtual void InitData()
		{
			obj = (_id == null) ? CreateObject() : GetObject(_id);
			if (IsPostBack)
				GetDataFromForm();
			else
				CopyDataToForm();
		}

		protected abstract T CreateObject();
		protected abstract T GetObject(string id);
		protected abstract void GetDataFromForm();
		protected abstract void CopyDataToForm();
		#endregion

		#region Private Methods
		private bool Save()
		{
			Page.Validate();
			if (!Page.IsValid)
				return false;

			if (!Object.IsValid)
			{
				StringBuilder sb = new StringBuilder();
				foreach (BrokenRule r in Object.GetAllBrokenRules())
					sb.AppendFormat("{0}<br>", r.Description);
				Master.StatusText = sb.ToString();
				if (Master.StatusText.Length == 0)
					Master.StatusText = "Unable to save; data invalid.";
				return false;
			}

			Object.Save();
			Master.StatusText = "Saved";
			return true;
		}
		#endregion

		#region Event Handlers
		protected virtual void Submit_Click(object sender, System.EventArgs e)
		{
			if (Save())
			{
				Master.StatusText = "Submitted";
				_editRequested = false;
			}
			else
				_editRequested = true;
		}

		protected virtual void Cancel_Click(object sender, System.EventArgs e)
		{
			Master.StatusText = "Cancelled";
			_editRequested = false;
		}

		protected virtual void Edit_Click(object sender, EventArgs e)
		{
			Master.StatusText = "Editing";
			_editRequested = true;
		}
		#endregion

	}
}
