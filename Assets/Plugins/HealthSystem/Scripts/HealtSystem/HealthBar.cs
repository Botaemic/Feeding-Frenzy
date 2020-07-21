using UnityEngine;

namespace Botaemic.Unity.HealthSystems
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem healthSystem = null;
        [SerializeField]
        private Transform bar = null;

        public void Setup(HealthSystem healthSystem)
        {
            this.healthSystem = healthSystem;
        }

        private void Update()
        {
            if (healthSystem != null)
            {
                bar.localScale = new Vector3(healthSystem.HealthPercentage, 1);
            }
        }
    }
}
