using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class LevelPass : MonoBehaviour
{
    // ———————————— fields ————————————
    bool _isLoading;
    [SerializeField] private int nextLevelIndex;


    [TitleGroup("Play Effects")]
    [SerializeField] AudioClip playSound;
    [SerializeField] Transition playTransition;


    [TitleGroup("Delay")]
    [SerializeField] float delayTimeToLoadScene = 1f;


    // ———————————— unity methods ————————————
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Play();
        }
    }

    // ———————————— level pass methods ————————————
    void Play()
    {
        if (_isLoading)
            return;

        _isLoading = true;

        PlaySound();
        PlayTransition();
        Asyncs.Delay(LoadScene, delayTimeToLoadScene);
    }

    void PlaySound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(playSound);
        Destroy(audioSource, playSound.length);
    }

    void PlayTransition()
    {
        playTransition.ClosingTransition();
    }

    void LoadScene()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
}
