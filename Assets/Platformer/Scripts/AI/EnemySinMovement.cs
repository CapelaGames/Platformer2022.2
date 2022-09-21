using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child or derived class
public class EnemySinMovement : EnemyMovement
{
    [SerializeField] protected float _amplitude = 10f;
    [SerializeField] protected float _frequency = 2f;
    protected override void MoveEnemy()
    {
        _velocity.y = Mathf.Sin(Time.time * _frequency ) * _amplitude * Time.deltaTime;
        
        base.MoveEnemy();
    }
}
