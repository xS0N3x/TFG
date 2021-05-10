using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject firstButtonSelected;
    public Pause pauseScript;

    public GameObject healthBar;
    public GameObject pauseMenu;
    public bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton() 
    {
        Application.Quit();
    }

    public void ResumeButton() 
    {
        healthBar.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void MenuButton() 
    {
        SceneManager.LoadScene(0);
    }
}
