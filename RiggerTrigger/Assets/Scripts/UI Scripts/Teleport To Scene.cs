using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    public string loadScene;
    private void OnTriggerEnter(Collider other)
    {

        print(other);

        if (other.CompareTag("Player_"))
        {

            SceneManager.LoadScene(loadScene);
        }
    }
}

