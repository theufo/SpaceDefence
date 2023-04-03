using DefaultNamespace;
using Managers;
using Managers.Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Screen = Assets.Scripts.Core.WindowSystem.Screen;

namespace UI.EndGameScreen
{
    public class EndGameScreen : Screen
    {
        [SerializeField] private TMP_Text _winText;

        [SerializeField] private Button _restartButton;

        public override void OnShow()
        {
            base.OnShow();
        
            _restartButton.onClick.AddListener(OnRestartPressed);
        }

        public override void OnHide()
        {
            base.OnHide();
        
            _restartButton.onClick.RemoveAllListeners();
        }

        public void SetInfo(string winnerCharacterName)
        {
            _winText.SetText($"{winnerCharacterName} wins!");
        }

        private void OnRestartPressed()
        {
            BattleManager.Instance.ClearScene();
            GameInitializer.Instance.Restart();
        }
    }
}
