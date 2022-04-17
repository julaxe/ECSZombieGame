using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void Instructions()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(4);
        AudioClip darkbackground = Resources.Load<AudioClip>("Sounds/GameMusic");
        SoundManager.PlayMusic(darkbackground);
    }
}
