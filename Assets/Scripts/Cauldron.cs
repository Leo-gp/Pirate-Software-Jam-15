using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private MixturesManager mixturesManager;
    [SerializeField] private Staff staff;
    [SerializeField] private SpriteRenderer mixtureSprite;

    private readonly List<Ingredient> _ingredients = new();

    public Mixture CurrentMixture { get; private set; }

    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
        UpdateIngredientsPositions();
        UpdateMixture();
        staff.UpdateCrystalColor(CurrentMixture.Color);
    }

    public void Clear()
    {
        CurrentMixture = null;
        mixtureSprite.color = Color.white;
        if (_ingredients.Count > 0)
        {
            _ingredients[^1].PutOnTable();
        }
        _ingredients.Clear();
    }

    private void UpdateIngredientsPositions()
    {
        var lastIngredient = _ingredients[^1];
        if (_ingredients.Count > 1)
        {
            var ingredientBeforeLast = _ingredients[^2];
            if (ingredientBeforeLast == lastIngredient)
            {
                lastIngredient.PutOnCauldron();
                return;
            }
            ingredientBeforeLast.PutOnTable();
            lastIngredient.PutOnCauldron();
        }
        else
        {
            lastIngredient.PutOnCauldron();
        }
    }

    private void UpdateMixture()
    {
        CurrentMixture = mixturesManager.GetMixtureFromIngredients(_ingredients);
        mixtureSprite.color = CurrentMixture.Color;
    }
}