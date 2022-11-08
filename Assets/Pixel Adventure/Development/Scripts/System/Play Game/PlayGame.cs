
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class PlayGame : MonoBehaviour
{
    // ———————— fields ————————
    bool _isLoading;

    [SerializeField] Button playGameButton;


    [TitleGroup("Play Effects")]

    [SerializeField] AudioClip playSound;
    [SerializeField] Transition playTransition;


    [TitleGroup("Delay")]
    [SerializeField] float delayTimeToLoadScene = 1f;



    // ———————— unity methods ————————
    void Start()
    {
        playGameButton.onClick.AddListener(Play);
    }

    void Update()
    {
        if (Input.anyKeyDown & !_isLoading)
        {
            Play();
        }
    }



    // ———————— play game methods ————————

    void Play()
    {
        _isLoading = true;
        playGameButton.interactable = false;
        playGameButton.onClick.RemoveListener(Play);

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
        SceneManager.LoadScene(1);
    }
}