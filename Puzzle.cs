using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private GameObject selectedObject;



    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("çalışıyor");
            if (selectedObject == null)
            {
                RaycastHit hit = rayCast();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    //Debug.Log("geliyor");
                    Cursor.visible = false;
                    
                }
            }
            else
            {
               Vector3 position = new Vector3(Input.mousePosition.x,
                               Input.mousePosition.y,
                               Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

                selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);

                selectedObject = null;
            
                Cursor.visible = true;
            }
        }
        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x,
                                           Input.mousePosition.y,
                                           Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            selectedObject.transform.position = new Vector3(worldPosition.x, 0.5f, worldPosition.z);
        }

    }
    private RaycastHit rayCast()
    {
       Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                                                Camera.main.farClipPlane);
        Vector3 screenMousePosNear= new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                                                Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;


    }

}
