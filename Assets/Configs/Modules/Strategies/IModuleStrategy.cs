using DefaultNamespace.Controllers;

namespace Configs
{
    public interface IModuleStrategy
    {
        public ModuleType ModuleType { get; set; }
        public string Description { get; set; }

        void StartModule();

        void Activate();
        void Setup(BattleStatsController battleStatsController);
    }
}