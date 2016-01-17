using System;
using System.ComponentModel;
using System.Diagnostics;
using Bahns.Core.BusinessObjects;

namespace TennisWpfControls.ViewModel
{
    /// <summary>
    /// Base class for all ViewModel classes in the application.
    /// It provides support for property change notifications 
    /// and has a DisplayName property.  This class is abstract.
    /// </summary>
    public abstract class ViewModelBusinessBase<T> : ViewModelBase, IDataErrorInfo where T : BusinessBase
    {
        #region Constructor
		protected ViewModelBusinessBase()
        {
        }
        #endregion // Constructor

		#region Business Object
		T _item;

		public T Item 
		{
			get
			{
				return _item;
			}
			set
			{
				if (_item == value)
					return;

				if (_item != null)
					_item.PropertyChanged -= _item_PropertyChanged;

				_item = value;
				_item.PropertyChanged += _item_PropertyChanged;
			}
		}

		/// <summary>
		/// _item_PropertyChanged is a ViewModel helper that assumes that the ViewModel has the same properties
		/// as the underlying business oject, and simply passes along the property changed notification for the
		/// like-named property.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void _item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Debug.WriteLine(string.Format("Item Property Changed: {0}", e.PropertyName));
			if (string.IsNullOrEmpty(e.PropertyName))
			{
				OnPropertyChanged(null);
				return;
			}

			ItemPropertyChanged(e.PropertyName);

			OnPropertyChanged(e.PropertyName);
		}

		/// <summary>
		/// ItemPropertyChanged is called whenever a property on the underlying business object changes.
		/// You can override this as an alternative to attaching an event handler to Item.PropertyChanged.
		/// </summary>
		protected virtual void ItemPropertyChanged(string propertyName)
		{
		}
		
		#endregion

		#region IDataErrorInfo Members
		string IDataErrorInfo.Error
		{
			get { return ((IDataErrorInfo)Item).Error; }
		}

		string IDataErrorInfo.this[string columnName]
		{
			get { return ((IDataErrorInfo)Item)[columnName]; }
		}
		#endregion
	}
}