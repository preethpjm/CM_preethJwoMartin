using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            SfxManager._insatnce.Play_Damage();
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
        }
    }
}