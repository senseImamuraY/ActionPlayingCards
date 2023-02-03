using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this; 
    }

    private int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DagamePlayer()
    {
        //LevelManager.instance.Respawn();
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
    }
}
