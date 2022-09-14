using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _lastFire = float.MinValue;
    [SerializeField] private Vector2 spawnOffset = Vector2.zero;
    
    public Transform bulletPrefab;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (PauseManager.IsPaused) return;
        
        Vector2 spawnLocation = Vector2.zero;
        Quaternion rotation;
        if (_sprite.flipX)
        {
            spawnLocation.x = -spawnOffset.x;
            rotation = Quaternion.Euler(new Vector3(0,180,0));
        }
        else
        {
            spawnLocation.x = spawnOffset.x;
            rotation = Quaternion.Euler(new Vector3(0,0,0));
        }

        spawnLocation.y = spawnOffset.y;
        
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, 
                transform.position + (Vector3) spawnLocation,
                rotation);
            
            _lastFire = Time.time;

        }
    }
}
