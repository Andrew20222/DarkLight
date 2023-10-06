using UnityEngine;

namespace Scripts.Healths
{
    public class GroundDetection : MonoBehaviour
    {
        [SerializeField] private float damage;
        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.gameObject.GetComponent<PlayerMove>();
            
            if (player)
            {
                player.GetComponent<IHealth>().TakeDamage(damage);
            }
        }
    }
}