using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerSR;
    private Image hpBar;
    private int hp = 0;
    private int curHp = 0;
    private float moveSpeed = 0f;
    private bool canRelease = false;
    private bool canCol = false;
    private bool protectFromCrash = false;
    private bool saveDogOriginalPlus = false;
    private bool minuteThreeSecondsDestroy = false;
    private bool minuteFiveSecondsNothing = false;
    private bool noticeObstacle = false;
    private bool onefiftyDestroyFiveOnce = false;
    private bool fifteenTreatTwentyMeters = false;
    public bool canCrush = false;
    public bool CanDoBeagle = true;
    public bool UnderHPBeagle = false;


    public int CurHp
    {
        get
        {
            return curHp;
        }

        set
        {
            curHp = value;
        }
    }

    //숙제 - break 전 "InitializeDog(hp, moveSpeed, def, noticeObstacle 등등등)" 쓰기, 속성 더 만들기

    // Use this for initialization
    void Start()
    {

        hpBar = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        switch (GameManager.instance.currentBreed)
        {
            case DogsBreed.BichonFrise:
                InitializeDog(1000, 5f, true, false, false, false, false, false, false);
                GameManager.instance.IsBichon = true;
                break;
            case DogsBreed.Beagle:
                print("bbb");
                onefiftyDestroyFiveOnce = true;
                hp = 1050;
                moveSpeed = 6f;
                GameManager.instance.IsBeagle = true;
                break;
            case DogsBreed.GoldenRetriever:
                noticeObstacle = true;
                hp = 1100;
                moveSpeed = 6f;
                break;
            case DogsBreed.Husky:
                minuteFiveSecondsNothing = true;
                hp = 1100;
                moveSpeed = 7f;
                GameManager.instance.IsHusky = true;
                break;
            case DogsBreed.Pomeranian:
                GameManager.instance.IsPomeranian = true;
                fifteenTreatTwentyMeters = true;
                hp = 900;
                moveSpeed = 4.5f;
                break;
            case DogsBreed.Poodle:
                minuteThreeSecondsDestroy = true;
                hp = 1000;
                moveSpeed = 5.5f;
                break;
            case DogsBreed.Shiba:
                GameManager.instance.IsShiba = true;
                saveDogOriginalPlus = true;
                hp = 1000;
                moveSpeed = 6f;
                break;
        }
        if (GameManager.instance.IsBeagle == true)
        {
            print("hhhhhhh");
        }
        curHp = hp;
        hpBar.fillAmount = curHp / (float)hp;
        GetComponent<PlayerMovement>().MoveSpeedSet(moveSpeed);
        canRelease = true;
        canCol = true;
        playerSR = GetComponent<SpriteRenderer>();
        InvokeRepeating("ContinousHPDecrease", 0f, 0.3f);

        print("AAAAA");
        InvokeRepeating("PoodleSpeciality", 0f, 60f);
        InvokeRepeating("HuskySpeciality", 0f, 60f);



    }

    void HuskySpeciality()
    {
        if (GameManager.instance.IsHusky == true)
        {
            print("started");
            StartCoroutine(HuskySpecialityCoroutine());
        }

    }

    IEnumerator HuskySpecialityCoroutine()
    {

        GameManager.instance.nothing = true;
        print("start coroutine");
        yield return new WaitForSeconds(5f);
        print("end coroutine");
        GameManager.instance.nothing = false;
    }

    void PoodleSpeciality()
    {
        if (minuteThreeSecondsDestroy == true)
        {
            StartCoroutine(PoodleSpecialityCoroutine());
        }
    }
    IEnumerator PoodleSpecialityCoroutine()
    {
        canCrush = true;
        yield return new WaitForSeconds(3f);
        canCrush = false;
    }
    void InitializeDog(int hp, float moveSpeed, bool protectFromCrash, bool saveDogOriginalPlus, bool minuteThreeSecondsDestroy, bool noticeObstacle, bool minuteFiveSecondsNothing, bool onefiftyDestroyFiveOnce, bool fifteenTreatTwentyMeters)
    {
        this.hp = hp;
        this.moveSpeed = moveSpeed;
        this.protectFromCrash = protectFromCrash;
        this.saveDogOriginalPlus = saveDogOriginalPlus;
        this.minuteThreeSecondsDestroy = minuteThreeSecondsDestroy;
        this.noticeObstacle = noticeObstacle;
        this.minuteFiveSecondsNothing = minuteFiveSecondsNothing;
        this.onefiftyDestroyFiveOnce = onefiftyDestroyFiveOnce;
        this.fifteenTreatTwentyMeters = fifteenTreatTwentyMeters;
    }

    public void HpManage(int amount)
    {
        if (canCol == false)
        {
            return;
        }
        curHp += amount;
        if (curHp > hp)
        {
            curHp = hp;
        }
        else if (curHp < 0)
        {
            curHp = 0;
            GameManager.instance.EndGame();
        }
        hpBar.fillAmount = curHp / (float)hp;
        print("현재 체력은 : " + curHp + "입니다.");
    }
    public void ContinousHPDecrease()
    {
        if (GameManager.instance.CanDecreaseHP == true)
        {
            if (GameManager.instance.IsDashing == false)
            {
                curHp = curHp - 5;
                hpBar.fillAmount = curHp / (float)hp;
            }
        }




    }

    public void FindCage()
    {
        if (canCol == false)
        {
            return;
        }
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, Vector2.up * 2.5f + Vector2.right * 2.5f, 0f);
        foreach (var col in cols)
        {
            if (col.GetComponent<Obstacle>() != null)
            {
                if (col.GetComponent<Obstacle>().mySort == ObstacleSort.Cage)
                {
                    col.GetComponentInChildren<Animator>().SetBool("Open", true);
                    GameManager.instance.DogUp();
                    canRelease = false;
                    Invoke("ReleaseSet", 0.7f);
                }
            }
        }
    }

    public void ReleaseSet()
    {
        canRelease = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canRelease)
        {
            FindCage();

        }
        /*if (GameManager.instance.IsBeagle == true)
        {
            BeagleSpeaciality();
        }
        */
    }

    /*public void BeagleSpeaciality()
    {
        print("a");
        if (curHp <= 150 && CanDoBeagle == true)
        {
            StartCoroutine(BeagleCoroutine());
            CanDoBeagle = false;
        }
    }
    //BeagleSpeciality - BeagleCoroutine - switch(mySort)
    IEnumerator BeagleCoroutine()
    {
        print("b");
        GameManager.instance.BeagleDoing = true;
        yield return new WaitForSeconds(5f);
        GameManager.instance.BeagleDoing = false;
    }
    */

    public void Blink()
    {
        if (canCol == false)
        {
            return;
        }
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        canCol = false;
        for (int i = 0; i < 4; i++)
        {
            playerSR.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.25f);
            playerSR.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
        }

        canCol = true;


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EndLine"))
        {
            GameManager.instance.EndGame();
        }

    }

}