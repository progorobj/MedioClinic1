using CMS.DocumentEngine;
using Core.Configuration;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using MedioClinic.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XperienceAdapter.Localization;
using XperienceAdapter.Models;
using XperienceAdapter.Repositories;

[assembly: RegisterPageRoute(CMS.DocumentEngine.Types.MedioClinic.LandingPage.CLASS_NAME, typeof(LandingPageController))]
namespace MedioClinic.Controllers
{
    public class LandingPageController : BaseController
    {
        private readonly IPageDataContextRetriever _pageDataContextRetriever;

        private readonly IPageRepository<BasePage, TreeNode> _landingPageRepository;

        public LandingPageController(
            ILogger<LandingPageController> logger,
            IOptionsMonitor<XperienceOptions> optionsMonitor,
            IStringLocalizer<SharedResource> stringLocalizer,
            IPageDataContextRetriever pageDataContextRetriever,
            IPageRepository<BasePage, TreeNode> landingPageRepository)
            : base(logger, optionsMonitor, stringLocalizer)
        {
            _pageDataContextRetriever = pageDataContextRetriever ?? throw new ArgumentNullException(nameof(pageDataContextRetriever));
            _landingPageRepository = landingPageRepository ?? throw new ArgumentNullException(nameof(landingPageRepository));
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            if (_pageDataContextRetriever.TryRetrieve<CMS.DocumentEngine.Types.MedioClinic.LandingPage>(out var pageDataContext)
                && pageDataContext.Page != null)
            {
                var landingPagePath = pageDataContext.Page.NodeAliasPath;

                if (!string.IsNullOrEmpty(landingPagePath))
                {
                    var landingPage = (await _landingPageRepository.GetPagesInCurrentCultureAsync(
                        cancellationToken,
                        filter => filter
                            .Path(landingPagePath, PathTypeEnum.Single)
                            .TopN(1),
                        buildCacheAction: cache => cache
                            .Key($"{nameof(LandingPageController)}|Page|{landingPagePath}")
                            .Dependencies((_, builder) => builder
                                .PageType(CMS.DocumentEngine.Types.MedioClinic.LandingPage.CLASS_NAME)
                                .PagePath(landingPagePath, PathTypeEnum.Single))))
                            .FirstOrDefault();

                    if (landingPage != null)
                    {
                        var viewModel = GetPageViewModel(pageDataContext.Metadata, landingPage);

                        return View(viewModel);
                    }

                }
            }

            return NotFound();
        }
    }
}
