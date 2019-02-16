using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	public static ObstacleManager instance;
	public int stage;
	private int lineNum;
	private Vector3 firstPos = new Vector3(0f,6f,0f);
	public Vector3[] caseOfObstacle;
	public GameObject[] Stage1GoodObject;
	public GameObject[] Stage1BadObject;
	public GameObject[] Stage2GoodObject;
	public GameObject[] Stage2BadObject;
	public GameObject[] Stage3GoodObject;
	public GameObject[] Stage3BadObject;
	public GameObject[] Stage4GoodObject;
	public GameObject[] Stage4BadObject;
	public GameObject[] Stage5GoodObject;
	public GameObject[] Stage5BadObject;
	public List<GameObject> Obstacles;
    public GameObject endLine;
	private void Awake()
	{
		stage = 1;
		if (instance == null)
		{
			instance = this;
		}
		ObstacleInstantiate();
		ObstacleSet();
	}
	//1스테이지 도로 : Cage,Car,//Cat,Puddle,//Truck,Treat,Meal,//Present
	//2스테이지 해변 : Cage,Crab,Trash,Puddle,Treat,Meal,//Present 
	//3스테이지 바다속 : RareCage,//JellyFish, //Whale, //Seaweed, Treat, Meal, Present
	//4스테이지 시간의 틈 : HiddenCage, //BlackHole, //Present, Treat, Meal
	//5스테이지 꿈 속 :
	//HiddenCage, Treat, Meal, //SpecialMeal, //Present

	
	
	//1.   2.   3.
	//좋은거 나쁜거 나쁜거 - 3
	//나쁜거 좋은거 나쁜거 - 3
	//나쁜거 나쁜거 좋은거 - 3
	//좋은거 좋은거 나쁜거 - 2
	//나쁜거 좋은거 좋은거 - 2
	//좋은거 나쁜거 좋은거 - 2
	//좋은거 좋은거 좋은거 - 1

	void ObstacleInstantiate()
	{
		
		//Cage,Car,Cat,Puddle,Truck,Treat,Meal,Present
		// 나쁜것 Cage,Car,Cat,Puddle,Truck
		// 좋은것 Treat,Meal,Present,Blank
		// 1-20,2-60,3-20
		for (int i = 0; i < 105; i++)
		{
			GameObject ObstacleLine = new GameObject();
			ObstacleLine.name = "ObstacleLine" + i;
			ObstacleLine.transform.parent = transform;
			ObstacleLine.SetActive(false);
			int hardness = 0;
			int randHard = Random.Range(0, 100);
			if (randHard > 59)
			{
				hardness = 1;
			}else if (randHard>39)
			{
				hardness = 2;
			}
			else
			{
				hardness = 3;
			}
			int randIdx =0;
			if (hardness == 1)
			{
				randIdx = 6;
			}
			else if (hardness == 2)
			{
				randIdx = Random.Range(3, 6);
			}
			else
			{
				randIdx = Random.Range(0, 3);
			}
			Vector3 thisObstacle = new Vector3(0,0,0);
			thisObstacle = caseOfObstacle[randIdx];
			
			
			if (thisObstacle.x < 1)
			{
				GameObject obs = Instantiate(Stage1BadObject[Random.Range(0, Stage1BadObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(-1.8f,0f,0f);
			}
			else
			{
				GameObject obs = Instantiate(Stage1GoodObject[Random.Range(0, Stage1GoodObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(-1.8f,0f,0f);
			}
			
			if (thisObstacle.y <1)
			{
				GameObject obs = Instantiate(Stage1BadObject[Random.Range(0, Stage1BadObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(0f,0f,0f);
			}
			else
			{
				GameObject obs = Instantiate(Stage1GoodObject[Random.Range(0, Stage1GoodObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(0f,0f,0f);
			}
			if (thisObstacle.z <1)
			{
				GameObject obs = Instantiate(Stage1BadObject[Random.Range(0, Stage1BadObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(1.8f,0f,0f);
			}
			else
			{
				GameObject obs = Instantiate(Stage1GoodObject[Random.Range(0, Stage1GoodObject.Length)]);
				obs.transform.parent = ObstacleLine.transform;
				obs.transform.Translate(1.8f,0f,0f);
			}
			
			Obstacles.Add(ObstacleLine);
		}
	}

	void ObstacleSet()
	{
		for (int i = 0; i < 105; i++)
		{
			Obstacles[i].SetActive(true);
			Obstacles[i].transform.position = firstPos + Vector3.up * 12 * lineNum;
			lineNum++;
        }
        GameObject endLineObject = Instantiate(endLine, firstPos + Vector3.up * 12 * lineNum,Quaternion.identity);

	}
	
	
	//옵스타클 라인 세트
	//9*9*9 -> 729세트
	//옵스타클 라인 -> 난이도 높다, 중간, 낮다.
	//
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
