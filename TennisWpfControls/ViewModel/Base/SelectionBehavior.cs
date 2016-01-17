﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace TennisWpfControls.ViewModel
{
	public class SelectionBehavior
	{
		public static DependencyProperty SelectionChangedProperty =
				DependencyProperty.RegisterAttached("SelectionChanged",
				typeof(ICommand),
				typeof(SelectionBehavior),
				new UIPropertyMetadata(SelectionBehavior.SelectedItemChanged));

		public static void SetSelectionChanged(DependencyObject target, ICommand value)
		{
			target.SetValue(SelectionBehavior.SelectionChangedProperty, value);
		}

		private static void SelectedItemChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			Selector element = target as Selector;

			if (element == null)
				throw new InvalidOperationException("This behavior can be attached to Selector item only.");

			if ((e.NewValue != null) && (e.OldValue == null))
			{
				element.SelectionChanged += SelectionChanged;
			}
			else if ((e.NewValue == null) && (e.OldValue != null))
			{
				element.SelectionChanged -= SelectionChanged;
			}
		}

		private static void SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UIElement element = (UIElement)sender;
			ICommand command = (ICommand)element.GetValue(SelectionBehavior.SelectionChangedProperty);
			command.Execute(e);
		}
	}
}
