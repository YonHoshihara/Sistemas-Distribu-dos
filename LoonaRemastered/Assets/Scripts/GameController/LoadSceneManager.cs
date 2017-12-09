using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//Isabella
public class LoadSceneManager : MonoBehaviour {

    public void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
