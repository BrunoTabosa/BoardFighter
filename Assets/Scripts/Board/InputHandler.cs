using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Camera camera;
    Ray ray;
    RaycastHit hitData;
    GameObject selectedObject;
    public LayerMask layer;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

         //Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);
        
        if (Physics.Raycast(ray, out hitData, 500, layer) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hitData.transform.gameObject;
            selectedObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

}
