using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField] private GameObject markerLessScenebtn;
    [SerializeField] private GameObject markerBasedScenebtn;
    [SerializeField] private GameObject tutorialscenebtn;

    private bool isGameObjectsEnabled;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(DisableEnable);
        isGameObjectsEnabled = false;
        markerLessScenebtn.SetActive(isGameObjectsEnabled);
        markerBasedScenebtn.SetActive(isGameObjectsEnabled);
        tutorialscenebtn.SetActive(isGameObjectsEnabled);
    }

    void DisableEnable()
    {
        isGameObjectsEnabled ^= true;
        markerLessScenebtn.SetActive(isGameObjectsEnabled);
        markerBasedScenebtn.SetActive(isGameObjectsEnabled);
        tutorialscenebtn.SetActive(isGameObjectsEnabled);
    }
    
}
