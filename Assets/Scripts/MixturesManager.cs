using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MixturesManager : MonoBehaviour
{
    [SerializeField] private Recipe[] recipes;
    [SerializeField] private Mixture flawedMixture;

    private Mixture[] _validMixtures;

    private void Awake()
    {
        var mixtures = FindObjectsOfType<Mixture>();
        _validMixtures = mixtures.Where(mixture => mixture != flawedMixture).ToArray();
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

    public Mixture GetRandomMixture()
    {
        return _validMixtures[Random.Range(0, _validMixtures.Length)];
    }
}