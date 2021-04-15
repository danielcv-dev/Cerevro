using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCamera : MonoBehaviour
{
   ShowInfo information;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("hit" + hit.collider.tag);

            //inicio de codigo para hit de informacion
            if (hit.collider.CompareTag("Info"))
            {
                information = hit.transform.gameObject.GetComponent<ShowInfo>();
                information.transform.SendMessage("HitByRaycast");
            }
            else if (!hit.collider.CompareTag("Info"))
            {
                if (information != null)
                {
                    information.transform.SendMessage("HitOutByRaycast");
                    information = null;
                }
            }
            //fin de codigo para hit de informacion
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("don't hit");
        }
    }
}
