﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

using MedioClinic.Components;
using MedioClinic.Components.InlineEditors;
using MedioClinic.Components.Sections;
using MedioClinic.Components.Widgets;


[assembly: RegisterSection(
    ComponentIdentifiers.SingleColumnSection,
    "{$" + ComponentIdentifiers.SingleColumnSection + ".Title$}",
    customViewName: "~/Components/Sections/_SingleColumn.cshtml",
    Description = "{$" + ComponentIdentifiers.SingleColumnSection + ".Description$}",
    IconClass = "icon-square")]

[assembly: RegisterSection(
    ComponentIdentifiers.TwoColumnSection,
    "{$" + ComponentIdentifiers.TwoColumnSection + ".Title$}",
    propertiesType: typeof(TwoColumnProperties),
    customViewName: "~/Components/Sections/_TwoColumn.cshtml",
    Description = "{$" + ComponentIdentifiers.TwoColumnSection + ".Description$}",
    IconClass = "icon-l-cols-2")]


[assembly: RegisterWidget(
    ComponentIdentifiers.TextWidget,
    "{$" + ComponentIdentifiers.TextWidget + ".Title$}",
    typeof(DocumentFormat.OpenXml.Drawing.Charts.TextProperties),
    customViewName: "~/Components/Widgets/_Text.cshtml",
    AllowCache = true,
    Description = "{$" + ComponentIdentifiers.TextWidget + ".Description$}",
    IconClass = "icon-l-text")]

[assembly: RegisterWidget(
    ComponentIdentifiers.ImageWidget,
    typeof(ImageViewComponent),
    "{$" + ComponentIdentifiers.ImageWidget + ".Title$}",
    typeof(ImageProperties),
    AllowCache = true,
    Description = "{$" + ComponentIdentifiers.ImageWidget + ".Description$}",
    IconClass = "icon-picture")]

[assembly: RegisterPageBuilderLocalizationResource(typeof(ImageUploaderResource), "en-US", "es-ES")]