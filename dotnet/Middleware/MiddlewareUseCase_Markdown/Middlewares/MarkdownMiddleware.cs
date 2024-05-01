using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownSharp;

namespace MiddlewareUseCase_Markdown.Middlewares;

public class MarkdownMiddleware
{
  private readonly RequestDelegate _next;
  private readonly IWebHostEnvironment _hostEnv;
  public MarkdownMiddleware(RequestDelegate next, IWebHostEnvironment hostEnv)
  {
    _next = next;
    _hostEnv = hostEnv;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    string path = context.Request.Path.ToString();
    if (path.EndsWith(".md", true, null))
    {
      await _next.Invoke(context);
      return;
    }

    var wwwwRootFile = _hostEnv.WebRootFileProvider.GetFileInfo(path);

    if (wwwwRootFile.Exists == false)
    {
      await _next.Invoke(context);
      return;
    }
    using var stream = wwwwRootFile.CreateReadStream();
    Ude.CharsetDetector cdet = new Ude.CharsetDetector();
    cdet.Feed(stream);
    cdet.DataEnd();
    string charset = cdet.Charset ?? "UTF-8";
    stream.Position = 0;
    using StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(charset));
    string mdText = await reader.ReadToEndAsync();
    Markdown markdown = new Markdown();
    string htmlText = markdown.Transform(mdText);
    context.Response.ContentType = "text/html;charset=UTF-8";
    await context.Response.WriteAsync(context.Response.ContentType);
  }
}
