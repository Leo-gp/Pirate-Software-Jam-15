using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform spawnPosition;

    public Enemy Spawn()
    {
        var enemy = enemyFactory.CreateEnemy();
        enemy.transform.position = spawnPosition.position;
        enemy.ApproachPlayer();
        return enemy;
    }
}