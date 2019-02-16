using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
	Good,Bad
}

public enum ObstacleSort
{
	//1스테이지 도로 : Cage,Car,Cat,Puddle,Truck,Treat,Meal,Present
	//2스테이지 해변 : Cage,Crab,Trash,Puddle,Treat,Meal,Present 
	//3스테이지 바다속 : BubbleCage,JellyFish, Whale, Seaweed, Treat, Meal, Present
	//4스테이지 시간의 틈 : HiddenCage, BlackHole, Present, Treat, Meal
	//5스테이지 꿈 속 :
	//HiddenCage, Cloud, Rainbow, Treat, Meal, SpecialMeal, Present
	
	Car,Truck,Whale,Puddle,Cage,BubbleCage,Crab,Cat,Treat,Meal,
	Blank,Trash,JellyFish,HiddenCage,BlackHole,Cloud,
	Rainbow,Seaweed,Present,SpecialMeal
}


public class Obstacle : MonoBehaviour
{
	public ObstacleType myType = ObstacleType.Bad;
	public ObstacleSort mySort = ObstacleSort.Blank;
	private GameObject player;
	private Player playerScript;
	private SpriteRenderer obsSR;

	private void Start()
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<Player>();
		obsSR = GetComponent<SpriteRenderer>();
	}

	public void SetObstacle(ObstacleType type, ObstacleSort sort)
	{
		myType = type;
		mySort = sort;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			
			switch (mySort)
			{
				case ObstacleSort.Blank:
					
					break;
				case ObstacleSort.Cage:
					playerScript.HpManage(-150);
					playerScript.Blink();
					break;
				case ObstacleSort.Car:
					playerScript.HpManage(-250);
					playerScript.Blink();
					break;
				case ObstacleSort.Cat:
					break;
				case ObstacleSort.Cloud:
					break;
				case ObstacleSort.Crab:
					break;
				case ObstacleSort.Meal:
					playerScript.HpManage(+100);
					obsSR.color = new Color(1,1,1,0);
					break;
				case ObstacleSort.Present:
					break;
				case ObstacleSort.Puddle:
					break;
				case ObstacleSort.Rainbow:
					break;
				case ObstacleSort.Seaweed:
					break;
				case ObstacleSort.Trash:
					break;
				case ObstacleSort.Treat:
					playerScript.HpManage(+50);
					obsSR.color = new Color(1,1,1,0);
					break;
				case ObstacleSort.Truck:
					break;
				case ObstacleSort.Whale:
					break;
				case ObstacleSort.BlackHole:
					break;
				case ObstacleSort.BubbleCage:
					break;
				case ObstacleSort.HiddenCage:
					break;
				case ObstacleSort.JellyFish:
					break;
				case ObstacleSort.SpecialMeal:
					break;

					
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		
	}
}
