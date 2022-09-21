using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 5;
    [SerializeField] private int _CurrentHealth = 5;
    
    private Animator _anim;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            _CurrentHealth--;
            StartCoroutine(FlashingAnimation(1f));
            if (_CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    IEnumerator FlashingAnimation(float seconds)
    {
        _anim.SetBool("Flashing", true);
        yield return new WaitForSeconds(seconds);
        _anim.SetBool("Flashing", false);
    }
}
