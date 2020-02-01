using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonFunctions : MonoBehaviour
{
    public GameObject menuRegion;
    public GameObject creditsRegion;
    private void Start()
    {
        BackButton();
    }
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void CreditsButton()
    {
        creditsRegion.SetActive(true);
        menuRegion.SetActive(false);
    }
    public void BackButton()
    {
        menuRegion.SetActive(true);
        creditsRegion.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
