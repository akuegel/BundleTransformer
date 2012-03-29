﻿namespace BundleTransformer.MicrosoftAjax.Configuration
{
	using System.Configuration;

	/// <summary>
	/// Configuration settings of minifier
	/// </summary>
	public abstract class MinifierSettingsBase : ConfigurationElement
	{
		/// <summary>
		/// Gets or sets whether embedded ASP.NET blocks (&lt;% %&gt;) 
		/// should be recognized and output as is
		/// </summary>
		[ConfigurationProperty("allowEmbeddedAspNetBlocks", DefaultValue = false)]
		public bool AllowEmbeddedAspNetBlocks
		{
			get { return (bool)this["allowEmbeddedAspNetBlocks"]; }
			set { this["allowEmbeddedAspNetBlocks"] = value; }
		}

		/// <summary>
		/// Gets or sets a string representation of the list of 
		/// debug lookups, comma-separated
		/// </summary>
		[ConfigurationProperty("ignoreErrorList", DefaultValue = "")]
		public string IgnoreErrorList
		{
			get { return (string)this["ignoreErrorList"]; }
			set { this["ignoreErrorList"] = value; }
		}

		/// <summary>
		/// Gets or sets a number of spaces per indent level when in 
		/// MultipleLines output mode
		/// </summary>
		[ConfigurationProperty("indentSize", DefaultValue = 4)]
		public int IndentSize
		{
			get { return (int)this["indentSize"]; }
			set { this["indentSize"] = value; }
		}

		/// <summary>
		/// Gets or sets a output mode:
		/// SingleLine - output all code on a single line
		/// MultipleLines - break the output into multiple lines to be more human-readable
		/// </summary>
		[ConfigurationProperty("outputMode", DefaultValue = OutputMode.SingleLine)]
		public OutputMode OutputMode
		{
			get { return (OutputMode)this["outputMode"]; }
			set { this["outputMode"] = value; }
		}

		/// <summary>
		/// Gets or sets a string representation of the list 
		/// of names defined for the preprocessor, comma-separated
		/// </summary>
		[ConfigurationProperty("preprocessorDefineList", DefaultValue = "")]
		public string PreprocessorDefineList
		{
			get { return (string)this["preprocessorDefineList"]; }
			set { this["preprocessorDefineList"] = value; }
		}

		/// <summary>
		/// Gets or sets a flag for whether to add a semicolon 
		/// at the end of the parsed code
		/// </summary>
		[ConfigurationProperty("termSemicolons", DefaultValue = false)]
		public bool TermSemicolons
		{
			get { return (bool)this["termSemicolons"]; }
			set { this["termSemicolons"] = value; }
		}

		/// <summary>
		/// Gets or sets a severity level of errors
		///		0 - syntax error
		///		1 - the programmer probably did not intend to do this
		///		2 - this can lead to problems in the future
		///		3 - this can lead to performance problems
		///		4 - this is just not right
		/// </summary>
		[ConfigurationProperty("severity", DefaultValue = 0)]
		[IntegerValidator(MinValue = 0, MaxValue = 4, ExcludeRange = false)]
		public int Severity
		{
			get { return (int)this["severity"]; }
			set { this["severity"] = value; }
		}
	}
}