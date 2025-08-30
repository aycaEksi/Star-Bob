
using System;
using UnityEngine;


public class EnemyCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            // Oyuncunun pozisyonu d��mandan yukar�daysa ve ger�ekten yukar�dan �arpm��sa
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 enemyPosition = collision.gameObject.transform.position;

            if (contactPoint.y > enemyPosition.y + 0.3f) // 0.3 de�eri d��man�n y�ksekli�ine g�re ayarlanabilir
            {
                Collider2D enemyCollider = collision.collider;
                enemyCollider.isTrigger = false;

                // �stten �arpt� ? d��man �ls�n
                Destroy(collision.gameObject);

                // Oyuncuyu biraz z�plat (iste�e ba�l�)
               
            }

        }
    }


}
