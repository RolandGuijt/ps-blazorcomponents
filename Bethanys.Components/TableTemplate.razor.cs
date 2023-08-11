using Microsoft.AspNetCore.Components;

namespace Bethanys.Components
{
    public partial class TableTemplate<TItem>
        where TItem: ITableModel
    {
        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public RenderFragment<TItem> ChildTemplate { get; set; }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public bool IsSmall { get; set; }
    }
}