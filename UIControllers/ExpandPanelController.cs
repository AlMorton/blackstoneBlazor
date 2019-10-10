namespace BlazorApp.UIControllers
{
    public interface IExpandPanelController
    {
        bool IsExpanded { get; }

        void ExpandPanel();
    }
    public class ExpandPanelController : IExpandPanelController
    {
        public bool IsExpanded { get; private set; }
        public void ExpandPanel()
        {
            IsExpanded = (IsExpanded == true) ? false : true;
        }
    }
}
