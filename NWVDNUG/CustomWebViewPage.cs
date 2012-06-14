using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace NWVDNUG
{
    public abstract class CustomWebViewPage : WebViewPage
    {
        public HelperResult RenderSection(string name, Func<dynamic, HelperResult> defaultContents)
        {
            if (this.IsSectionDefined(name))
            {
                return this.RenderSection(name);
            }
            return defaultContents(null);
        }

        public HelperResult RenderSection(string name, IHtmlString defaultContents)
        {
            if (this.IsSectionDefined(name))
            {
                return this.RenderSection(name);
            }
            
            var result = new HelperResult((x) => x.Write(defaultContents.ToString()));
            return this.RenderSection(name, (x) => result);

        }
    }

    public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel>
    {
        public HelperResult RenderSection(string name, Func<dynamic, HelperResult> defaultContents)
        {
            if (this.IsSectionDefined(name))
            {
                return this.RenderSection(name);
            }
            return defaultContents(null);
        }

        public HelperResult RenderSection(string name, IHtmlString defaultContents)
        {
            if (this.IsSectionDefined(name))
            {
                return this.RenderSection(name);
            }

            var result = new HelperResult((x) => x.Write(defaultContents.ToString()));
            return this.RenderSection(name, (x) => result);

        }
    }
}
