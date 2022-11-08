using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    // ———————— fields ————————

    [SerializeField] List<GameObject> backgrounds;
    [SerializeField] List<RuntimeAnimatorController> animations;

    // ———————— unity methods ————————

    void Start()
    {
        int backgroundIndex = Random.Range(0, backgrounds.Count);
        GameObject backgroundGenerated = Instantiate(backgrounds[backgroundIndex], transform);

        int animationIndex = Random.Range(0, animations.Count);
        backgroundGenerated.AddComponent<Animator>().runtimeAnimatorController = animations[animationIndex];
    }
}
