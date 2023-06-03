using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerSlider : MonoBehaviour
{

    [SerializeField] GameObject panel;
    Slider timerSlider;
    TextMeshProUGUI timerText;
    private float timer;

    public float gameTime = 30.0f;

    Image fillImage;
    public Color32 normalFillColor;
    public Color32 warningFillColor;
    public float warningLimit;  // as a percentage
    private string error = "";

    public bool stopTimer;

    TextMeshProUGUI gameOverText;

    void Start()
    {
        panel.SetActive(false);
        timer = gameTime;
        stopTimer = false;
        gameObject.GetComponent<Shooting>().enabled = true;

        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false);

        timerSlider = GameObject.FindGameObjectWithTag("TimerSlider").GetComponent<Slider>();
        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();

        fillImage = GameObject.FindGameObjectWithTag("SliderFill").GetComponent<Image>();

        if (timerSlider == null)
        {
            error = "TimerSliderErr";
        }
        else
        {
            timerSlider.maxValue = gameTime;
            timerSlider.value = timer;
            fillImage.color = normalFillColor;
        }
       // timerSlider.maxValue = gameTime;
        //timerSlider.value = gameTime;
       // fillImage.color = normalFillColor;



    }

   
    void Update()
    {
        gameTime -= Time.deltaTime;

        string textTime = "Time left: " + gameTime.ToString("f0") + "s";

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = gameTime;
        }

        if (timerSlider.value < ((warningLimit/100)* timerSlider.maxValue))
        {
            fillImage.color = warningFillColor;
        }

        if(gameTime <= 0 && stopTimer == false)  // On Game over
        {
            stopTimer = true;
            gameObject.GetComponent<Shooting>().enabled = false;
            Destroy(timerSlider.gameObject);
            panel.SetActive(true);
            //gameOverText.gameObject.SetActive(true);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("spider");
            foreach (GameObject enemy in enemies)
                Destroy(enemy); // destroy all spiders in the scene

        }
        
    }
}


