using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Transform PlayButton;

   public void Play(float scale)
    {
        PlayButton.localScale = new Vector3(1, scale, 1);
    }

    public void Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
