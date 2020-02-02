using Buco.InfoModels;

namespace Buco.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            CrudInfo = new CRUDInfo();
        }

        public string GoalText { get; set; }
        public string MsgToDisplay { get; set; }
        public CRUDInfo CrudInfo { get; set; }
        public bool GoalReached { get; set; }
    }
}
