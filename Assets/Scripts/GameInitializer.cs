using System;
using Assets.Scripts.Core.WindowSystem;
using DefaultNamespace.Managers;
using DefaultNamespace.UI.BattleScreen;
using DefaultNamespace.Utils;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameInitializer : Common.Singleton<GameInitializer>
    {
        public GameState GameState { get; private set; }

        private void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(gameObject);
        }
        
        public void Start()
        {
            GameState = GameState.Setup;

            SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
            SceneUtils.ChangeScene(SceneUtils.HangarScene);
        }

        public void StartBattle()
        {
            SceneUtils.ChangeScene(SceneUtils.BattleScene);
        }

        public void Restart()
        {
            WindowSystem.Hide<EndGameScreen>();
            SceneUtils.ChangeScene(SceneUtils.HangarScene);
        }

        private void SceneManagerOnsceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == SceneUtils.HangarScene)
            {
                GameState = GameState.Hangar;
                
                HangarManager.Instance.Init();
            }
            else if (scene.name == SceneUtils.BattleScene)
            {
                GameState = GameState.Battle;
                
                BattleManager.Instance.Init();
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
        }
    }

    public enum GameState
    {
        Setup,
        Hangar,
        Battle
    }
}