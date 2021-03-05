using UnityEngine;

public interface IDamageable
{
    int health {get; set;}
    void TakeDamage(int amount);
}
