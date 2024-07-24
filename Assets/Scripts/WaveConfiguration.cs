using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfiguration", menuName = "Wave Configuration")]
public class WaveConfiguration : ScriptableObject
{
    [SerializeField] private float delayBeforeWaveStarts;
    [SerializeField] private float enemiesTimeToReachPlayer;
    [SerializeField] private SubWave[] subWaves;

    public float DelayBeforeWaveStarts => delayBeforeWaveStarts;

    public float EnemiesTimeToReachPlayer => enemiesTimeToReachPlayer;

    public SubWave[] SubWaves => subWaves;

    [Serializable]
    public struct SubWave
    {
        [SerializeField] private float delayBeforeStart;
        [SerializeField] private int enemiesAmount;
        [SerializeField] private float spawnDelay;
        [SerializeField] private SubWaveVulnerabilities vulnerabilities;

        public float DelayBeforeStart => delayBeforeStart;

        public int EnemiesAmount => enemiesAmount;

        public float SpawnDelay => spawnDelay;

        public SubWaveVulnerabilities Vulnerabilities => vulnerabilities;

        [Serializable]
        public struct SubWaveVulnerabilities
        {
            [SerializeField] private int uniqueSimpleAmount;
            [SerializeField] private int uniqueComplexAmount;

            public int UniqueSimpleAmount => uniqueSimpleAmount;

            public int UniqueComplexAmount => uniqueComplexAmount;
        }
    }
}