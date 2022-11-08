using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Fruit : MonoBehaviour
{
    // ———————————— fields ————————————
    Animator animator;

    [TitleGroup("Audio")]
    [SerializeField, PreviewField] AudioClip fruitSound;

    // ———————————— unity methods ————————————

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }


    // ———————————— fruit methods ————————————

    void Collect()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(fruitSound);

        animator.SetTrigger("Hit");

        Destroy(this);
        Destroy(gameObject, 0.3f);
    }
}
