using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn_point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_"))
        {
            player.transform.position = respawn_point.transform.position;
        }
    }
}
