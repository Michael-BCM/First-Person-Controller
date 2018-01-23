using UnityEngine;

public class Recipe : MonoBehaviour
{
    enum IngredientUnit { Teaspoon, Tablespoon, Cup, Bowl, Piece }

    [System.Serializable]
    public class Ingredient
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int amount;
        [SerializeField]
        private IngredientUnit unit;
    }

    [SerializeField]
    private Ingredient potionResult;

    [SerializeField]
    private Ingredient[] potionIngredients;
}


