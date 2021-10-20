using Core.Configuration;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XperienceAdapter.Models;
using XperienceAdapter.Repositories;

namespace MedioClinic.Components.Widgets
{
	public class ImageViewComponent : ViewComponent
	{
		private readonly IOptionsMonitor<XperienceOptions> _optionsMonitor;

		private readonly IMediaFileRepository _mediaFileRepository;

		public ImageViewComponent(IOptionsMonitor<XperienceOptions> optionsMonitor, IMediaFileRepository mediaFileRepository)
		{
			_optionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
			_mediaFileRepository = mediaFileRepository ?? throw new ArgumentNullException(nameof(mediaFileRepository));
		}

		public async Task<IViewComponentResult> InvokeAsync(ComponentViewModel<ImageProperties> componentViewModel)
		{
			var properties = componentViewModel?.Properties;
			var imageGuid = properties?.ImageGuid;
			MediaLibraryFile? mediaFile = default;

			if (imageGuid.HasValue == true && !string.IsNullOrEmpty(properties?.MediaLibraryName) && componentViewModel != null)
			{
				mediaFile = await _mediaFileRepository.GetMediaFileAsync(imageGuid.Value);
				componentViewModel.CacheDependencies.CacheKeys = new List<string>() { $"mediafile|{mediaFile?.Guid}" };
			}

			var model = new ImageViewModel
			{
				PageId = componentViewModel?.Page?.DocumentID,
				HasImage = mediaFile?.MediaFileUrl?.IsImage == true,
				MediaLibraryFile = mediaFile,
			};

			model.MediaLibraryViewModel.AllowedFileExtensions = _optionsMonitor.CurrentValue?.MediaLibraryOptions?.AllowedImageExtensions.ToHashSet();
			model.MediaLibraryViewModel.LibraryName = properties?.MediaLibraryName;

			return View("~/Components/Widgets/_Image.cshtml", model);
		}
	}
}
