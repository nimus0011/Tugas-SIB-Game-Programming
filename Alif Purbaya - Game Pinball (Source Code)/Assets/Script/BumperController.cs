using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    private Renderer renderer;
    private Animator animator;

    public ScoreManager scoreManager;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            animator.SetTrigger("hit");
            audioManager.PlaySFX(collision.transform.position);

            vfxManager.PlayVFX(collision.transform.position);
        }
        if (collision.collider == bola)
        {
            scoreManager.AddScore(score);
        }
    }
}
