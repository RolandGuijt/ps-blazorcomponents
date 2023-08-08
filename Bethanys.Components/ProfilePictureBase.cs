using Microsoft.AspNetCore.Components;

namespace Bethanys.Components
{
    public class ProfilePictureBase: ComponentBase
    {
        protected string CssClass { get; set; } = "circle";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void ProfileClick()
        {
            CssClass = CssClass == "circle" ? "" : "circle";
        }
    }
}
