using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
    public float SpawnTimer;
    public GameObject EnemyPrefab;
    public Transform SpawnLocation;
    public float EnemyHealth;
    public float EnemyType;

    public abstract void CreateEnemy();
}
