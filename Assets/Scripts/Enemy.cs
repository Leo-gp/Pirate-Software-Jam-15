using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PrimeTween;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly int DieAnimationTrigger = Animator.StringToHash("Die");

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip deathAnimationClip;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private SpriteRenderer bodySpriteRenderer;
    [SerializeField] private GameObject umbrellaGameObject;
    [SerializeField] private GameObject explosionPositionGameObject;
    [SerializeField] private float fadeOutOnDeathTime;
    [SerializeField] private SpriteRenderer[] vulnerabilitiesSprites;
    [SerializeField] private float startScale;
    [SerializeField] private float endScale;

    private readonly Dictionary<Mixture, List<SpriteRenderer>> _vulnerabilitiesSpritesDict = new();

    private float _timeToReachPlayer;
    private List<Mixture> _totalVulnerabilities;
    private List<Mixture> _remainingVulnerabilities;

    public Action<Enemy> Died { get; set; }

    public bool IsAlive { get; private set; }

    public GameObject ExplosionPositionGameObject => explosionPositionGameObject;

    public void Initialize(float timeToReachPlayer, List<Mixture> vulnerabilities)
    {
        Tween.StopAll(transform);
        _timeToReachPlayer = timeToReachPlayer;
        IsAlive = true;
        Activate();
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
        Tween.Scale(transform, startScale, endScale, _timeToReachPlayer, Ease.Linear);
    }

    private void OnReachedPlayer()
    {
        playerManager.Hit();
        Die();
    }

    private void Die()
    {
        Tween.StopAll(transform);
        StartCoroutine(RunDieAnimation());
        IsAlive = false;
        Died?.Invoke(this);
        Died = null;
    }

    private IEnumerator RunDieAnimation()
    {
        if (playerManager.IsDead)
        {
            yield break;
        }
        AudioManager.Instance.AudioSource.PlayOneShot(deathSound);
        umbrellaGameObject.SetActive(false);
        animator.SetTrigger(DieAnimationTrigger);
        yield return new WaitForSeconds(deathAnimationClip.length);
        Tween.Alpha(bodySpriteRenderer, 0f, fadeOutOnDeathTime, Ease.Linear)
            .OnComplete(this, target => target.Deactivate());
    }

    private void Activate()
    {
        gameObject.SetActive(true);
        umbrellaGameObject.SetActive(true);
        var bodySpriteColor = bodySpriteRenderer.color;
        bodySpriteColor.a = 1f;
        bodySpriteRenderer.color = bodySpriteColor;
    }

    private void Deactivate()
    {
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