using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Botaemic.Unity.HealthSystems
{
    public class HealthSystem
    {
        private float healthPoints = 10f;
        private float maximumHealthPoints = 10f;

        private float shieldPoints = 10f;
        private float maximumShieldPoints = 10f;

        public float HealthPercentage { get => (healthPoints / maximumHealthPoints); }
        public float HealthPoints { get => healthPoints; set => healthPoints = value; }

        public float ShieldPercentage { get => (shieldPoints / maximumShieldPoints); }
        public float ShieldPoints { get => shieldPoints; set => shieldPoints = value; }

        private bool hasShield = false;

        public HealthSystem( float maximumHealthPoints, float maximumShieldPoints, bool hasShield = false)
        {
            this.maximumHealthPoints = maximumHealthPoints;
            HealthPoints = maximumHealthPoints;

            this.maximumShieldPoints = maximumShieldPoints;
            ShieldPoints = maximumShieldPoints;

            this.hasShield = hasShield; 

        }

        public void Damage( float damageAmount)
        {
            if (ShieldPoints > Mathf.Epsilon)
            {
                shieldPoints -= damageAmount;
            }
            else
            {
                HealthPoints -= damageAmount;
            }
            if (HealthPoints < 0) { HealthPoints = 0; }
            if (shieldPoints < 0) { shieldPoints = 0; }
        }

        public void Heal(float healAmount)
        {
            HealthPoints += healAmount;
            if (HealthPoints > maximumHealthPoints) { HealthPoints = maximumHealthPoints; }
        }

        public void RechargeShield(float amount)
        {
            if (hasShield)
            {
                ShieldPoints += amount;
                if (ShieldPoints > maximumShieldPoints) { ShieldPoints = maximumShieldPoints; }
            }
        }
    }
}
