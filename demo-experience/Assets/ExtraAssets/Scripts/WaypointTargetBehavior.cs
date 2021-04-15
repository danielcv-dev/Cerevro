using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointTargetBehavior : MonoBehaviour
{
    [Header("Image")]
    [Tooltip("Image to canvas reference")]
    public Image image;
    [Header("Targets")]
    [Tooltip("List of waypoints targets")]
    public List<Transform> targets;
    [Header("Text")]
    [Tooltip("Reference to canvas text")]
    public Text distance;
    [Header("Offset")]
    [Tooltip("The offset od the image marker")]
    public Vector3 offset;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(targets[0].position) + offset;
        

        if (Vector3.Dot((targets[0].position - transform.position), transform.forward) < 0)
        {
            //target is behind the player
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        image.transform.position = pos;
        distance.text = ((int)Vector3.Distance(targets[0].position, transform.position)).ToString() + "m";

        if (Input.GetKeyDown(KeyCode.D))
        {
            PopTargets();
        }
    }

    public void PopTargets()
    {
        if (targets.Count > 0)
        {
            targets.RemoveAt(0);
        }
        
    }
}
