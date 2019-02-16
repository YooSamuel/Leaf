using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour {
    public GameObject shopPanel1;
    public GameObject shopPanel2;
    public GameObject shopPanel3;
    public GameObject shopPanel4;
    public GameObject shopPanel5;
    Touch touch;
    Vector2 touchPos;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    void Start()
    {
        TogglePanel1();
        button1.onClick.AddListener(TogglePanel1);
        button2.onClick.AddListener(TogglePanel2);
        button3.onClick.AddListener(TogglePanel3);
        button4.onClick.AddListener(TogglePanel4);
        button5.onClick.AddListener(TogglePanel5);
    }

    void Update()
    {

    }

    public void TogglePanel1()
    {
        shopPanel1.SetActive(true);
        shopPanel2.SetActive(false);
        shopPanel3.SetActive(false);
        shopPanel4.SetActive(false);
        shopPanel5.SetActive(false);
    }
    public void TogglePanel2()
    {
        shopPanel2.SetActive(true);
        shopPanel1.SetActive(false);
        shopPanel3.SetActive(false);
        shopPanel4.SetActive(false);
        shopPanel5.SetActive(false);
    }
    public void TogglePanel3()
    {
        shopPanel3.SetActive(true);
        shopPanel2.SetActive(false);
        shopPanel1.SetActive(false);
        shopPanel4.SetActive(false);
        shopPanel5.SetActive(false);
    }
    public void TogglePanel4()
    {
        shopPanel4.SetActive(true);
        shopPanel2.SetActive(false);
        shopPanel3.SetActive(false);
        shopPanel1.SetActive(false);
        shopPanel5.SetActive(false);
    }
    public void TogglePanel5()
    {
        shopPanel5.SetActive(true);
        shopPanel2.SetActive(false);
        shopPanel3.SetActive(false);
        shopPanel4.SetActive(false);
        shopPanel1.SetActive(false);
    }
}
