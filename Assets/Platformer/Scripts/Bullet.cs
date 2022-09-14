using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10f;
    private float _spawnTime = 0f;
    [SerializeField] private float _speed = 50f;

    private void OnEnable()
    {
        _spawnTime = Time.time;
    }

    void Update()
    {
        transform.position += transform.right * (_speed * Time.deltaTime);

        if (Time.time > _spawnTime + _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
