using UnityEngine.SceneManagement;

namespace DefaultNamespace.Utils
{
    public static class SceneUtils
    {
        public static string HangarScene = "HangarScene";
        public static string BattleScene = "BattleScene";

        public static void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}