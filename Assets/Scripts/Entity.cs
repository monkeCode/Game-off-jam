using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
     [SerializeField] private int hp;
     [SerializeField] private int maxHp;
     [SerializeField] protected int speed;
     [SerializeField] protected int maxSpeed;

     public int Hp
     {
          get => hp;
          set
          {
               hp += value;
               if (hp > maxHp)
                    hp = maxHp;
               HpChanged?.Invoke(hp,value);
          }
     }
     public int MaxHp => maxHp;

     public event Action<int, int> HpChanged;

     public virtual void TakeDamage(int damage)
     {
          Hp -= damage;
          if(Hp <=0)
               Die();
     }

     protected virtual void Die()
     {
          Destroy(gameObject);
     }
}
