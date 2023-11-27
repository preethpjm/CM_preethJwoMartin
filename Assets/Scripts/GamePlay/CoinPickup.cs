using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SfxManager._insatnce.Play_Collected();
            collision.gameObject.GetComponent<PlayerController>().CollectCoin(coinValue);

            Destroy(gameObject);
        }
    }
}
