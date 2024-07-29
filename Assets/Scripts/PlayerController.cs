using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputActions.IPlayerActions, InputActions.IUIActions
{
    [SerializeField] private Cauldron cauldron;
    [SerializeField] private Staff staff;
    [SerializeField] private IngredientsManager ingredientsManager;
    [SerializeField] private PauseManager pauseManager;

    private InputActions _inputActions;

    private void OnEnable()
    {
        _inputActions = new InputActions();
        _inputActions.Player.SetCallbacks(this);
        _inputActions.UI.SetCallbacks(this);
        _inputActions.Player.Enable();
        _inputActions.UI.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.RemoveCallbacks(this);
        _inputActions.UI.RemoveCallbacks(this);
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

    public void OnStaffAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            staff.Attack();
        }
    }

    public void OnTogglePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pauseManager.TogglePauseMenu();
        }
    }

    public void DisablePlayerInput()
    {
        _inputActions.Player.Disable();
    }

    public void EnablePlayerInput()
    {
        _inputActions.Player.Enable();
    }
}