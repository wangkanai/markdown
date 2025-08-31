// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;

namespace Wangkanai.Markdown.ApplicationModels;

public class MarkdownRouteModel
{
   public MarkdownRouteModel(string relativePath, string viewEnginePath)
      : this(relativePath, viewEnginePath, null) { }

   public MarkdownRouteModel(string relativePath, string viewEnginePath, string? areaName)
   {
      RelativePath   = relativePath.ThrowIfNull();
      ViewEnginePath = viewEnginePath.ThrowIfNull();
      AreaName       = areaName;

      Properties  = new Dictionary<object, object?>();
      Selectors   = new List<SelectorModel>();
      RouteValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
   }

   public MarkdownRouteModel(MarkdownRouteModel other)
   {
      other.ThrowIfNull();

      RelativePath              = other.RelativePath;
      ViewEnginePath            = other.ViewEnginePath;
      AreaName                  = other.AreaName;
      RouteParameterTransformer = other.RouteParameterTransformer;

      Properties  = new Dictionary<object, object?>(other.Properties);
      Selectors   = new List<SelectorModel>(other.Selectors.Select(m => new SelectorModel(m)));
      RouteValues = new Dictionary<string, string>(other.RouteValues, StringComparer.OrdinalIgnoreCase);
   }

   public string  RelativePath   { get; }
   public string  ViewEnginePath { get; }
   public string? AreaName       { get; }

   public IDictionary<object, object?> Properties  { get; }
   public IDictionary<string, string>  RouteValues { get; }

   public IList<SelectorModel> Selectors { get; }

   public IOutboundParameterTransformer? RouteParameterTransformer { get; set; }
}