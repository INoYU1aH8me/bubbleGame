using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LoadRandomGame()
    {
        SceneManager.LoadScene("RandomGame");
    }
    public void LoadCampaignGame()
    {
        SceneManager.LoadScene("CampaignGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
