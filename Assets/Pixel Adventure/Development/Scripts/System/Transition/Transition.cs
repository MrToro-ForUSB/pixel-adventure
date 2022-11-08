using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Transition : MonoBehaviour
{
    // ———————— fields ————————
    Animator animator;

    [SerializeField] bool playOnAwake;

    [ShowIf("playOnAwake")]
    [SerializeField] float delayTimeToDestroy = 2;



    // ———————— unity methods ————————

    void Start()
    {
        animator = GetComponent<Animator>();

        if (playOnAwake)
        {
            OpeningTransition();
        }
    }



    // ———————— transition methods ————————

    public void OpeningTransition()
    {
        animator.SetTrigger("OpeningTransition");
        Asyncs.Delay(DestroyTransition, delayTimeToDestroy);
    }

    public void ClosingTransition()
    {
        animator.SetTrigger("ClosingTransition");
    }

    void DestroyTransition()
    {
        Destroy(gameObject);
    }
}
