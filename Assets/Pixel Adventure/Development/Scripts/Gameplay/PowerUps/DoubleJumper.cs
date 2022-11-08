using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DoubleJumper : MonoBehaviour
{

    // ———————— fields ————————
    Player player;
    Animator animator;
    bool stay;

    [TitleGroup("Play")]
    [SerializeField, PreviewField] AudioClip jumpClickSound;


    // ———————— unity methods ————————

    void Start()
    {
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.OnDoubleJump.AddListener(Hit);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stay = true;
            player.canDoubleJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stay = false;
            player.canDoubleJump = false;
        }
    }

    void Hit()
    {
        if (stay)
        {
            animator.SetTrigger("Hit");

            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(jumpClickSound);
        }
    }
}
