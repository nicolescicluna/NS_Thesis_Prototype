using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonUI : MonoBehaviour
{
    public Sprite closeBtnImage;

    public Button button;
    public Sprite menuButtonImage;

    public bool isMenu = true;
    // Start is called before the first frame update
    void Start()
    {
        button.image.sprite = menuButtonImage;
    }
    public void ChangeButtonImage()
    {
        if (isMenu)
        {
            button.image.sprite = closeBtnImage;
            isMenu = false;
        }
        else
        {
            button.image.sprite = menuButtonImage;
            isMenu = true;
        }
    }
}
