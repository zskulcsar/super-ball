using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {
    private static float SFX = 0;
    private static float SFZ = -4.5f;

    private static float FORCE_MULTI = 5.0f;
    private static int PICKUPS_LAYER = 8;

    private static float EXP_FORCE = 15.0f;
    private static float EXP_RADIUS = 2.0f;
    private static float EXP_UP_MOD = 2.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move the thing
        if (rb.position.y < 0.6) // ie.: if we are not in the "air"
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * FORCE_MULTI;
            float moveVertical = Input.GetAxis("Vertical") * FORCE_MULTI;

            Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == PICKUPS_LAYER) {
            rb.AddExplosionForce(EXP_FORCE, transform.position, EXP_RADIUS, EXP_UP_MOD, ForceMode.Impulse);
            Explode();
        }
    }

    private void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }
}