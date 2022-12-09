using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("BeginCutscene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
