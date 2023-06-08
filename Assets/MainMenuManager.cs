using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public GameObject tip1;
    public GameObject tip2;
    public GameObject tip3;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HowToPlay()
    {
        tip1.SetActive(!tip1.activeSelf);
        tip2.SetActive(!tip2.activeSelf);
        tip3.SetActive(!tip3.activeSelf);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SetNormal()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }
    public void SetHard()
    {
        PlayerPrefs.SetInt("Difficulty", 1);

    }
}
