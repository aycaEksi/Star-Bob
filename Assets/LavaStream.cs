using UnityEngine;

public class LavaStream : MonoBehaviour
{
    public float streamSpeed = 0.5f; // Lav�n nesneyi s�r�kledi�i h�z
    public Vector2 streamDirection = Vector2.right; // Sa�a s�r�kl�yor

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Yava� ama sabit bir yatay hareket uygula (h�z ekle de�il, do�rudan uygula)
            Vector2 velocity = rb.linearVelocity;
            velocity.x = streamDirection.normalized.x * streamSpeed;
            rb.linearVelocity = velocity;
        }
    }
}
