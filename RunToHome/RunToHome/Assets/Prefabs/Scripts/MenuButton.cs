using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
    public GameObject menuPanel;
    Touch touch;
    Vector2 touchPos;
    public Button button;

    void Start() {
         button.onClick.AddListener(TogglePanel);
    }

    void Update() {

    }

    public void TogglePanel()
    {
        if(menuPanel.activeInHierarchy == true)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }
}
