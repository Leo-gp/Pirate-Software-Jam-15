using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private MixturesManager mixturesManager;
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private SpriteRenderer mixtureSprite;

    private readonly List<Ingredient> _ingredients = new();

    private Mixture _mixture;

    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
        UpdateIngredientsPositions();
        UpdateMixture();
    }

    public void LaunchMixture()
    {
        if (_mixture is null)
        {
            return;
        }
        var enemy = enemiesManager.GetLowestEnemy();
        if (enemy != null)
        {
            enemy.Hit(_mixture);
        }
        Clear();
    }

    private void UpdateIngredientsPositions()
    {
        var lastIngredient = _ingredients[^1];
        if (_ingredients.Count > 1)
        {
            var ingredientBeforeLast = _ingredients[^2];
            if (ingredientBeforeLast == lastIngredient)
            {
                return;
            }
            MoveIngredientAwayFromCauldron(ingredientBeforeLast);
            MoveIngredientIntoCauldron(lastIngredient);
        }
        else
        {
            MoveIngredientIntoCauldron(lastIngredient);
        }
    }

    private static void MoveIngredientIntoCauldron(Ingredient ingredient)
    {
        var tr = ingredient.transform;
        var position = tr.localPosition;
        tr.localPosition = new Vector2(position.x, position.y += 0.5f);
    }

    private static void MoveIngredientAwayFromCauldron(Ingredient ingredient)
    {
        var tr = ingredient.transform;
        var position = tr.localPosition;
        tr.localPosition = new Vector2(position.x, position.y -= 0.5f);
    }

    private void UpdateMixture()
    {
        _mixture = mixturesManager.GetMixtureFromIngredients(_ingredients);
        mixtureSprite.color = _mixture.Color;
    }

    private void Clear()
    {
        _mixture = null;
        mixtureSprite.color = Color.white;
        if (_ingredients.Count > 0)
        {
            MoveIngredientAwayFromCauldron(_ingredients[^1]);
        }
        _ingredients.Clear();
    }
}