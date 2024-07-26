using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    private const int MaxEnemyUniqueVulnerabilities = 6;

    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private WaveConfiguration[] wavesConfigurations;

    private Enemy _lastSpawnedEnemy;

    public WaveConfiguration CurrentWave { get; private set; }

    public WaveConfiguration.SubWave CurrentSubWave { get; private set; }

    private void Start()
    {
        ValidateWavesConfigurations();
        StartNextWave();
    }

    private void OnDisable()
    {
        if (_lastSpawnedEnemy is not null)
        {
            _lastSpawnedEnemy.Died -= OnLastEnemyDefeated;
        }
    }

    private void StartNextWave()
    {
        var nextWaveIndex = 0;
        if (CurrentWave is not null)
        {
            var currentWaveIndex = wavesConfigurations.ToList().IndexOf(CurrentWave);
            if (currentWaveIndex < wavesConfigurations.Length - 1)
            {
                nextWaveIndex = currentWaveIndex + 1;
            }
            else
            {
                OnWavesFinished();
                return;
            }
        }
        StartCoroutine(StartWave(wavesConfigurations[nextWaveIndex]));
    }

    private IEnumerator StartWave(WaveConfiguration waveConfiguration)
    {
        CurrentWave = waveConfiguration;
        yield return new WaitForSeconds(waveConfiguration.DelayBeforeWaveStarts);
        foreach (var subWave in waveConfiguration.SubWaves)
        {
            CurrentSubWave = subWave;
            yield return new WaitForSeconds(subWave.DelayBeforeStart);
            for (var i = 0; i < subWave.EnemiesAmount; i++)
            {
                _lastSpawnedEnemy = enemySpawner.Spawn();
                if (i < subWave.EnemiesAmount - 1)
                {
                    yield return new WaitForSeconds(subWave.SpawnDelay);
                }
            }
        }
        StartNextWave();
    }

    private void OnWavesFinished()
    {
        _lastSpawnedEnemy.Died += OnLastEnemyDefeated;
    }

    private void OnLastEnemyDefeated(Enemy enemy)
    {
        gameOverManager.GameOverWin();
    }

    private void ValidateWavesConfigurations()
    {
        foreach (var waveConfiguration in wavesConfigurations)
        {
            if (waveConfiguration.EnemiesTimeToReachPlayer <= 0)
            {
                throw new Exception
                (
                    $"Enemies time to reach player must be greater than zero at {waveConfiguration.name}"
                );
            }
            for (var i = 0; i < waveConfiguration.SubWaves.Length; i++)
            {
                var subWave = waveConfiguration.SubWaves[i];
                var simpleAmount = subWave.Vulnerabilities.UniqueSimpleAmount;
                var complexAmount = subWave.Vulnerabilities.UniqueComplexAmount;
                if (simpleAmount < 0 || complexAmount < 0)
                {
                    throw new Exception
                    (
                        "The amount of simple and/or complex unique vulnerabilities for enemy cannot be " +
                        $"negative at: {waveConfiguration.name}, Sub-Wave [{i}]"
                    );
                }
                if (simpleAmount > 3 || complexAmount > 3)
                {
                    throw new Exception
                    (
                        "The amount of simple and/or complex unique vulnerabilities for enemy cannot be " +
                        $"greater than 3 at: {waveConfiguration.name}, Sub-Wave [{i}]"
                    );
                }
                if (simpleAmount + complexAmount <= 0)
                {
                    throw new Exception
                    (
                        "The total amount of simple and complex unique vulnerabilities for enemy must be " +
                        $"greater than zero at: {waveConfiguration.name}, Sub-Wave [{i}]"
                    );
                }
                if (MaxEnemyUniqueVulnerabilities % (simpleAmount + complexAmount) != 0)
                {
                    throw new Exception
                    (
                        $"The max enemy unique vulnerabilities value ({MaxEnemyUniqueVulnerabilities}) must be " +
                        "divisible by the total amount of simple and complex unique vulnerabilities for enemy " +
                        $"at: {waveConfiguration.name}, Sub-Wave [{i}]"
                    );
                }
            }
        }
    }
}