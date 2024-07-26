using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private Transform[] spawnPositions;

    private readonly Dictionary<Transform, Enemy> _spawnPositionEnemyDict = new();

    private void Start()
    {
        InitializeSpawnPositionEnemyDict();
    }

    public Enemy Spawn()
    {
        var enemy = enemyFactory.CreateEnemy();
        enemy.Died += OnEnemyDied;
        var spawnPosition = GetNextSpawnPosition();
        enemy.transform.position = spawnPosition.position;
        _spawnPositionEnemyDict[spawnPosition] = enemy;
        enemy.ApproachPlayer();
        return enemy;
    }

    private void InitializeSpawnPositionEnemyDict()
    {
        foreach (var spawnPosition in spawnPositions)
        {
            _spawnPositionEnemyDict.Add(spawnPosition, null);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        RemoveEnemyFromSpawnPositionDict(enemy);
    }

    private void RemoveEnemyFromSpawnPositionDict(Enemy enemy)
    {
        var spawnPositionPair = _spawnPositionEnemyDict.FirstOrDefault(pair => pair.Value == enemy);
        if (spawnPositionPair.Value == enemy)
        {
            _spawnPositionEnemyDict[spawnPositionPair.Key] = null;
        }
    }

    private Transform GetNextSpawnPosition()
    {
        var spawnPositionsWithoutEnemies = _spawnPositionEnemyDict
            .Where(pair => pair.Value is null)
            .Select(pair => pair.Key)
            .ToList();

        if (spawnPositionsWithoutEnemies.Count > 0)
        {
            return spawnPositionsWithoutEnemies[Random.Range(0, spawnPositionsWithoutEnemies.Count)];
        }

        var lowestEnemy = enemiesManager.GetLowestEnemy(_spawnPositionEnemyDict.Values);
        return _spawnPositionEnemyDict.FirstOrDefault(pair => pair.Value == lowestEnemy).Key;
    }
}