namespace Buco.InfoModels
{
    public class CRUDInfo
    {
        public CRUDInfo()
        {
            Added = false;
            Deleted = false;
            Updated = false;
            Error = false;
        }

        public bool Added { get; set; }
        public bool Deleted { get; set; }
        public bool Updated { get; set; }
        public bool Error { get; set; }
    }
}
