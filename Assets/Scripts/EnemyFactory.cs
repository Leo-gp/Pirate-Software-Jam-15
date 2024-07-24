using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private const int VulnerabilitiesAmount = 6;

    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private MixturesManager mixturesManager;
    [SerializeField] private WavesManager wavesManager;

    public Enemy CreateEnemy()
    {
        var enemy = GetEnemyFromPool();
        enemy.gameObject.SetActive(true);
        enemy.Initialize(wavesManager.CurrentWave.EnemiesTimeToReachPlayer, CreateVulnerabilities());
        return enemy;
    }

    private Enemy GetEnemyFromPool()
    {
        return enemiesManager.EnemiesPool.FirstOrDefault(enemy => !enemy.gameObject.activeInHierarchy);
    }

    private List<Mixture> CreateVulnerabilities()
    {
        var mixtures = new List<Mixture>();
        var vulnerabilities = wavesManager.CurrentSubWave.Vulnerabilities;
        var totalUniqueVulnerabilities = vulnerabilities.UniqueSimpleAmount + vulnerabilities.UniqueComplexAmount;
        var vulnerabilitiesRepeatAmount = VulnerabilitiesAmount / totalUniqueVulnerabilities;
        for (var i = 0; i < vulnerabilities.UniqueSimpleAmount; i++)
        {
            mixtures.AddRange(GetUniqueVulnerabilityListForMixtures(mixtures, true, vulnerabilitiesRepeatAmount));
        }
        for (var i = 0; i < vulnerabilities.UniqueComplexAmount; i++)
        {
            mixtures.AddRange(GetUniqueVulnerabilityListForMixtures(mixtures, false, vulnerabilitiesRepeatAmount));
        }
        return mixtures;
    }

    private List<Mixture> GetUniqueVulnerabilityListForMixtures
    (
        List<Mixture> mixtures,
        bool isSimpleMixture,
        int vulnerabilitiesRepeatAmount
    )
    {
        Mixture mixture;
        var loopCount = 0;
        do
        {
            mixture = isSimpleMixture
                ? mixturesManager.GetRandomSimpleMixture()
                : mixturesManager.GetRandomComplexMixture();
            loopCount++;
            if (loopCount > 9999)
            {
                throw new Exception("Infinite loop");
            }
        } while (mixtures.Contains(mixture));
        return Enumerable.Repeat(mixture, vulnerabilitiesRepeatAmount).ToList();
    }
}