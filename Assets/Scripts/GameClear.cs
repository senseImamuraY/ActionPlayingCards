using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    [SerializeField] GameObject ClearUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ClearUI.SetActive(true);

            StartCoroutine(ClearCo());
        }
    }

    private IEnumerator ClearCo()
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 1f;

        SceneManager.LoadScene("titleScene");
    }
}
