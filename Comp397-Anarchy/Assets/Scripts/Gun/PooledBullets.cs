using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PooledBullets : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _maxLifeTime = 3f;

    // Why on Enable and not Start
    // OnEnable is called when the object is activated. 
    private void OnEnable()
    {
        _lifeTime = 0;
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime > _maxLifeTime)
        {
            //BulletsPoolManager.Instance.ReturnToPool(this);
        }
    }
}
