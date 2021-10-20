using CMS.Base;
using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XperienceAdapter.Models;

namespace XperienceAdapter.Repositories
{
	/// <summary>
	/// Stores information about media library files.
	/// </summary>
	public interface IMediaFileRepository : IRepository<MediaLibraryFile>
	{
		/// <summary>
		/// Gets media files by folder path.
		/// </summary>
		/// <param name="mediaLibraryName">Media library code name.</param>
		/// <param name="path">Folder path.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <returns>File DTOs.</returns>
		Task<IEnumerable<MediaLibraryFile>> GetMediaFilesAsync(string mediaLibraryName, string path, CancellationToken? cancellationToken = default);

		/// <summary>
		/// Gets a media file.
		/// </summary>
		/// <param name="fileGuid">File GUID.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		/// <returns>Media file DTO.</returns>
		Task<MediaLibraryFile?> GetMediaFileAsync(Guid fileGuid, CancellationToken? cancellationToken = default);


		/// <summary>
		/// Adds a new media file.
		/// </summary>
		/// <param name="uploadedFile">Uploaded file.</param>
		/// <param name="mediaLibraryName">Media library code name.</param>
		/// <param name="libraryFolderPath">Folder path.</param>
		/// <param name="checkPermisions">Indicates if permissions shall be verified.</param>
		/// <returns>File GUID.</returns>
		Task<Guid> AddMediaFileAsync(IUploadedFile uploadedFile,
									 string mediaLibraryName,
									 string? libraryFolderPath = default,
									 bool checkPermisions = default,
									 CancellationToken? cancellationToken = default);


	}
}
