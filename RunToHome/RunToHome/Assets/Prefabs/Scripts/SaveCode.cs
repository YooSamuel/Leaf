/*
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum DogsBreed
{
    BichonFrise, Shiba, Poodle, GoldenRetriever, Husky, Beagle, Pomeranian
}

public class GameManager : MonoBehaviour
{
    public bool gameStart = false;
    public Text LifeScore;
    public Text PawScore;
    public Text MeterScore;
    public Text TotalScore;
    public GameObject SettingPanel;
    public GameObject ResultPanel;
    public GameObject DialoguePanel;

    public static GameManager instance;
    public GameObject[] CharacterPrefabs = new GameObject[5];
    public GameObject[] dogImages;
    public Text DogName;
    public Text textDisplay;
    public String[] sentences;
    private int index;
    public float typingSpeed;
    private Player playerScript;
    public GameObject[] tutoImage;

    public Text scoreText;

    public Text dogText;
    //Item
    //Money, Diamond
    //Saved Dog
    public List<int> ItemOccupiedList = new List<int>();
    private int itemCount = 28;
    private int money;
    private int diamond;
    private int dog = 0;
    private int score = 0;
    public DogsBreed currentBreed = DogsBreed.BichonFrise;

    public void SaveItem()
    {
        for (int i = 0; i < ItemOccupiedList.Count; i++)
        {
            PlayerPrefs.SetInt("Item" + i, ItemOccupiedList[i]);
        }
        PlayerPrefs.Save();
    }
    public void EndGame()
    {
        LifeScore.text = playerScript.CurHp.ToString() + " * 1 = " + playerScript.CurHp.ToString();
        PawScore.text = dog + " * 50 = " + dog * 50;
        MeterScore.text = score / 10 + " * 5 = " + score / 10 * 5;
        TotalScore.text = (playerScript.CurHp + dog * 50 + score / 2).ToString();
        ResultPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void SaveAsset()
    {

        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Diamond", diamond);
        PlayerPrefs.SetInt("Dog", dog);
        PlayerPrefs.Save();
    }

    public void LoadItem()
    {
        ItemOccupiedList.Clear();

        for (int i = 0; i < itemCount; i++)
        {
            if (PlayerPrefs.HasKey("Item" + i))
            {
                ItemOccupiedList.Add(PlayerPrefs.GetInt("Item" + i));
            }
            else
            {
                ItemOccupiedList.Add(0);
            }
        }
    }

    public void LoadAsset()
    {

        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }

        if (PlayerPrefs.HasKey("Diamond"))
        {
            diamond = PlayerPrefs.GetInt("Diamond");
        }

        if (PlayerPrefs.HasKey("Dog"))
        {
            dog = PlayerPrefs.GetInt("Dog");
        }

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        SettingPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        SettingPanel.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
    public void InitializeGame()
    {
        LoadItem();
        LoadAsset();
        LoadPlayer();

    }

    public void LoadPlayer()
    {
        GameObject playerObject = Instantiate(CharacterPrefabs[UIManager.characterSelectedNumber], transform.position, Quaternion.identity);
        dogImages[UIManager.characterSelectedNumber].SetActive(true);
        switch (UIManager.characterSelectedNumber)
        {
            case 0:
                DogName.text = "Beagle";
                break;
            case 1:
                DogName.text = "Bicheon";
                break;
            case 2:
                DogName.text = "Husky";
                break;
            case 3:
                DogName.text = "Pomeranian";
                break;
            case 4:
                DogName.text = "Shiba";
                break;

        }
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InitializeGame();
    }

    public void ScoreUp()
    {
        score++;
        //1->0.1
        //10 -> 1
        //100 -> 10.0;
        string tempStr = score / 10 + "." + score % 10;
        scoreText.text = string.Concat(tempStr, "m");

    }

    public void ScorUp2(int amount)
    {
        score = score + amount;
    }

    public void DogUp()
    {
        dog++;
        dogText.text = dog.ToString();
    }

    private void Start()
    {


        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();

        StartCoroutine(Type());
    }

    public IEnumerator Type()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence()
    {


        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            GameStart();
            gameStart = true;
            DialoguePanel.SetActive(false);

        }
        if (index == 1)
        {
            tutoImage[0].SetActive(true);
            tutoImage[1].SetActive(true);
        }
        else if (index == 2)
        {
            tutoImage[0].SetActive(false);
            tutoImage[1].SetActive(false);
            tutoImage[2].SetActive(true);
            tutoImage[3].SetActive(true);
        }
        else if (index == 3)
        {
            tutoImage[2].SetActive(false);
            tutoImage[3].SetActive(false);
            tutoImage[4].SetActive(true);
        }
        else if (index == 4)
        {
            tutoImage[4].SetActive(false);
        }
    }
    public void GameStart()
    {

        InvokeRepeating("ScoreUp", 0f, 0.05f);
    }
}
*/




