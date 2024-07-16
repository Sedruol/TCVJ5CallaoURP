using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void RepeatScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Change(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}