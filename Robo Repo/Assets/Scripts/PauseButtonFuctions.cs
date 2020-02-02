using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonFuctions : MonoBehaviour
{
    public GameObject pauseRegion;
    public GameObject healthRegion;
    public GameObject noticeText;
    private void Start()
    {
        noticeText.SetActive(true);
        ResumeButton();
        Invoke("Reminder", 4f);
    }
    void Reminder()
    {
        noticeText.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseRegion.SetActive(!pauseRegion.activeSelf);
        }
    }
    public void ResumeButton()
    {
        pauseRegion.SetActive(false);
    }
    public void ReturnButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
