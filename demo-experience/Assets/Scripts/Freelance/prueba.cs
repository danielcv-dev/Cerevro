using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioVoz;
    public List<AnimationManager.animationsEnum> animEnum;
    public List<AnimationManager.animationsEnum> animEnumExit;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Test", 1);  
    }

    public void Test()
    {
        
        //AnimationManager anim = FindObjectOfType<AnimationManager>();
        //StartCoroutine(anim.PlayAnimationWithSound(animEnum, animEnumExit, audioVoz, ));
    }

}
