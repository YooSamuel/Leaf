using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
            DontDestroyOnLoad(gameObject);
        }
		
	
		
	}

	public ScrollSnapRect scroll;
    public static int characterSelectedNumber;
	// Use this for initialization
	void Start ()
	{
		characterSelectedNumber = 0;
	}
	
    public void GamePlay()
    {
	    characterSelectedNumber = scroll.CurrentPage;
        SceneManager.LoadScene(2);

    }
}
