using Botaemic.Unity.HealthSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private FoodType _eats = FoodType.Herbivore;
    [SerializeField] private int _hunger = 3;
    [SerializeField] private int _scorePoints = 1;
    [SerializeField] private HealthBar _healthBar = null;

    private HealthSystem healthSystem = null;

    private void Awake()
    {
        healthSystem = new HealthSystem(_hunger, 0, false);

        if (_healthBar != null) { _healthBar.Setup(healthSystem); }
        healthSystem.HealthPoints = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        Animal animal = other.GetComponent<Animal>();
        if (animal) { return; }

        Food food = other.GetComponent<Food>();
        if (food != null)
        {
            if (food.FoodType == _eats)
            {
                healthSystem.Heal(1);
                
                if (healthSystem.HealthPoints >= _hunger)
                {
                    EventManager.Instance.OnAnimalKill?.Invoke(_scorePoints);
                    Destroy(gameObject);
                }
            }
            Destroy(other.gameObject);
        }
        else
        {
            EventManager.Instance.OnPlayerHit?.Invoke(1);
        }
    }
}
