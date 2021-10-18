using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeCameraSizeDynamicaly : MonoBehaviour
{
    public Camera camera;

    public bool trigger = false;

    public float inf;
    public float pas;
    public float sup ;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            if(trigger == false)
            {
                StartCoroutine(DezoomCamera());
            }
            else
            {
                StartCoroutine(ZoomCamera());
            }
        }
    }
    
    public IEnumerator DezoomCamera()
    {
        while(camera.orthographicSize < inf)
        {
            camera.orthographicSize += pas;
            yield return null;
        }
        trigger = true;
    }

    public IEnumerator ZoomCamera()
    {
        while(camera.orthographicSize > sup)
        {
            camera.orthographicSize -= pas;
            yield return null;
        }
        trigger = false;
    }
}
