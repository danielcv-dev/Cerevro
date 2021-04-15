using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
public class ShowInfo : MonoBehaviour
{
    [Header("Info text")]
    [Tooltip("Write the information to show when the raycast hit the boxcollider")]
    [TextArea]
    public string infoText;
    [Tooltip("Assign the text area")]
    public Text textArea;
    [Header("Camera")]
    [Tooltip("Assign the tag of the main camera to look at the camera")]
    public string cameraTag;
    private GameObject mainCamera;
    [Header("Sprites")]
    [Tooltip("Assign the icon sprite, if is empty search in the first chhild an icon")]
    public GameObject iconInfo;
    public GameObject imageInformation;
    [Header("Animator")]
    [Tooltip("Assign the animator to play the animations")]
    public Animator animator;

    
    
    private void Start(){
        if (iconInfo == null) {
            iconInfo = transform.GetChild(0).gameObject;
        }
        
        textArea.text = infoText;
        mainCamera = GameObject.FindGameObjectWithTag(cameraTag);
    }

    private void Update()
    {
        iconInfo.transform.LookAt(mainCamera.transform);
        imageInformation.transform.LookAt(mainCamera.transform);
    }

    public void HitByRaycast()
    {
        print("hitt");
        animator.SetBool("ActiveFadeOut", false);
        animator.SetBool("ActiveFadeIn",true);
    }

    public void HitOutByRaycast()
    {
        print("hi outt");
        animator.SetBool("ActiveFadeIn", false);
        animator.SetBool("ActiveFadeOut", true);
    }




}
