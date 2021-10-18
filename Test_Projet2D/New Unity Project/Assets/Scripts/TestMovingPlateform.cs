using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovingPlateform : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 1;

    public bool col = false;

    void Start()
    {
        target = waypoints[1];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.name == "Player")
    //     {
    //         collision.transform.SetParent(transform);
    //         col = true;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if(collision.gameObject.name == "Player")
    //     {
    //         collision.transform.SetParent(null);
    //         col = false;
    //     }
    // }
}
