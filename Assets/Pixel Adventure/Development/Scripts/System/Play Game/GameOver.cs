using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class GameOver : MonoBehaviour
{
    // ———————————— fields ————————————
    bool _isLoading;
    Player player;


    [TitleGroup("Play Effects")]
    [SerializeField] AudioClip playSound;
    [SerializeField] Transition playTransition;


    [TitleGroup("Delay")]
    [SerializeField] float delayTimeToLoadScene = 2f;


    // ———————————— unity methods ————————————
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnHit.AddListener(Play);
    }

    // ———————————— level pass methods ————————————
    void Play()
    {
        if (_isLoading)
            return;

        _isLoading = true;

        PlaySound();
        Asyncs.Delay(PlayTransition, delayTimeToLoadScene / 4);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
