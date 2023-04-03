
using Controllers;

namespace Configs
{
    public interface IModuleConfig
    {
        public ModuleType ModuleType { get; set; }
        public string Description { get; set; }
        
        public void Setup(BattleStatsController battleStatsController)
        {
        }
    }
}