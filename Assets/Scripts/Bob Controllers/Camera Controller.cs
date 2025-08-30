using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject bob;

    void Start()
    {
        bob = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (bob == null)
        {
            return;
        }

        // Kameranm�n derinli�inin etkilenmemesi i�in bu 3 sat�r var. Sadece x ve y Bob'un pozisyonuna e�itlenmeli
        // Ayr�ca kamera Bob'dan biraz yukar�da olmal�
        var p = bob.transform.position;
        p.z = transform.position.z;
        p.y += 2f;


        transform.position = p;
    }
}
