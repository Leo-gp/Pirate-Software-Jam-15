using UnityEngine;

public class IngredientsManager : MonoBehaviour
{
    [SerializeField] private Ingredient blueIngredient;
    [SerializeField] private Ingredient yellowIngredient;
    [SerializeField] private Ingredient redIngredient;

    public Ingredient BlueIngredient => blueIngredient;

    public Ingredient YellowIngredient => yellowIngredient;

    public Ingredient RedIngredient => redIngredient;
}