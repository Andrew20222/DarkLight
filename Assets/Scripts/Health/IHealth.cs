using System;

public interface IHealth
{
    public event Action OnDie;
    public void TakeDamage(float damage);
}
