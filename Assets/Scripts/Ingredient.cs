using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ingredientOnTableSprite;
    [SerializeField] private SpriteRenderer ingredientOnCauldronSprite;

    public void PutOnTable()
    {
        ingredientOnTableSprite.gameObject.SetActive(true);
        ingredientOnCauldronSprite.gameObject.SetActive(false);
    }

    public void PutOnCauldron()
    {
        ingredientOnCauldronSprite.gameObject.SetActive(true);
        ingredientOnTableSprite.gameObject.SetActive(false);
    }
}