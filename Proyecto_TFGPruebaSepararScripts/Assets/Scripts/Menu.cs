using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject firstButtonSelected;

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
}
