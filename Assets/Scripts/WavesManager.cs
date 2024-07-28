using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PrimeTween;
using TMPro;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    private const int MaxEnemyUniqueVulnerabilities = 6;

    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private TextMeshProUGUI waveStartedText;
    [SerializeField] private TweenSettings<float> waveStartedTextAlphaTweenSettings;
    [SerializeField] private WaveConfiguration[] wavesConfigurations;

    private readonly Dictionary<SubWave, List<Enemy>> _remainingSubWaveEnemiesDict = new();

    private bool _allCurrentWaveEnemiesSpawned;

    public static WaveConfiguration CurrentWave { get; private set; }

    public static SubWave CurrentSubWave { get; private set; }

    private bool IsLastWave => CurrentWave == wavesConfigurations[^1];

    private bool CurrentWaveEnemiesDefeated => _allCurrentWaveEnemiesSpawned &&
                                               _remainingSubWaveEnemiesDict.Values.All(enemies => enemies.Count is 0);

    private void Start()
    {
        ValidateWavesConfigurations();
        if (CurrentWave is not null)
        {
            StartCoroutine(StartWave(CurrentWave));
        }
        else
        {
            StartNextWave();
        }
    }

    public static void SetCurrentWave(WaveConfiguration waveConfiguration)
    {
        CurrentWave = waveConfiguration;
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
                return;
            }
        }
        StartCoroutine(StartWave(wavesConfigurations[nextWaveIndex]));
    }

    private IEnumerator StartWave(WaveConfiguration waveConfiguration)
    {
        CurrentWave = waveConfiguration;
        _allCurrentWaveEnemiesSpawned = false;
        yield return new WaitForSeconds(waveConfiguration.DelayBeforeWaveStarts);
        DisplayWaveStartedText();
        foreach (var subWaveConfig in waveConfiguration.SubWavesConfigurations)
        {
            CurrentSubWave = new SubWave(subWaveConfig);
            _remainingSubWaveEnemiesDict.Add(CurrentSubWave, new List<Enemy>());
            yield return new WaitForSeconds(subWaveConfig.DelayBeforeStart);
            for (var i = 0; i < subWaveConfig.EnemiesAmount; i++)
            {
                var enemy = enemySpawner.Spawn();
                _remainingSubWaveEnemiesDict[CurrentSubWave].Add(enemy);
                enemy.Died += OnEnemyDefeated;
                if (i < subWaveConfig.EnemiesAmount - 1)
                {
                    yield return new WaitForSeconds(subWaveConfig.SpawnDelay);
                }
            }
        }
        _allCurrentWaveEnemiesSpawned = true;
    }

    private void DisplayWaveStartedText()
    {
        var waveIndex = wavesConfigurations.ToList().IndexOf(CurrentWave);
        waveStartedText.SetText($"Wave {waveIndex + 1} incoming!");
        Tween.Alpha(waveStartedText, waveStartedTextAlphaTweenSettings);
    }

    private void OnEnemyDefeated(Enemy enemy)
    {
        var subWave = _remainingSubWaveEnemiesDict.First(pair => pair.Value.Contains(enemy)).Key;
        _remainingSubWaveEnemiesDict[subWave].Remove(enemy);
        if (!CurrentWaveEnemiesDefeated)
        {
            return;
        }
        _remainingSubWaveEnemiesDict.Clear();
        if (playerManager.CurrentLives <= 0)
        {
            return;
        }
        if (IsLastWave)
        {
            StartCoroutine(GameOverWin());
        }
        else
        {
            StartNextWave();
        }
    }

    private IEnumerator GameOverWin()
    {
        yield return new WaitForSeconds(2f);
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
            for (var i = 0; i < waveConfiguration.SubWavesConfigurations.Length; i++)
            {
                var subWave = waveConfiguration.SubWavesConfigurations[i];
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