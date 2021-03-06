using System;
using System.Collections.Generic;
using Sfg.Util.Properties;

namespace Sfg.Util.Validation
{

	/// <summary>
	/// Tracks the business rules broken within a business object.
	/// </summary>
	[Serializable()]
	public class ValidationRules
	{
		// list of broken rules for this business object.
		private BrokenRulesCollection _brokenRules;
		// threshold for short-circuiting to kick in
		private int _processThroughPriority;
		// reference to current business object
		[NonSerialized()]
		private object _target;
		// reference to per-instance rules manager for this object
		[NonSerialized()]
		private ValidationRulesManager _instanceRules;
		// reference to per-type rules manager for this object
		[NonSerialized()]
		private ValidationRulesManager _typeRules;
		// reference to the active set of rules for this object
		[NonSerialized()]
		private ValidationRulesManager _rulesToCheck;

		public ValidationRules(object businessObject)
		{
			SetTarget(businessObject);
		}

		internal void SetTarget(object businessObject)
		{
			_target = businessObject;
		}

		private BrokenRulesCollection BrokenRulesList
		{
			get
			{
				if (_brokenRules == null)
					_brokenRules = new BrokenRulesCollection();
				return _brokenRules;
			}
		}

		private ValidationRulesManager GetInstanceRules(bool createObject)
		{
			if (_instanceRules == null)
				if (createObject)
					_instanceRules = new ValidationRulesManager();
			return _instanceRules;
		}

		private ValidationRulesManager GetTypeRules(bool createObject)
		{
			if (_typeRules == null)
				_typeRules = SharedValidationRules.GetManager(_target.GetType(), createObject);
			return _typeRules;
		}

		private ValidationRulesManager RulesToCheck
		{
			get
			{
				if (_rulesToCheck == null)
				{
					ValidationRulesManager instanceRules = GetInstanceRules(false);
					ValidationRulesManager typeRules = GetTypeRules(false);
					if (instanceRules == null)
					{
						if (typeRules == null)
							_rulesToCheck = null;
						else
							_rulesToCheck = typeRules;
					}
					else if (typeRules == null)
						_rulesToCheck = instanceRules;
					else
					{
						// both have values - consolidate into instance rules
						_rulesToCheck = instanceRules;
						foreach (KeyValuePair<string, RulesList> de in typeRules.RulesDictionary)
						{
							RulesList rules = _rulesToCheck.GetRulesForProperty(de.Key, true);
							List<IRuleMethod> instanceList = rules.GetList(false);
							instanceList.AddRange(de.Value.GetList(false));
							List<string> dependancy = de.Value.GetDependancyList(false);
							if (dependancy != null)
								rules.GetDependancyList(true).AddRange(dependancy);
						}
					}
				}
				return _rulesToCheck;
			}
		}

		/// <summary>
		/// Returns an array containing the text descriptions of all
		/// validation rules associated with this object.
		/// </summary>
		/// <returns>String array.</returns>
		/// <remarks></remarks>
		public string[] GetRuleDescriptions()
		{
			List<string> result = new List<string>();
			ValidationRulesManager rules = RulesToCheck;
			if (rules != null)
			{
				foreach (KeyValuePair<string, RulesList> de in rules.RulesDictionary)
				{
					List<IRuleMethod> list = de.Value.GetList(false);
					for (int i = 0; i < list.Count; i++)
					{
						IRuleMethod rule = list[i];
						result.Add(rule.ToString());
					}
				}
			}
			return result.ToArray();
		}

		#region Short-Circuiting

		/// <summary>
		/// Gets or sets the priority through which
		/// CheckRules should process before short-circuiting
		/// processing on broken rules.
		/// </summary>
		/// <value>Defaults to 0.</value>
		/// <remarks>
		/// All rules for each property are processed by CheckRules
		/// though this priority. Rules with lower priorities are
		/// only processed if no previous rule has been marked as
		/// broken.
		/// </remarks>
		public int ProcessThroughPriority
		{
			get { return _processThroughPriority; }
			set { _processThroughPriority = value; }
		}

		#endregion

		#region Adding Instance Rules

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		public void AddInstanceRule(RuleHandler handler, string propertyName)
		{
			GetInstanceRules(true).AddRule(handler, new RuleArgs(propertyName), 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddInstanceRule(RuleHandler handler, string propertyName, int priority)
		{
			GetInstanceRules(true).AddRule(handler, new RuleArgs(propertyName), priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		/// <typeparam name="T">Type of the business object to be validated.</typeparam>
		public void AddInstanceRule<T>(RuleHandler<T, RuleArgs> handler, string propertyName)
		{
			GetInstanceRules(true).AddRule<T, RuleArgs>(handler, new RuleArgs(propertyName), 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		/// <typeparam name="T">Type of the business object to be validated.</typeparam>
		public void AddInstanceRule<T>(RuleHandler<T, RuleArgs> handler, string propertyName, int priority)
		{
			GetInstanceRules(true).AddRule<T, RuleArgs>(handler, new RuleArgs(propertyName), priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		public void AddInstanceRule(RuleHandler handler, RuleArgs args)
		{
			GetInstanceRules(true).AddRule(handler, args, 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddInstanceRule(RuleHandler handler, RuleArgs args, int priority)
		{
			GetInstanceRules(true).AddRule(handler, args, priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <typeparam name="T">Type of the target object.</typeparam>
		/// <typeparam name="R">Type of the arguments parameter.</typeparam>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		public void AddInstanceRule<T, R>(RuleHandler<T, R> handler, R args) where R : RuleArgs
		{
			GetInstanceRules(true).AddRule(handler, args, 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <typeparam name="T">Type of the target object.</typeparam>
		/// <typeparam name="R">Type of the arguments parameter.</typeparam>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddInstanceRule<T, R>(RuleHandler<T, R> handler, R args, int priority) where R : RuleArgs
		{
			GetInstanceRules(true).AddRule(handler, args, priority);
		}

		#endregion

		#region Adding Per-Type Rules

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		public void AddRule(RuleHandler handler, string propertyName)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, new RuleArgs(propertyName), 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		public void AddRule(RuleHandler handler, string propertyName, string propertyDisplayName)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, new RuleArgs(propertyName, propertyDisplayName), 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddRule(RuleHandler handler, string propertyName, int priority)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, new RuleArgs(propertyName), priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		public void AddRule<T>(RuleHandler<T, RuleArgs> handler, string propertyName)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule<T, RuleArgs>(handler, new RuleArgs(propertyName), 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </para><para>
		/// The propertyName may be used by the method that implements the rule
		/// in order to retrieve the value to be validated. If the rule
		/// implementation is inside the target object then it probably has
		/// direct access to all data. However, if the rule implementation
		/// is outside the target object then it will need to use reflection
		/// or CallByName to dynamically invoke this property to retrieve
		/// the value to be validated.
		/// </para>
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="propertyName">
		/// The property name on the target object where the rule implementation can retrieve
		/// the value to be validated.
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddRule<T>(RuleHandler<T, RuleArgs> handler, string propertyName, int priority)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule<T, RuleArgs>(handler, new RuleArgs(propertyName), priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		public void AddRule(RuleHandler handler, RuleArgs args)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, args, 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddRule(RuleHandler handler, RuleArgs args, int priority)
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, args, priority);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <typeparam name="T">Type of the target object.</typeparam>
		/// <typeparam name="R">Type of the arguments parameter.</typeparam>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		public void AddRule<T, R>(RuleHandler<T, R> handler, R args) where R : RuleArgs
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, args, 0);
		}

		/// <summary>
		/// Adds a rule to the list of rules to be enforced.
		/// </summary>
		/// <remarks>
		/// A rule is implemented by a method which conforms to the 
		/// method signature defined by the RuleHandler delegate.
		/// </remarks>
		/// <typeparam name="T">Type of the target object.</typeparam>
		/// <typeparam name="R">Type of the arguments parameter.</typeparam>
		/// <param name="handler">The method that implements the rule.</param>
		/// <param name="args">
		/// A RuleArgs object specifying the property name and other arguments
		/// passed to the rule method
		/// </param>
		/// <param name="priority">
		/// The priority of the rule, where lower numbers are processed first.
		/// </param>
		public void AddRule<T, R>(RuleHandler<T, R> handler, R args, int priority) where R : RuleArgs
		{
			ValidateHandler(handler);
			GetTypeRules(true).AddRule(handler, args, priority);
		}

		private bool ValidateHandler(RuleHandler handler)
		{
			return ValidateHandler(handler.Method);
		}

		private bool ValidateHandler<T, R>(RuleHandler<T, R> handler) where R : RuleArgs
		{
			return ValidateHandler(handler.Method);
		}

		private bool ValidateHandler(System.Reflection.MethodInfo method)
		{
			if (!method.IsStatic && method.DeclaringType.Equals(_target.GetType()))
				throw new InvalidOperationException(
				  string.Format("{0}: {1}",
				  Resources.InvalidRuleMethodException, method.Name));
			return true;
		}

		#endregion

		#region Adding per-type dependancies

		/// <summary>
		/// Adds a property to the list of dependencies for
		/// the specified property
		/// </summary>
		/// <param name="propertyName">
		/// The name of the property.
		/// </param>
		/// <param name="dependantPropertyName">
		/// The name of the depandent property.
		/// </param>
		/// <remarks>
		/// When rules are checked for propertyName, they will
		/// also be checked for any dependant properties associated
		/// with that property.
		/// </remarks>
		public void AddDependantProperty(string propertyName, string dependantPropertyName)
		{
			GetTypeRules(true).AddDependantProperty(propertyName, dependantPropertyName);
		}

		/// <summary>
		/// Adds a property to the list of dependencies for
		/// the specified property
		/// </summary>
		/// <param name="propertyName">
		/// The name of the property.
		/// </param>
		/// <param name="dependantPropertyName">
		/// The name of the depandent property.
		/// </param>
		/// <param name="isBidirectional">
		/// If <see langword="true"/> then a 
		/// reverse dependancy is also established
		/// from dependantPropertyName to propertyName.
		/// </param>
		/// <remarks>
		/// When rules are checked for propertyName, they will
		/// also be checked for any dependant properties associated
		/// with that property. If isBidirectional is 
		/// <see langword="true"/> then an additional association
		/// is set up so when rules are checked for
		/// dependantPropertyName the rules for propertyName
		/// will also be checked.
		/// </remarks>
		public void AddDependantProperty(string propertyName, string dependantPropertyName, bool isBidirectional)
		{

			ValidationRulesManager mgr = GetTypeRules(true);
			mgr.AddDependantProperty(propertyName, dependantPropertyName);
			if (isBidirectional)
			{
				mgr.AddDependantProperty(dependantPropertyName, propertyName);
			}
		}

		#endregion

		#region Checking Rules

		/// <summary>
		/// Invokes all rule methods associated with
		/// the specified property and any 
		/// dependant properties.
		/// </summary>
		/// <param name="propertyName">The name of the property to validate.</param>
		public void CheckRules(string propertyName)
		{
			// get the rules dictionary
			ValidationRulesManager rules = RulesToCheck;
			if (rules != null)
			{
				// get the rules list for this property
				RulesList rulesList = rules.GetRulesForProperty(propertyName, false);
				if (rulesList != null)
				{
					// get the actual list of rules (sorted by priority)
					List<IRuleMethod> list = rulesList.GetList(true);
					if (list != null)
						CheckRules(list);
					List<string> dependancies = rulesList.GetDependancyList(false);
					if (dependancies != null)
					{
						for (int i = 0; i < dependancies.Count; i++)
						{
							string dependantProperty = dependancies[i];
							CheckRules(rules, dependantProperty);
						}
					}
				}
			}
		}

		private void CheckRules(ValidationRulesManager rules, string propertyName)
		{
			// get the rules list for this property
			RulesList rulesList = rules.GetRulesForProperty(propertyName, false);
			if (rulesList != null)
			{
				// get the actual list of rules (sorted by priority)
				List<IRuleMethod> list = rulesList.GetList(true);
				if (list != null)
					CheckRules(list);
			}
		}

		/// <summary>
		/// Invokes all rule methods for all properties
		/// in the object.
		/// </summary>
		public void CheckRules()
		{
			ValidationRulesManager rules = RulesToCheck;
			if (rules != null)
			{
				foreach (KeyValuePair<string, RulesList> de in rules.RulesDictionary)
					CheckRules(de.Value.GetList(true));
			}
		}

		/// <summary>
		/// Given a list
		/// containing IRuleMethod objects, this
		/// method executes all those rule methods.
		/// </summary>
		private void CheckRules(List<IRuleMethod> list)
		{
			bool previousRuleBroken = false;
			bool shortCircuited = false;

			for (int index = 0; index < list.Count; index++)
			{
				IRuleMethod rule = list[index];
				// see if short-circuiting should kick in
				if (!shortCircuited && (previousRuleBroken && rule.Priority > _processThroughPriority))
					shortCircuited = true;

				if (shortCircuited)
				{
					// we're short-circuited, so just remove
					// all remaining broken rule entries
					BrokenRulesList.Remove(rule);
				}
				else
				{
					// we're not short-circuited, so check rule
					if (rule.Invoke(_target))
					{
						// the rule is not broken
						BrokenRulesList.Remove(rule);
					}
					else
					{
						// the rule is broken
						BrokenRulesList.Add(rule);
						if (rule.RuleArgs.Severity == RuleSeverity.Error)
							previousRuleBroken = true;
					}
					if (rule.RuleArgs.StopProcessing)
						shortCircuited = true;
				}
			}
		}

		#endregion

		#region Status Retrieval

		/// <summary>
		/// Returns a value indicating whether there are any broken rules
		/// at this time. 
		/// </summary>
		/// <returns>A value indicating whether any rules are broken.</returns>
		public bool IsValid
		{
			get { return BrokenRulesList.ErrorCount == 0; }
		}

		/// <summary>
		/// Returns a reference to the readonly collection of broken
		/// business rules.
		/// </summary>
		/// <remarks>
		/// The reference returned points to the actual collection object.
		/// This means that as rules are marked broken or unbroken over time,
		/// the underlying data will change. Because of this, the UI developer
		/// can bind a display directly to this collection to get a dynamic
		/// display of the broken rules at all times.
		/// </remarks>
		/// <returns>A reference to the collection of broken rules.</returns>
		public BrokenRulesCollection GetBrokenRules()
		{
			return BrokenRulesList;
		}

		#endregion

	}
}