using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Menus
{
    public class MenuQuit : MonoBehaviour
    {
        public void QuitGame()
        {
            #if UNITY_EDITOR
                     UnityEditor.EditorApplication.isPlaying = false;
            #else
                     Application.Quit();
            #endif
        }
    }
}
