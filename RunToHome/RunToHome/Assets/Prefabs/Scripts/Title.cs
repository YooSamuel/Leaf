using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    public GameObject[] disGameObject;
    public GameObject[] apGameObject;

    void Start () 
    {
        Invoke("StartBtn", 6f);
	}

	
	// Update is called once per frame
	void Update () 
    {
		
	}
    void StartBtn()
    {
        foreach (var go in disGameObject)
        {
            go.SetActive(false);
        }
        foreach (var go in apGameObject)
        {
            go.SetActive(true);
        }
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

}
