using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Bahns.Util
{
	public static class DataBind
	{
		public static void BindField(Control control, string propertyName, object dataSource, string dataMember, DataSourceUpdateMode dataSourceUpdateMode)
		{
			for (int i = control.DataBindings.Count - 1; i >= 0; i--)
			{
				Binding bd = control.DataBindings[i];
				if (bd.PropertyName == propertyName)
				{
					control.DataBindings.Remove(bd);
				}
			}
			if (dataSource != null)
				control.DataBindings.Add(propertyName, dataSource, dataMember).DataSourceUpdateMode = dataSourceUpdateMode;
		}

		public static void BindField(Control control, string propertyName, object dataSource, string dataMember)
		{
			BindField(control, propertyName, dataSource, dataMember, DataSourceUpdateMode.OnPropertyChanged);
		}
	}
}
