using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Bahns.Util.Validation;
//using Bahns.Util.Validation;
//using Sfg.Framework.Security;

namespace Bahns.Core.BusinessObjects
{
	/// <summary>
	/// An object is "new" if it does not exist in the database, and "old" if it
	/// does.
	/// 
	/// An object is "clean" for a new object if its values match the default
	/// values, and for an old if its values match the values stored in the
	/// database.
	/// 
	/// When a business object is first instantiated, it is considered "new" and
	/// "not dirty".  From there, the object could be presented to the user as a
	/// new object with default values, or it could be populated with existing
	/// data.
	/// 
	/// When a new object is first edited by the user, it is still "new", but also
	/// becomes "dirty".
	/// 
	/// When an existing object is retrieved from the database, it is considered
	/// "old" but "not dirty" until it is edited.
	/// </summary>
	public abstract class BusinessBase : INotifyPropertyChanged, IDataErrorInfo
	{
		#region Constructors
		protected BusinessBase()
		{
			AddBusinessRules();
		}
		#endregion

		#region Fields
		bool _isDirty;
		bool _isNew = true;
		#endregion

		#region Properties
		public virtual bool IsDirty
		{
			get { return _isDirty; }
		}

		public bool IsNew
		{
			get { return _isNew; }
		}

		public bool IsSavable
		{
			get { return IsDirty && IsValid; }
		}
		#endregion

		#region Public Methods
		#endregion

		#region ValidationRules, IsValid

		private Bahns.Util.Validation.ValidationRules _validationRules;

		/// <summary>
		/// Provides access to the broken rules functionality.
		/// </summary>
		/// <remarks>
		/// This property is used within your business logic so you can
		/// easily call the AddRule() method to associate validation
		/// rules with your object's properties.
		/// </remarks>
		protected Bahns.Util.Validation.ValidationRules ValidationRules
		{
			get
			{
				if (_validationRules == null)
					_validationRules = new Bahns.Util.Validation.ValidationRules(this);
				return _validationRules;
			}
		}

		/// <summary>
		/// Override this method in your business class to
		/// be notified when you need to set up business
		/// rules.
		/// </summary>
		/// <remarks>
		/// This method is automatically called by CSLA .NET
		/// when your object should associate per-instance
		/// validation rules with its properties.
		/// </remarks>
		protected virtual void AddInstanceBusinessRules()
		{
		}

		/// <summary>
		/// Override this method in your business class to
		/// be notified when you need to set up shared 
		/// business rules.
		/// </summary>
		/// <remarks>
		/// This method is automatically called by CSLA .NET
		/// when your object should associate per-type 
		/// validation rules with its properties.
		/// </remarks>
		protected virtual void AddBusinessRules()
		{
		}

		/// <summary>
		/// Returns <see langword="true" /> if the object is currently valid, <see langword="false" /> if the
		/// object has broken rules or is otherwise invalid.
		/// </summary>
		/// <remarks>
		/// <para>
		/// By default this property relies on the underling ValidationRules
		/// object to track whether any business rules are currently broken for this object.
		/// </para><para>
		/// You can override this property to provide more sophisticated
		/// implementations of the behavior. For instance, you should always override
		/// this method if your object has child objects, since the validity of this object
		/// is affected by the validity of all child objects.
		/// </para>
		/// </remarks>
		/// <returns>A value indicating if the object is currently valid.</returns>
		//[Browsable(false)]
		public virtual bool IsValid
		{
			get { return ValidationRules.IsValid; }
		}


		/// <summary>
		/// Provides access to the readonly collection of broken business rules
		/// for this object.
		/// </summary>
		/// <returns>A Csla.Validation.RulesCollection object.</returns>
		//[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual Bahns.Util.Validation.BrokenRulesCollection BrokenRulesCollection
		{
			get { return ValidationRules.GetBrokenRules(); }
		}

		#endregion

		#region Authorization
		public static void Authorize(bool authorized)
		{
			//Authorization.Authorize(authorized);
		}

		protected static void Authorize(string rule)
		{
			//Authorization.Authorize(rule);
		}

		protected static bool IsAuthorized(string rule)
		{
			//return Authorization.IsAuthorized(rule);
			return true;
		}
		#endregion

		#region MarkNew, MarkOld, MarkDirty
		/// <summary>
		/// Marks the object as being a new object. This also marks the object
		/// as being dirty and ensures that it is not marked for deletion.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Newly created objects are marked new by default. You should call
		/// this method in the implementation of DataPortal_Update when the
		/// object is deleted (due to being marked for deletion) to indicate
		/// that the object no longer reflects data in the database.
		/// </para><para>
		/// If you override this method, make sure to call the base
		/// implementation after executing your new code.
		/// </para>
		/// </remarks>
		protected virtual void MarkNew()
		{
			_isNew = true;
			//_isDeleted = false;
			MarkClean();
			//MarkDirty();
		}

		/// <summary>
		/// Marks the object as being an old (not new) object. This also
		/// marks the object as being unchanged (not dirty).
		/// </summary>
		/// <remarks>
		/// <para>
		/// You should call this method in the implementation of
		/// DataPortal_Fetch to indicate that an existing object has been
		/// successfully retrieved from the database.
		/// </para><para>
		/// You should call this method in the implementation of 
		/// DataPortal_Update to indicate that a new object has been successfully
		/// inserted into the database.
		/// </para><para>
		/// If you override this method, make sure to call the base
		/// implementation after executing your new code.
		/// </para>
		/// </remarks>
		protected virtual void MarkOld()
		{
			_isNew = false;
			MarkClean();
		}

		/// <summary>
		/// Marks an object as being dirty, or changed.
		/// </summary>
		/// <remarks>
		/// <para>
		/// You should call this method in your business logic any time
		/// the object's internal data changes. Any time any instance
		/// variable changes within the object, this method should be called
		/// to tell CSLA .NET that the object's data has been changed.
		/// </para><para>
		/// Marking an object as dirty does two things. First it ensures
		/// that CSLA .NET will properly save the object as appropriate. Second,
		/// it causes CSLA .NET to tell Windows Forms data binding that the
		/// object's data has changed so any bound controls will update to
		/// reflect the new values.
		/// </para>
		/// </remarks>
		protected void MarkDirty()
		{
			MarkDirty(false);
		}

		/// <summary>
		/// Marks an object as being dirty, or changed.
		/// </summary>
		/// <param name="suppressEvent">
		/// <see langword="true" /> to supress the PropertyChanged event that is otherwise
		/// raised to indicate that the object's state has changed.
		/// </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void MarkDirty(bool suppressEvent)
		{
			_isDirty = true;
			if (!suppressEvent)
				OnPropertyChanged(null);
		}

		/// <summary>
		/// Forces the object's IsDirty flag to <see langword="false" />.
		/// </summary>
		/// <remarks>
		/// This method is normally called automatically and is
		/// not intended to be called manually.
		/// </remarks>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void MarkClean()
		{
			_isDirty = false;
			OnPropertyChanged(null);
		}

		#endregion

		#region SetProperty, PropertyChanged
		/// <summary>
		/// Performs processing required when the current
		/// property has changed.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method calls CheckRules(propertyName), MarkDirty and
		/// OnPropertyChanged(propertyName). MarkDirty is called such
		/// that no event is raised for IsDirty, so only the specific
		/// property changed event for the current property is raised.
		/// </para><para>
		/// This implementation uses System.Diagnostics.StackTrace to
		/// determine the name of the current property, and so must be called
		/// directly from the property to be checked.
		/// </para>
		/// </remarks>
		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void PropertyHasChanged()
		{
			string propertyName = new StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
			PropertyHasChanged(propertyName);
		}

		/// <summary>
		/// Performs processing required when a property
		/// has changed.
		/// </summary>
		/// <param name="propertyName">Name of the property that
		/// has changed.</param>
		/// <remarks>
		/// This method calls CheckRules(propertyName), MarkDirty and
		/// OnPropertyChanged(propertyName). MarkDirty is called such
		/// that no event is raised for IsDirty, so only the specific
		/// property changed event for the current property is raised.
		/// </remarks>
		protected virtual void PropertyHasChanged(string propertyName)
		{
			TennisObjects.Log.Debug("calling CheckRules('{0}')", propertyName);

			bool wasValid = IsValid;

			ValidationRules.CheckRules(propertyName);

			//force refresh of all properties, in particular BrokenRules, IsValid, IsSavable, 
			//if not valid either before or after this property change
			if (!IsValid || !wasValid)
				OnPropertyChanged(null);
			
			TennisObjects.Log.Debug("{0} broken rules", BrokenRulesCollection.Count);
			if (BrokenRulesCollection.Count > 0)
				TennisObjects.Log.Debug(BrokenRulesCollection.ToString());
			MarkDirty(true);
			OnPropertyChanged(propertyName);
		}


		/*private void PropertyChange(string name)
		{
			_isDirty = true;
			OnPropertyChanged(name);
		}*/

		public void Save()
		{
			ValidationRules.CheckRules();

			if (!IsValid)
			{
				OnPropertyChanged(null);
				throw new InvalidOperationException("The business object is not in a savable state.");
			}

			Update();

			MarkOld();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected bool SetProperty<T>(ref T field, T value)
		{
			string propertyName = new StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
			return SetProperty(propertyName, ref field, value);
		}

		protected bool SetProperty<T>(string propertyName, ref T field, T value)
		{
			if (field != null && field.Equals(value))
				return false;
			TennisObjects.Log.Debug("{0} changing from {1} to {2}", propertyName, field, value);
			field = value;
			PropertyHasChanged(propertyName);
			return true;
		}
		#endregion

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		/// <summary>
		/// In a parent class, attach this event handler to the child's PropertyChanged
		/// event.  This generic handler will raise an unnamed PropertyChanged event on
		/// the parent, so listeners will not know exactly which property changed, but
		/// it's better than nothing.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Child_PropertyChangedGeneric(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			//todo: see if there's a way to generically determine the name of the property on the parent
			//I suppose this probably isn't possible... even if we loo
			OnPropertyChanged(null);
		}

		#endregion

		#region IDataErrorInfo
		string IDataErrorInfo.Error
		{
			get
			{
				if (!IsValid)
					return ValidationRules.GetBrokenRules().ToString();
				else
					return String.Empty;
			}
		}

		string IDataErrorInfo.this[string columnName]
		{
			get
			{
				string result = string.Empty;
				if (!IsValid)
				{
					BrokenRule rule = ValidationRules.GetBrokenRules().GetFirstBrokenRule(columnName);
					if (rule != null)
						result = rule.Description;
				}
				return result;
			}
		}
		#endregion

		#region Data Access
		protected virtual void Update() { }
		#endregion
	}
}
