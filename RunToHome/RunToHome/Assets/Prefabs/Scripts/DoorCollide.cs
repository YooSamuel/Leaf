using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorCollide : MonoBehaviour {
    public Image loadingBar;
    public Image loadingBarWhite;
    private float loadingAmount;
    private bool isColliding;

    Coroutine a;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AdventurePlayer"))
        {
            print("collide");
            isColliding = true;
            a = StartCoroutine(DoorCollideCoroutine());
        }
    }

    IEnumerator DoorCollideCoroutine()
    {
        loadingBar.enabled = true;
        loadingBarWhite.enabled = true;

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            loadingAmount = loadingAmount + 5f;
            loadingBar.fillAmount = loadingAmount / 100.0f;
        }

        print("sceneChange");
        SceneManager.LoadScene("Adventure Mode");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        isColliding = false;
        loadingAmount = 0f;
        StopCoroutine(a);
        loadingBar.enabled = false;
        loadingBarWhite.enabled = false;
    }

    private void Start()
    {
        loadingBar = GameObject.FindWithTag("LoadingBar").GetComponent<Image>();
        loadingBarWhite = GameObject.FindWithTag("LoadingBarWhite").GetComponent<Image>();
    }

    void Update()
    {
        if (isColliding != true)
        {
            loadingBar.enabled = false;
            loadingBarWhite.enabled = false;
        }
    }
}
