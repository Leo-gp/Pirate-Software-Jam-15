using System.Collections.Generic;
using System.Linq;
using PrimeTween;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private SpriteRenderer[] vulnerabilitiesSprites;
    [SerializeField] private float _timeToReachPlayer;

    private readonly Dictionary<Mixture, List<SpriteRenderer>> _vulnerabilitiesSpritesDict = new();
    private List<Mixture> _totalVulnerabilities;
    private List<Mixture> _remainingVulnerabilities;

    public void Initialize(List<Mixture> vulnerabilities)
    {
        Tween.StopAll(transform);
        InitializeVulnerabilities(vulnerabilities);
    }

    public void Hit(Mixture mixture)
    {
        var hasVulnerability = _remainingVulnerabilities.Any(vulnerability => vulnerability == mixture);
        if (!hasVulnerability)
        {
            return;
        }
        var hitSprites = _vulnerabilitiesSpritesDict[mixture];
        hitSprites.ForEach(sprite => sprite.color = Color.black);
        _remainingVulnerabilities.RemoveAll(vulnerability => vulnerability == mixture);
        if (_remainingVulnerabilities.Count is 0)
        {
            Die();
        }
    }

    public void ApproachPlayer()
    {
        Tween.PositionY(transform, playerManager.PlayerPosition.position.y, _timeToReachPlayer, Ease.Linear)
            .OnComplete(this, target => target.OnReachedPlayer());
    }

    private void OnReachedPlayer()
    {
        playerManager.Hit();
        Die();
    }

    private void Die()
    {
        Tween.StopAll(transform);
        gameObject.SetActive(false);
    }

    private void InitializeVulnerabilities(List<Mixture> vulnerabilities)
    {
        _totalVulnerabilities = vulnerabilities;
        _remainingVulnerabilities = _totalVulnerabilities;
        _vulnerabilitiesSpritesDict.Clear();
        for (var i = 0; i < _totalVulnerabilities.Count; i++)
        {
            var vulnerability = _totalVulnerabilities[i];
            if (_vulnerabilitiesSpritesDict.TryGetValue(vulnerability, out var sprites))
            {
                sprites.Add(vulnerabilitiesSprites[i]);
            }
            else
            {
                _vulnerabilitiesSpritesDict.Add(vulnerability, new List<SpriteRenderer> { vulnerabilitiesSprites[i] });
            }
            vulnerabilitiesSprites[i].color = vulnerability.Color;
        }
    }
}