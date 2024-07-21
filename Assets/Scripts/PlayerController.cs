using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputActions.IPlayerActions
{
    [SerializeField] private Cauldron cauldron;
    [SerializeField] private IngredientsManager ingredientsManager;

    private void Start()
    {
        var inputActions = new InputActions();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
    }

    public void OnAddBlueIngredient(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cauldron.AddIngredient(ingredientsManager.BlueIngredient);
        }
    }

    public void OnAddYellowIngredient(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cauldron.AddIngredient(ingredientsManager.YellowIngredient);
        }
    }

    public void OnAddRedIngredient(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cauldron.AddIngredient(ingredientsManager.RedIngredient);
        }
    }

    public void OnLaunchMixture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            cauldron.LaunchMixture();
        }
    }
}