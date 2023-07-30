using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SfxManager._insatnce.Play_Damage();
            other.GetComponent<PlayerController>().TakeDamage(damageAmount);
        }
    }
}