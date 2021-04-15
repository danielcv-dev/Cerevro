using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    
    public enum animationsEnum
    {
        Idle,
        TalkOne,
        TalkTwo,
        Walk
    }
    
    [Tooltip("Agregar animator del modelo")]
    public Animator animator;
    [Tooltip("Agregar clip de audio")]
    [SerializeField] AudioClip voz;
    [Tooltip("Agregar AudioSource")]
    [SerializeField] AudioSource audioSource;
    [Tooltip("Select if you change the target when the animation and sound is finished")]
    public Transform nextTargetPoss;

    public bool animIsPlaying = false;
    private IEnumerator animationCorutine;
    private Collider colliderPeople;

    // Start is called before the first frame update
    void Start(){}


    public void StartAnimationCorutine(List<animationsEnum> animations, List<animationsEnum> animationExit, AudioClip[] _voz, Animator _animator, Collider _collider, Transform nextTargetPoss = null, AudioSource _audioSource = null)
    {
        
        if (_voz.Length > 0) {
            if (!animIsPlaying)
            {
                animIsPlaying = false;
                animationCorutine = PlayAnimationWithSound(animations, animationExit, _voz, _animator, nextTargetPoss, _audioSource);
                colliderPeople = _collider;
                colliderPeople.enabled = false;
                StartCoroutine(animationCorutine);
            }
            else
            {
                colliderPeople.enabled = true;
                StopCoroutine(animationCorutine);
                SetTriggerAnimation(animationExit[animationExit.Count-1].ToString());
                if (nextTargetPoss != null)
                {
                    GameObject.FindObjectOfType<WaypontTargetVR>().PushTargets(nextTargetPoss);
                }
                GameObject.FindObjectOfType<WaypontTargetVR>().PopTargets();
                animationCorutine = PlayAnimationWithSound(animations, animationExit, _voz, _animator, nextTargetPoss, _audioSource);
                StartCoroutine(animationCorutine);
            }
        }
        else
        {
            if (!animIsPlaying)
            {
                colliderPeople.enabled = false;
                animIsPlaying = true;
                animationCorutine = PlayAnimation(animations, animationExit);
                StartCoroutine(animationCorutine);
            }
        }
    } 

    //
    // Resumen:
    //     Reproduce la animacion correspondiente al enum
    //
    // Parámetros
    //     animations:
    //     animationsExit
    //     _voz:
    // Parámetros opcionales:
    //     _audioSource:
    
    public IEnumerator PlayAnimationWithSound(List<animationsEnum> animations, List<animationsEnum> animationExit, AudioClip[] _voz, Animator _animator, Transform nextTargetPoss = null, AudioSource _audioSource = null)
    {
        animIsPlaying = true;
        animator = _animator;

        if (animations.Count == animationExit.Count && animations.Count == _voz.Length && _voz.Length == animationExit.Count) {
            audioSource = _audioSource;
            int count = 0;
            foreach (animationsEnum animation in animations)
            {
                SetTriggerAnimation(animation.ToString());

                if (_audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }

                audioSource.clip = _voz[count];
                audioSource.loop = false;
                audioSource.Play();

                yield return new WaitForSeconds(_voz[count].length + .05f);
                Destroy(GetComponent<AudioSource>());
                if (count < _voz.Length)
                {
                    colliderPeople.enabled = true;
                    SetTriggerAnimation(animationExit[count].ToString());
                    count++;
                }
                else
                {
                    colliderPeople.enabled = true;
                    SetTriggerAnimation(animationExit[count].ToString());
                }

                if (nextTargetPoss != null)
                {
                    GameObject.FindObjectOfType<WaypontTargetVR>().PushTargets(nextTargetPoss);
                }
                GameObject.FindObjectOfType<WaypontTargetVR>().PopTargets();
            }
        }
        else
        {
            Debug.LogError("Falta algun elemento en animations, animationExit, audio");
        }

        animIsPlaying = false;
    
    }

    //
    // Parámetros
    //     animations:
    //     animationsExit
    //     _

    public IEnumerator PlayAnimation(List<animationsEnum> animations, List<animationsEnum> animationExit)
    {
        if (animations.Count == animationExit.Count )
        {
            int count = 0;
            foreach (animationsEnum animation in animations)
            {
                print(animation.ToString());
                SetTriggerAnimation(animation.ToString());
                
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
                SetTriggerAnimation(animationExit[count].ToString());
                
            }
        }
        else
        {
            Debug.LogError("Falta algun elemento en animations o animationExit");
        }
    }

    

    //
    // Resumen:
    //     Activa el trigger de la animacion correspondiente
    //
    // Parámetros
    //     nameTrigger:
    private void SetTriggerAnimation(string nameTrigger)
    {
        
        if (animator != null) 
            animator.SetTrigger(nameTrigger);
        else
            Debug.LogError("No existe animator asignado");
    }

    

}
