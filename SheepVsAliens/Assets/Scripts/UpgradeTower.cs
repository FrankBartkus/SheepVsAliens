using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public GameObject ui;

    void Awake()
    {
        ui.SetActive(false);
    }
    void OnMouseOver()
    {
        ui.gameObject.GetComponent<DisapearingUI>().col = true;
        ui.SetActive(true);
    }
    void OnMouseExit()
    {
        ui.SetActive(ui.gameObject.GetComponent<DisapearingUI>().col);
    }

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
            upgrades[level++].action.Invoke();
        }
        else
            SoundManager.PlaySound(SoundManager.Sound.Error);
    }
}