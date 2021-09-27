using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{

    private const float TIME_TO_DESTROY = 10F;

    [SerializeField]
    private int maxHP = 1;

    private int currentHP;

    [SerializeField]
    public int scoreAdd = 10;

    Player player;

    private void Awake()
    {
       player = FindObjectOfType<Player>();
        player.OnPlayerHit += DamagePlayer;
        player.OnScoreChanged += UpdateScore;

    }

    
    private void Start()
    {
        currentHP = maxHP;
        Destroy(gameObject, TIME_TO_DESTROY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedObjectLayer = collision.gameObject.layer;

        if (collidedObjectLayer.Equals(Utils.BulletLayer))
        {
            Destroy(collision.gameObject);

            currentHP -= 1;

            if (currentHP <= 0)
            {
                //Player player = FindObjectOfType<Player>();

                player.OnPlayerHit -= DamagePlayer;

                Destroy(gameObject);

                UpdateScore();

                //player.AddScore();

                //player.Lives--;

            }
        }
        /*
        else if (collidedObjectLayer.Equals(Utils.PlayerLayer) ||
            collidedObjectLayer.Equals(Utils.KillVolumeLayer))
        {
            Player player = FindObjectOfType<Player>();

            if (player != null)
            {
                player.Lives -= 1;
                
                if (player.Lives <= 0 && player.OnPlayerDied != null)
                {
                    player.OnPlayerDied();
                }              
            }

            Destroy(gameObject);
        }
        */

    }


    private void UpdateScore()
    {
        Player player = FindObjectOfType<Player>();

        player.Score += scoreAdd;
    }
    private void DamagePlayer()
    {
        Player player = FindObjectOfType<Player>();

        

        player.Lives--;   

        if(this != null)
        {
            Destroy(gameObject);
        }
            
                   
            
        
    }
}