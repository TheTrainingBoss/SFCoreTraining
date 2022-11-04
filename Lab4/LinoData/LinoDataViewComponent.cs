using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Progress.Sitefinity.AspNetCore.Web;
using Progress.Sitefinity.AspNetCore;
using Newtonsoft.Json.Linq;
using SFNov2022Core.ViewModels;

namespace ViewComponents.LinoData
{
    /// <summary>
    /// Test widget with different kind of restrictions for its properties. For more information on creating widgets
    /// visit <see href="https://www.progress.com/documentation/sitefinity-cms/asp.net-core-widget-components">this page.</see>
    /// </summary>
    [SitefinityWidget(Category =WidgetCategory.Content, Title = "Lino Data", EmptyIcon ="hand-peace-o")]
    public class LinoDataViewComponent : ViewComponent
    {
        private IHttpClientFactory httpClientFactory;
        private IRequestContext requestContext;

        public LinoDataViewComponent(IHttpClientFactory httpClientFactory, IRequestContext requestContext)  
        {
            this.httpClientFactory = httpClientFactory;
            this.requestContext = requestContext;
        }


        /// <summary>
        /// Invokes the view.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext context)
        {
            var client = this.httpClientFactory.CreateClient(Constants.HttpClients.ODataHttpClientName);
            var newsItemsResponseMessage = await client.GetAsync($"newsitems?sf_site={this.requestContext.Site.Id}&sf_culture={this.requestContext.Culture}").ConfigureAwait(true);
            newsItemsResponseMessage.EnsureSuccessStatusCode();
            var responseJson = await newsItemsResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);
            var itemArray = JObject.Parse(responseJson)["value"] as JArray;
            var items = itemArray.ToObject<NewsViewModel[]>();

            return this.View(items);

        }
    }
}
