using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public float waitBeforeRespawning;

    [HideInInspector]
    public bool respawning;

    private PlayerController player;

    [HideInInspector]
    public Vector3 respawnPoint;

    private CameraController cam;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        respawnPoint = player.transform.position + Vector3.up;

        cam = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn() 
    {
        if (!respawning)
        {
            respawning= true;

            StartCoroutine(RespawnCo());
        }
    }


    public IEnumerator RespawnCo() 
    {
        player.gameObject.SetActive(false);
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(waitBeforeRespawning);

        player.transform.position = respawnPoint;

        cam.SnapToTarget();

        player.gameObject.SetActive(true);

        respawning = false;

        UIController.instance.FadeFromBlack();

        PlayerHealthController.instance.FillHealth();
    }   
}
