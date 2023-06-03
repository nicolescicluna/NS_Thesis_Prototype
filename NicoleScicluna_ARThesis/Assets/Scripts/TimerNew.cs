using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerNew : MonoBehaviour
{
    
    private  float countDown = 30.0f;
    private float timer;
    TextMeshProUGUI timerText;
    Slider timerSlider;
    Image fillImage;
    [SerializeField] GameObject panel;

    private string error = "";
    
    public Color32 normalFillColor;
    public Color32 warningFillColor;
    
    TextMeshProUGUI gameOverText;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = countDown;
        panel.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerText = GameObject.FindGameObjectWithTag("TimerText")?.GetComponent<TextMeshProUGUI>();
        timerSlider = GameObject.FindGameObjectWithTag("TimerSlider")?.GetComponent<Slider>();
        
        //shootTrackedComponent.enabled = true;
        
        if (timerSlider != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                panel.SetActive(true);
                
                gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<TextMeshProUGUI>();
                gameOverText.gameObject.SetActive(true);
                //shootTrackedComponent.enabled = false;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("spider");
                foreach (GameObject enemy in enemies)
                     Destroy(enemy); // destroy all spiders in the scene
                
                
            }

            if (timerText == null)
            {
                error = "TimerTextError";
            }
            else
            {
                timerText.text = timer.ToString("f0") +"s";
            }

            if (timerSlider == null)
            {
                error = "TimerSliderErr";
            }
            else
            {
                timerSlider.maxValue = countDown;
                timerSlider.value = timer;
                fillImage.color = normalFillColor;
            }
        }
    }
    
   /* public void OnGUI()
    {
      
        GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
        errorStyle.alignment = TextAnchor.MiddleCenter;
        errorStyle.fontSize = 24;
        errorStyle.normal.textColor = Color.red;

        Vector2 labelSize = new Vector2(600, 50);
        Rect labelRect = new Rect((Screen.width - labelSize.x) / 2, (Screen.height - labelSize.y) / 2, labelSize.x,
            labelSize.y);
        GUI.Label(labelRect, timer.ToString() +"\n" +error,errorStyle);
        
    } */
}
