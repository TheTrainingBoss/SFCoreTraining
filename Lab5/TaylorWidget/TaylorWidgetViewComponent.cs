using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using  Progress.Sitefinity.RestSdk;
using  Progress.Sitefinity.RestSdk.Dto;

namespace ViewComponents.TaylorWidget
{
    /// <summary>
    /// Test widget with different kind of restrictions for its properties. For more information on creating widgets
    /// visit <see href="https://www.progress.com/documentation/sitefinity-cms/asp.net-core-widget-components">this page.</see>
    /// </summary>
    [SitefinityWidget]
    public class TaylorWidgetViewComponent : ViewComponent
    {
        private readonly IRestClient restClient;
        
        public TaylorWidgetViewComponent(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        /// <summary>
        /// Invokes the view.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(IViewComponentContext<TaylorWidgetEntity> context)
        {
            var viewModels = await GetItems(context.Entity);

            return this.View(viewModels);
        }
        public async Task<IList<SdkItem>> GetItems(TaylorWidgetEntity entity)
        {
            var getAllArgs = new GetAllArgs()
            {
                Type = RestClientContentTypes.News
            };

            getAllArgs.Fields.Add("Title");
            if (!entity.HideImage)
            {
                getAllArgs.Fields.Add("Thumbnail");
            }

            //getAllArgs.Filter = $"Status eq Published and Visible eq true and ParentId eq {entity.ParentId}";
            

            var response = await this.restClient.GetItems<SdkItem>(getAllArgs);
            return response.Items;
        }
    }

    /// <summary>
    /// The test model for the load tests widget. For a list of supported properties
    /// visit <see href="https://www.progress.com/documentation/sitefinity-cms/autogenerated-field-types">this page.</see>
    /// </summary>
    public class TaylorWidgetEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether a boolean property is true or false.
        /// </summary>
        [DisplayName("Hide Related Image")]
        public bool HideImage { get; set; }
        
    }
}