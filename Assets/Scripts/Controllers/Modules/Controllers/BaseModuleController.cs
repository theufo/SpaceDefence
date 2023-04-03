using Configs;

namespace Controllers.Modules
{
    public class BaseModuleController : IModuleController
    {
        protected IModuleConfig ModuleView;
        protected BattleStatsController _battleStatsController;

        public BaseModuleController(ModuleView moduleView, BattleStatsController battleStatsController)
        {
            ModuleView = moduleView.GetConfig();
            _battleStatsController = battleStatsController;
            ModuleView.Setup(battleStatsController);
        }

        public virtual void Activate()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            
        }
    }
}