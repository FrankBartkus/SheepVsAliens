using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class Upgrade
{
    public string name;
    public UnityEvent action;
    public int cost = 20;
}

public class UpgradeTower : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>();
    int level = 0;
    GameObject placeToAdd;
    GameObject add;

    public void LevelUp(int finalLevel)
    {
        if (level + 1 == finalLevel)
        {
            if (PlayerStats.Money < upgrades[level].cost)
            {
                SoundManager.PlaySound(SoundManager.Sound.Error);
                return;
            }
            UnityEngine.Debug.Log(upgrades[level].name);
            PlayerStats.changeMoneyAmount(-upgrades[level].cost);
            SoundManager.PlaySound(SoundManager.Sound.TowerPurchase);
            SoundManager.PlaySound(SoundManager.Sound.TowerUpgrade);
            placeToAdd = GetComponentsInChildren<Image>()[finalLevel + level].gameObject;
            add = new GameObject("Check" + level);
            add.transform.position = placeToAdd.transform.position;
            add.transform.SetParent(placeToAdd.transform);
            add.AddComponent<Image>().sprite = GameAssets.i.checkSprite;
            add.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
            upgrades[level++].action.Invoke();
        }
        else
            SoundManager.PlaySound(SoundManager.Sound.Error);
    }
}