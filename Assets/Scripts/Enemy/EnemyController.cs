using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    public float hareketHizi = 2f;
    public float hareketMesafesi = 3f;
    public float donusHizi = 100f;
    public float gravityScale = 0.5f; // Hafif bir yer�ekimi

    private Vector2 baslangicPozisyonu;
    private bool sagaGidiyor = true;
    private Rigidbody2D rb;

    void Start()
    {
        baslangicPozisyonu = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        rb.freezeRotation = true; // Fiziksel rotasyonu dondur
    }

    void Update()
    {
        // Karakterin hareket y�n�ne g�re d�n�� y�n�n� ayarla
        float donusYon = sagaGidiyor ? -1f : 1f;
        transform.Rotate(0f, 0f, donusYon * donusHizi * Time.deltaTime);
    }

    void FixedUpdate()
    {
        float hareketYonu = sagaGidiyor ? 1 : -1;
        Vector2 hareket = new Vector2(hareketYonu * hareketHizi, rb.linearVelocity.y);
        rb.linearVelocity = hareket;

        if (sagaGidiyor && transform.position.x >= baslangicPozisyonu.x + hareketMesafesi)
        {
            sagaGidiyor = false;
        }
        else if (!sagaGidiyor && transform.position.x <= baslangicPozisyonu.x - hareketMesafesi)
        {
            sagaGidiyor = true;
        }

        // Zemin kontrol� ve yere bast�rma
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f);
        if (!raycastHit.collider)
        {
            // E�er zemin yoksa, a�a��ya do�ru hafif bir kuvvet uygula
            rb.AddForce(Vector2.down * 5f);
        }
    }
}
