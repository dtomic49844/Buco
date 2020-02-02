using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buco.ViewModels
{
    public class GetEntriesViewModel
    {
        public SelectList DropDownPets { get; set; }
        public bool Error { get; set; } = false;
    }
}
