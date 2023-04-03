namespace Controllers.Modules
{
    public interface IModuleController
    {
        public void Activate();
        public void Update(float deltaTime);
    }
}