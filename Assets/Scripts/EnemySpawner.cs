using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform spawnPosition;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        // TODO: For testing purposes. Remove later.
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetEnemy();
        }
    }

    private void Spawn()
    {
        var enemy = enemyFactory.CreateEnemy();
        enemy.transform.position = spawnPosition.position;
        enemy.ApproachPlayer();
    }

    // TODO: For testing purposes. Remove later.
    private void ResetEnemy()
    {
        FindObjectOfType<Enemy>(true).gameObject.SetActive(false);
        Spawn();
    }
}