using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Botaemic.Unity.HealthSystems
{
    public class HealthPortrait : MonoBehaviour
    {
        private HealthSystem healthSystem;
        [SerializeField]
        private Image currentHealth = null;
        [SerializeField]
        private Image secondayBar = null;


        public void Setup(HealthSystem healthSystem)
        {
            this.healthSystem = healthSystem;
        }

        private void Update()
        {
            if (currentHealth)
            {
                currentHealth.fillAmount = healthSystem.HealthPercentage;
            }
            if (secondayBar)
            {
                secondayBar.fillAmount = healthSystem.ShieldPercentage;
            }
        }

    }
}