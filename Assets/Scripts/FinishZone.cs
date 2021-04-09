using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public GameObject victoryText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Player>())
        {
            victoryText.SetActive(true);
            Invoke("ReloadScene", 1);
        }
    }

    private void ReloadScene()
    {
        Enemy.RemoveAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
