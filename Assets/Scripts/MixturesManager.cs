using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MixturesManager : MonoBehaviour
{
    [SerializeField] private Recipe[] recipes;
    [SerializeField] private Mixture flawedMixture;

    public Mixture GetMixtureFromIngredients(List<Ingredient> ingredients)
    {
        var recipe = recipes.FirstOrDefault
        (
            recipe => recipe.Ingredients.Count == ingredients.Count &&
                      recipe.Ingredients.TrueForAll(ingredients.Contains)
        );
        return recipe.Mixture ? recipe.Mixture : flawedMixture;
    }
}