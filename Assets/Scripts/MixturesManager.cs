using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MixturesManager : MonoBehaviour
{
    [SerializeField] private Recipe[] recipes;
    [SerializeField] private Mixture flawedMixture;

    private Mixture[] _simpleMixtures;
    private Mixture[] _complexMixtures;

    private void Awake()
    {
        var mixtures = FindObjectsOfType<Mixture>();
        var validMixtures = mixtures.Where(mixture => mixture != flawedMixture).ToArray();
        _simpleMixtures = validMixtures.Where(mixture => mixture.Complexity == MixtureComplexity.Simple).ToArray();
        _complexMixtures = validMixtures.Where(mixture => mixture.Complexity == MixtureComplexity.Complex).ToArray();
    }

    public Mixture GetMixtureFromIngredients(List<Ingredient> ingredients)
    {
        var recipe = recipes.FirstOrDefault
        (
            recipe => recipe.Ingredients.Count == ingredients.Count &&
                      recipe.Ingredients.TrueForAll(ingredients.Contains)
        );
        return recipe.Mixture ? recipe.Mixture : flawedMixture;
    }

    public Mixture GetRandomSimpleMixture()
    {
        return _simpleMixtures[Random.Range(0, _simpleMixtures.Length)];
    }

    public Mixture GetRandomComplexMixture()
    {
        return _complexMixtures[Random.Range(0, _complexMixtures.Length)];
    }
}