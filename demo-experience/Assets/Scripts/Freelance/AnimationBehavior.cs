using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{

    public AudioSource audioSource;
    public Animator animator;
    public Transform nextTargetPos;
    public AudioClip[] audioVoz;
    public List<AnimationManager.animationsEnum> animEnum;
    public List<AnimationManager.animationsEnum> animEnumExit;
    public Collider colliderPeople;

    public void StartAnimationWithSoundSpeak()
    {
        colliderPeople = GetComponent<Collider>();
        AnimationManager anim = FindObjectOfType<AnimationManager>();
        anim.StartAnimationCorutine(animEnum, animEnumExit, audioVoz, animator, colliderPeople,nextTargetPos, audioSource);
    }
}
