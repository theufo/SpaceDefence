namespace Assets.Scripts.Core.WindowSystem
{
	public interface IScreen
    {
        ScreenState ScreenState { get; set; }
        void OnShow();
        void OnHide();
    }
}
