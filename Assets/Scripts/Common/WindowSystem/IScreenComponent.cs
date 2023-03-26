namespace Assets.Scripts.Core.WindowSystem
{
    public interface IScreenComponent
    {
        void SetInfo(Screen screen);
        void OnShow();
        void OnHide();
    }
}