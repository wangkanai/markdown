// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace Wangkanai.Markdown;

public readonly struct MarkdownPageFactoryResult
{
   [MemberNotNullWhen(true, nameof(MarkdownPageFactory))]
   public bool Success => MarkdownPageFactory != null;

   public Func<IMarkdownPage>?    MarkdownPageFactory { get; }
   public CompiledViewDescriptor? ViewDescriptor      { get; }

   public MarkdownPageFactoryResult(
      CompiledViewDescriptor viewDescriptor,
      Func<IMarkdownPage>?   razorPageFactory)
   {
      ViewDescriptor      = viewDescriptor.ThrowIfNull();
      MarkdownPageFactory = razorPageFactory;
   }
}