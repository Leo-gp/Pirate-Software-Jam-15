using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public Enemy[] EnemiesPool { get; private set; }

    private void Awake()
    {
        EnemiesPool = FindObjectsOfType<Enemy>(true);
    }

    public Enemy GetLowestEnemy()
    {
        return EnemiesPool
            .Where(enemy => enemy.gameObject.activeInHierarchy)
            .OrderBy(enemy => enemy.transform.position.y)
            .FirstOrDefault();
    }

    public Enemy GetLowestEnemy(IEnumerable<Enemy> enemies)
    {
        return enemies
            .OrderBy(enemy => enemy.transform.position.y)
            .FirstOrDefault();
    }
}