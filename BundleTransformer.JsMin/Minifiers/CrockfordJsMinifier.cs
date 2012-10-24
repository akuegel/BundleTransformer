﻿namespace BundleTransformer.JsMin.Minifiers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Core.Assets;
	using Core.Minifiers;
	using CoreStrings = Core.Resources.Strings;

	using DouglasCrockford;

	/// <summary>
	/// Minifier, which produces minifiction of JS-code 
	/// by using C# port of Douglas Crockford's JSMin (version of May 22 2007)
	/// </summary>
	public sealed class CrockfordJsMinifier : IMinifier
	{
		/// <summary>
		/// Name of minifier
		/// </summary>
		const string MINIFIER_NAME = "JSMin Minifier";

		/// <summary>
		/// Name of code type
		/// </summary>
		const string CODE_TYPE = "JS";

		/// <summary>
		/// Produces code minifiction of JS-assets by using C# port of 
		/// Douglas Crockford's JSMin (version of May 22 2007)
		/// </summary>
		/// <param name="assets">Set of JS-assets</param>
		/// <returns>Set of JS-assets with minified text content</returns>
		public IList<IAsset> Minify(IList<IAsset> assets)
		{
			if (assets == null)
			{
				throw new ArgumentException(CoreStrings.Common_ValueIsEmpty, "assets");
			}

			if (assets.Count == 0)
			{
				return assets;
			}

			var assetsToProcessing = assets.Where(a => a.IsScript && !a.Minified).ToList();
			if (assetsToProcessing.Count == 0)
			{
				return assets;
			}

			var jsMin = new JavaScriptMinifier();

			foreach (var asset in assetsToProcessing)
			{
				string newContent;
				string assetPath = asset.Path;
				
				try
				{
					newContent = jsMin.Minify(asset.Content);
				}
				catch (Exception e)
				{
					throw new AssetMinificationException(
						string.Format(CoreStrings.Minifiers_MinificationFailed, 
							CODE_TYPE, assetPath, MINIFIER_NAME, e.Message));
				}

				asset.Content = newContent;
				asset.Minified = true;
			}

			return assets;
		}
	}
}