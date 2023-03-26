using UnityEngine;

namespace DefaultNamespace.Utils
{
    public static class UIUtils
    {
        public static void EnableMouse(bool enable)
        {
            Cursor.visible = enable;
            Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}