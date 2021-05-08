using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public Text numberText;
    public Text message;

    private string mensaje1 = "Random dungeon generation";
    private string mensaje2 = "Bulding map & lights"; 
    private string mensaje3 = "Setting the game up";
    private string mensaje4 = "Completed";


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Time.deltaTime * 100 / 11;
        numberText.text = slider.value.ToString() + "%";

        if (slider.value < 50)
        {
            message.text = mensaje1;
        }
        else if (slider.value < 75)
        {
            message.text = mensaje2;
        }
        else if (slider.value < 100)
        {
            message.text = mensaje3;
        }
        else 
        {
            message.text = mensaje4;
        }
    }

}
