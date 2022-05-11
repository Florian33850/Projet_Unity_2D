using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static PlayerSpawn instance;

    private void Awake() 
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;

        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }
}
