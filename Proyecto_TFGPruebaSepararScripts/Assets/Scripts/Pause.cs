using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    //public GameObject firstButtonSelected;
    public GameObject healthBar;
    public GameObject pauseMenu;
    public AudioSource audioSource;
    public bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            if (!gamePaused) 
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
            
        }
    }

    public void PauseGame()
    {
        audioSource.Pause();
        healthBar.SetActive(false);
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(pauseMenu.GetComponent<Menu>().firstButtonSelected);
        Time.timeScale = 0f;
        gamePaused = true;
        pauseMenu.GetComponent<Menu>().gamePaused = true;
    }

    public void ResumeGame()
    {
        audioSource.Play();
        healthBar.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        pauseMenu.GetComponent<Menu>().gamePaused = false;
    }
}
