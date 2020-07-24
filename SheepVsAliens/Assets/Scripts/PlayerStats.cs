using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;
    public static PlayerStats i;
    public static Transform liveParent;

    public Text moneyText;

    void Start()
    {
        i = this;
        Money = startMoney;
		Lives = startLives;

        moneyText.text = string.Format("Wool : {0}", Money);
        Rounds = 0;
        liveParent = GameObject.Find("Lives").transform;
    }

    public static void reduceLives(int amount)
    {
        Lives -= amount;
        for (int x = 0; x < amount; x++)
        {
            if (liveParent.childCount < 1)
                break;
            Destroy(liveParent.GetChild(liveParent.childCount - 1).gameObject);
        }
        if (Lives <= 0)
        {
            Lives = 0;
            GameHandler.GameOverLevel();
            UnityEngine.Debug.LogWarning("Game Over!");
        }
    }

    public static void changeMoneyAmount(int amount)
    {
        Money += amount;
        i.moneyText.text = string.Format("Wool : {0}", Money);
    }
}