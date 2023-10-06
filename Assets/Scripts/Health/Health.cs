using System;
using UnityEngine;

namespace Scripts.Healths
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action OnDie;
        [SerializeField] private float health;
        
        public void TakeDamage(float damage)
        {
            health -= damage;
            Mathf.Clamp(health, 0, 100);
            
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
            OnDie?.Invoke();
        }
    }
}