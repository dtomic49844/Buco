using Buco.InfoModels;
using System.Collections.Generic;

namespace Buco.ViewModels
{
    public class LatestEntriesViewModel
    {
        public LatestEntriesViewModel()
        {
            LatestEntries = new HashSet<LatestEntryViewModel>();
            CrudInfo = new CRUDInfo();
        }
        public IEnumerable<LatestEntryViewModel> LatestEntries { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public CRUDInfo CrudInfo { get; set; }
        public string MsgToDisplay { get; set; }
    }
}
