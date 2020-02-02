using Buco.InfoModels;
using System.Collections.Generic;

namespace Buco.ViewModels
{
    public class PetsViewModel
    {
        public PetsViewModel()
        {
            Pets = new HashSet<PetViewModel>();
            CrudInfo = new CRUDInfo();
        }

        public CRUDInfo CrudInfo { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<PetViewModel> Pets { get; set; }
    }
}
