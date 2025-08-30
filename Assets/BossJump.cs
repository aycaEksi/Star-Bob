using System.Collections;
using UnityEngine;
using static CartoonFX.CFXR_Effect;

public class BossJump : MonoBehaviour
{
    public float jumpForce = 5f;           // Z�plama kuvveti
    public float jumpInterval = 2f;        // Ka� saniyede bir z�plas�n
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpInterval);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CameraShake.Instance.Shake(); // Kamera sallans�n
        }
    }

}
