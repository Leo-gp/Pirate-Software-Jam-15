using PrimeTween;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] private Cauldron cauldron;
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private SpriteRenderer crystalSprite;
    [SerializeField] private ParticleSystem energyParticleEffect;
    [SerializeField] private ParticleSystem explosionParticleEffect;
    [SerializeField] private TweenSettings<float> floatingTweenSettings;
    [SerializeField] private TweenSettings<Vector3> attackPositionTweenSettings;
    [SerializeField] private TweenSettings<Vector3> attackRotationTweenSettings;

    private Tween _floatingTween;

    private void Start()
    {
        RunFloatEffect();
    }

    public void Attack()
    {
        if (cauldron.CurrentMixture is null)
        {
            return;
        }
        var enemy = enemiesManager.GetLowestAliveEnemy();
        if (enemy != null)
        {
            PlayExplosionEffectAtPosition
            (
                (Vector2)enemy.ExplosionPositionGameObject.transform.position, cauldron.CurrentMixture.Color
            );
            enemy.Hit(cauldron.CurrentMixture);
        }
        AudioManager.Instance.AudioSource.PlayOneShot(attackSound);
        energyParticleEffect.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        cauldron.Clear();
        _floatingTween.isPaused = true;
        UpdateCrystalColor(Color.white);
        RunAttackEffect();
    }

    private void PlayExplosionEffectAtPosition(Vector3 position, Color color)
    {
        explosionParticleEffect.transform.position = position;
        PlayParticleEffectWithColor(explosionParticleEffect, color);
    }

    public void UpdateCrystalColor(Color color)
    {
        crystalSprite.color = color;
        if (color != Color.white)
        {
            PlayParticleEffectWithColor(energyParticleEffect, color);
        }
    }

    private void PlayParticleEffectWithColor(ParticleSystem particleSystem, Color color)
    {
        var particleEffectMain = particleSystem.main;
        particleEffectMain.startColor = color;
        particleSystem.Play();
    }

    private void RunFloatEffect()
    {
        _floatingTween = Tween.PositionY(transform, floatingTweenSettings);
    }

    private void RunAttackEffect()
    {
        Sequence.Create()
            .Group(Tween.Position(transform, attackPositionTweenSettings))
            .Group(Tween.Rotation(transform, attackRotationTweenSettings))
            .OnComplete(this, target => target.OnAttackEffectCompleted());
    }

    private void OnAttackEffectCompleted()
    {
        _floatingTween.isPaused = false;
    }
}