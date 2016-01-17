using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Validation;

namespace TennisObjects
{
	static class BusinessRules
	{
		static public bool ComboRequired(object target, RuleArgs e)
		{
			e.Description = e.PropertyName + " is required";
			return (int)Utilities.CallByName(target, e.PropertyName, CallType.Get) > 0;
		}

		//Public Function DateRequired(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean 
		// e.Description = e.PropertyName & " is required" 
		// Return Not DirectCast(CallByName(target, e.PropertyName, CallType.Get), SmartDate).IsEmpty 
		//End Function 

		static public bool DateRequired(object target, RuleArgs e)
		{
			e.Description = e.PropertyName + " is required";
			return ((string)Utilities.CallByName(target, e.PropertyName, CallType.Get)).Length > 0;
		}

		static public bool DateIsInPast(object target, RuleArgs e)
		{
			e.Description = e.PropertyName + " must be in the past";
			return (System.DateTime)Utilities.CallByName(target, e.PropertyName, CallType.Get) < System.DateTime.Now;
		}

	}
}
