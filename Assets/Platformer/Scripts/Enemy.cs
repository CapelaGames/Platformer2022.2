using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 5;
    [SerializeField] private int _CurrentHealth = 5;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (bullet != null)
        {
            _CurrentHealth--;

            if (_CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
