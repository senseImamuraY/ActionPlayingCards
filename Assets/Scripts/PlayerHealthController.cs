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

    public float invincibilityLength = 1f;
    private float invincCounter;
    private bool colorSwitch = false;
    private Material[] tmp;
    private bool isBlack = false;

    [SerializeField] private float waitMin = 0.5f;
    [SerializeField] private GameObject PlayersBody;



    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
        tmp = PlayersBody.gameObject.GetComponent<SkinnedMeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            if (!colorSwitch)
            {
                ColorChanger();
                colorSwitch = true;
            }
            if (currentHealth > 1)
            {
                StartCoroutine(ColorFlasherCo(tmp)); 
            }
        }
        else
        {
            foreach (Material mat in tmp)
            {
                mat.color = Color.white;
            }
            colorSwitch = false;
        }
    }

    public void DagamePlayer()
    {
        if (invincCounter <= 0)
        {
            invincCounter = invincibilityLength;

            currentHealth--;

            if (currentHealth <= 0)
            {               
                LevelManager.instance.Respawn();
            }

            UIController.instance.UpdateHealthDisplay(currentHealth);
        }
    }
    
    public void FillHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth);
    }

    private void ColorChanger()
    {
        if (!colorSwitch)
        {
            
            foreach (Material mat in tmp)
            {
                mat.color = Color.black;
            }
        }
        else
        {
            foreach (Material mat in tmp)
            {
                mat.color = Color.white;
            }
            colorSwitch = false;
        }
    }

    private IEnumerator ColorFlasherCo (Material[] tmp)
    {
        foreach (Material mat in tmp)
        {
            if (!isBlack)
            {
                mat.color = Color.black;
                isBlack = !isBlack;
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                mat.color = Color.white;
                isBlack = !isBlack;
                yield return new WaitForSeconds(0.2f);
            }

        }
    }
}
