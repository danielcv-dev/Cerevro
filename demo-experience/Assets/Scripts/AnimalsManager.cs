using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsManager : MonoBehaviour
{

    public SceneAnimatorController[] cats;

    void Start()
    {
      cats[0].SetAnimatorString("isSleeping");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
