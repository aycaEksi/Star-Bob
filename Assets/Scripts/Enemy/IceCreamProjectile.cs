using UnityEngine;

public class IceCreamProjectile : MonoBehaviour
{
    public float lifeTime = 5f;

    private void Start()
    {
        // 5 saniye sonra kendi kendine yok olsun
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        // D��man harici her �eye �arpt���nda yok et
        if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
