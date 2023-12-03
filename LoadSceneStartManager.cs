using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStartManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("GameExists", "no");
    }
}
