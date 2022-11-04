using System;
using Microsoft.AspNetCore.Mvc;
using Progress.Sitefinity.AspNetCore.ViewComponents;
using Progress.Sitefinity.Renderer.Forms;

namespace ViewComponents.Captcha
{
    /// <summary>
    /// Test widget with different kind of restrictions for its properties. For more information on creating widgets
    /// visit <see href="https://www.progress.com/documentation/sitefinity-cms/asp.net-core-widget-components">this page.</see>
    /// </summary>
    [SitefinityFormWidget(FormFieldType.Captcha, Title = "Captcha 2", EmptyIcon ="hand-peace-o", Section = WidgetSection.Other)]
    public class CaptchaViewComponent : ViewComponent
    {
        /// <summary>
        /// Invokes the view.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(IViewComponentContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return this.View();
        }
    }

    /// <summary>
    /// The test model for the load tests widget. For a list of supported properties
    /// visit <see href="https://www.progress.com/documentation/sitefinity-cms/autogenerated-field-types">this page.</see>
    /// </summary>
    public class CaptchaEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether a boolean property is true or false.
        /// </summary>
        public string Message { get; set; }
    }
}