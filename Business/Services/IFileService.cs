using Business.Models;
using Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface IFileService : IService
	{
		/// <summary>
		/// Validates a form file and converts it into <see cref="UploadedFile"/>.
		/// </summary>
		/// <param name="formFile">Input file.</param>
		/// <param name="permittedExtensions">Permitted file name extensions.</param>
		/// <param name="sizeLimit">File size limit.</param>
		/// <returns>Uploaded file.</returns>
		Task<ProcessedFile> ProcessFormFileAsync(IFormFile formFile, string[] permittedExtensions, long sizeLimit);

		/// <summary>
		/// Sanitizes a file name and extension.
		/// </summary>
		/// <param name="completeFileName">Input file name.</param>
		/// <returns>Name and extension.</returns>
		(string Name, string Extension) GetSafeFileName(string completeFileName);
	}
}
