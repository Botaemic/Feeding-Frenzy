using UnityEngine;
using UnityEngine.UI;

namespace Botaemic.Unity.HealthSystems
{
    public class HealthBarCanvas : MonoBehaviour
    {
        private HealthSystem healthSystem = null;
        [SerializeField]
        private Image bar = null;

        public void Setup(HealthSystem healthSystem)
        {
            this.healthSystem = healthSystem;
        }

        private void Update()
        {
            if (healthSystem != null)
            {
                bar.fillAmount = healthSystem.HealthPercentage;
            }
        }
    }
}
