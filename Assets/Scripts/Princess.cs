using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public GameObject cage;
    public GameObject victoryText;

    public void BrakeCage()
    {
        transform.parent = null;
        gameObject.AddComponent<Rigidbody>();
        victoryText.SetActive(true);
        Invoke("ReloadScene", 3);
        Destroy(cage);
    }

    private void ReloadScene()
    {
        Enemy.RemoveAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
