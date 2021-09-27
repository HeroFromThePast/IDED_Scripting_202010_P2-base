using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolumeDamage : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            player.Lives--;
            Destroy(collision.gameObject);          
        }
    }
}
