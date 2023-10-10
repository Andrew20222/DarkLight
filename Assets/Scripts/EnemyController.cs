using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Transform _player;

    public void Init(Transform player)
    {
        _player = player;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMove playerMove))
        {
            playerMove.GetComponent<IHealth>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (_player == null) return;

        if(GameLogic.IsFreezeTime == false)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, Time.deltaTime * speed);
    }
}
