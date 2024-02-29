using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public void GantiScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void Keluar()
    {
        Application.Quit();
    }
}
