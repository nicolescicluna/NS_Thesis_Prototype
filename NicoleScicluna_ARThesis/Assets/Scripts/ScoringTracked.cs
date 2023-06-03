using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoringTracked : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameObject scoreBoardUI;
    public static int score;

    private string errorMessage = "";
    
    public void Update()
    {
        ShootTracked shootTrackedComponent = GameObject.Find("ShootScript").GetComponent<ShootTracked>();

        if (shootTrackedComponent == null)
        {
            errorMessage = "Error.ShootTracked component not found!";
            return;
        }
        else
        {
            shootTrackedComponent.enabled = true;
        }
        
        scoreBoardUI = GameObject.FindGameObjectWithTag("ScoreCanvas");
        scoreText = GameObject.FindGameObjectWithTag("ScoreOnBannerTwo")?.GetComponent<TextMeshProUGUI>();

        if (scoreBoardUI == null || scoreText == null)
        {
            errorMessage = "Error: Marker Image not found!";
        }
        else
        {
            errorMessage = "";
            scoreText.text = "Score: " + score.ToString();
        }
    }

   public void OnGUI()
    {
        if (!string.IsNullOrEmpty(errorMessage))
        {
            GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
            errorStyle.alignment = TextAnchor.MiddleCenter;
            errorStyle.fontSize = 40;
            errorStyle.normal.textColor = Color.red;

            Vector2 labelSize = new Vector2(600, 55);
            Rect labelRect = new Rect((Screen.width - labelSize.x) / 8, (Screen.height - labelSize.y) / 8, labelSize.x,
                labelSize.y);
            GUI.Label(labelRect, errorMessage,errorStyle);
        }
    } 
}
