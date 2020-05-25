using CoreImplementation.Database;

namespace Core.Entities
{
    public class MenuItem : IMenuItem
    {
        private string RouterLink { get; }
        private string Title { get; }
        public string Identity => $"That is super menu item called:  {Title} with Router Link : {RouterLink}";
     
    }
}