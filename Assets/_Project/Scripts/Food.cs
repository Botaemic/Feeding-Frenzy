using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    Herbivore,
    Carnivore,
    Omnivore
} 


public class Food : MonoBehaviour
{
    [SerializeField] private FoodType _foodType = FoodType.Herbivore;
    [SerializeField] private Sprite _icon = null;

    public FoodType FoodType { get => _foodType; }
    public Sprite Icon { get => _icon;  }
}
