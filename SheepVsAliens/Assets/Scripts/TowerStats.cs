using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public int cost = 15;
    public float range = 4f;
    public float fireRate = 1f;
    [HideInInspector]
    public float fireCountdown = 0f;
    public int damage = 10;
    public DamageOverTime overTime = new DamageOverTime();

    public void SetCost(int cost_)
    {
        cost = cost_;
    }
    public void SetRange(float range_)
    {
        range = range_;
    }
    public void SetFireRate(float fireRate_)
    {
        fireRate = fireRate_;
    }
    public void SetDamage(int damage_)
    {
        damage = damage_;
    }
    public void SetDoT(float dot)
    {
        DamageOverTime next = new DamageOverTime();
        next.DoT = dot;
        next.DoTTime = 5f;
        overTime.SetDoT(next);
    }
    [Serializable]
    public class DamageOverTime
    {
        public float DoT = 0;
        public float DoTTime = 0f;
        public float DoTCurrentTime = 0f;
        public float DoTFullTime = 0f;
        public void SetDoT(DamageOverTime damageOverTime)
        {
            DoT = damageOverTime.DoT;
            DoTTime = damageOverTime.DoTTime;
        }
    }
}
