// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Wangkanai.Markdown;

public interface IMarkdownPage
{
   ViewContext   ViewContext { get; set; }
   IHtmlContent? BodyContent { get; set; }

   bool    IsLayoutBeingRendered { get; set; }
   string  Path                  { get; set; }
   string? Layout                { get; set; }

   IDictionary<string, RenderAsyncDelegate> PreviousSectionWriters { get; set; }
   IDictionary<string, RenderAsyncDelegate> SectionWriters         { get; }

   Task ExecuteAsync();

   void EnsureRenderedBodyOrSections();
}