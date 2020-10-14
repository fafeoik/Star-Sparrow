using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreToAdd = 5;
    [SerializeField] int hp = 5;
    Score scoreboard;
    void Start()
    {
        scoreboard = FindObjectOfType<Score>();
        AddNonTriggerCollider();
    }


    void AddNonTriggerCollider()    
    { 
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    void OnParticleCollision(GameObject other)
    {
        hp--;
        if(hp <= 0)
        {
            scoreboard.ScoreHit(scoreToAdd);
            Death();
        }
        
    }

    void Death()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
