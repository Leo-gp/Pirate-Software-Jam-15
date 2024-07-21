using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private const int VulnerabilitiesAmount = 4;

    [SerializeField] private MixturesManager mixturesManager;

    private Enemy[] _enemiesPool;

    private void Awake()
    {
        _enemiesPool = FindObjectsOfType<Enemy>(true);
    }

    public Enemy CreateEnemy()
    {
        var enemy = GetEnemyFromPool();
        enemy.Initialize(GetRandomVulnerabilities());
        return enemy;
    }

    private Enemy GetEnemyFromPool()
    {
        return _enemiesPool.FirstOrDefault(enemy => !enemy.gameObject.activeInHierarchy);
    }

    private List<Mixture> GetRandomVulnerabilities()
    {
        var mixtures = new List<Mixture>();
        for (var i = 0; i < VulnerabilitiesAmount; i++)
        {
            mixtures.Add(mixturesManager.GetRandomMixture());
        }
        return mixtures;
    }
}