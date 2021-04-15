using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypontTargetVR : MonoBehaviour
{
    [Header("3DModel reference")]
    [Tooltip("Reference of the model to mark the waypoint")]
    public GameObject model;
    [Header("Reference to cilinder")]
    [Tooltip("reference to offset the cilinder")]
    public GameObject cylinder;
    [Header("Targets")]
    [Tooltip("List of waypoint targets ")]
    public List<Transform> targets;
    
    [Header("Offset")]
    [Tooltip("The offset of the 3D model marker")]
    public Vector3 offset;
    [Tooltip("The offset of the cylinder")]
    public Vector3 cylinderOffset;
    private GameObject camera;
    [SerializeField] private float distance;
    


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count != 0) {
            distance = Vector3.Distance(camera.transform.position, targets[0].transform.position);

            model.transform.position = targets[0].position + offset;
            cylinder.transform.position = targets[0].position + cylinderOffset;
            distance = Vector3.Distance(camera.transform.position, targets[0].transform.position);

            model.transform.localScale = new Vector3(distance * 0.3f, distance * 0.3f, distance * 0.3f);
            //transform.localScale = new Vector3 (FixeScale/parent.transform.localScale.x,FixeScale/parent.transform.localScale.y,FixeScale/parent.transform.localScale.z);
            cylinder.transform.localScale = new Vector3(1 / model.transform.localScale.x, 1 / model.transform.localScale.y, 1 / model.transform.localScale.z);
            LookAtRotation(model.transform, camera);


        }
        else
        {
            model.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            PopTargets();
        }
    }

    //
    // Resumen:
    //     Hacer rotar hacia la camara
    //
    // Parámetros
    //     _target:
    //     _camera
    
    private void LookAtRotation(Transform _target, GameObject _camera)
    {
        Vector3 pos = _target.position - _camera.transform.position;
        pos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(pos, Vector3.down);
        
        _target.rotation = rotation;  
    }

    //
    // Resumen:
    //     Saca un elemento de la lista
    //
    public void PopTargets()
    {
        if (targets.Count >= 0 ) {
            targets.RemoveAt(0);
        }
        
    }

    //
    // Resumen:
    //     Ingresa un objetivo nuevo a la lista
    //
    // Parámetros
    //     newTarget
    //
    public void PushTargets(Transform newTarget)
    {
        model.SetActive(true);
        targets.Add(newTarget);
    }


}
