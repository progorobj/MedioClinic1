using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Configuration
{
	/// </summary>
	public class XperienceOptions
	{
		/// <summary>
		/// Friendly name of the company.
		/// </summary>
		public string? CompanyName { get; set; }

		/// <summary>
		/// Site code name.
		/// </summary>
		public string? SiteCodeName { get; set; }

		public MediaLibraryOptions? MediaLibraryOptions { get; set; }
	}

	/// <summary>
	/// Media library options.
	/// </summary>
	public class MediaLibraryOptions
	{
		/// <summary>
		/// Image formats allowed in the site.
		/// </summary>
		public string[]? AllowedImageExtensions { get; set; }

		/// <summary>
		/// File size limit.
		/// </summary>
		public long FileSizeLimit { get; set; }
	}
}
