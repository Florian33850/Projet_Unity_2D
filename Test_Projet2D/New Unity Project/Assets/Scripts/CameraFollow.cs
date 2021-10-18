using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    public PlayerMovement playerMovement;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        
        // Décallage de la caméra suivant si on avance ou recule
        // if((playerMovement.rb.velocity.x < -0.1 && posOffset.x > 0) || (playerMovement.rb.velocity.x > 0.1 && posOffset.x < 0))
        // {
        //     posOffset.x = -posOffset.x;
        // }
    }
}
