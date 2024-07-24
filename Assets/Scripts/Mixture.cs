using UnityEngine;

public class Mixture : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private MixtureComplexity complexity;

    public Color Color => color;

    public MixtureComplexity Complexity => complexity;
}