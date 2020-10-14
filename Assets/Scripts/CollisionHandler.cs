using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("Seconds")][SerializeField] float LoadLevelDelay;
    [Tooltip("Explosion Prefab")] [SerializeField] GameObject explosionFX;
    void OnTriggerEnter(Collider other)
    {
        StartDeath();
        explosionFX.SetActive(true);
        Invoke("RestartLevel", LoadLevelDelay);
    }
    
    void StartDeath()
    {
        SendMessage("OnPlayerDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
