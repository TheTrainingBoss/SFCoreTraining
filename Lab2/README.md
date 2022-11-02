# SFCoreTraining Lab 2

### Every layout file must have a defined section named Scripts.
### Every layout file must have a reference to the taghelpers defined in the namespace Progress.Sitefinity.AspNetCore like so:
```
  @addTagHelper *, Progress.Sitefinity.AspNetCore
```
### Every layout must have a model defined like so:
```
  @model Progress.Sitefinity.AspNetCore.Models.PageModel
```
### Every layout can render the SEO metadata from Sitefinity by using the custom method:
```
  @Html.RenderSeoMeta(this.Model)
```
