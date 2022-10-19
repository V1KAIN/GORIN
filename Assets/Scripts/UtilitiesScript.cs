using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilitiesScript : MonoBehaviour
{
    #region Scene Managment

    public static void GoToNextScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    public static void GoToPreviousScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); }
    public static void GoToIndexScene(int sceneIndex) { SceneManager.LoadScene(sceneIndex);}
    public static void GoToSceneWithName(string sceneName) { SceneManager.LoadScene(sceneName);}

    #endregion

    #region Game Utility

    public static void QuitGame()
    {
        SaveGameFiles();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
#endif
    }
    
    public static void SaveGameFiles(){}

    #endregion
}
