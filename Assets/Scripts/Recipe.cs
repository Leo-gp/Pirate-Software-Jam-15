using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Recipe
{
    [SerializeField] private List<Ingredient> ingredients;
    [SerializeField] private Mixture mixture;

    public List<Ingredient> Ingredients => ingredients;

    public Mixture Mixture => mixture;
}