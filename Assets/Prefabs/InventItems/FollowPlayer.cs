using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  [SerializeField] Player player;   

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameObject.GetComponent<Item>().isShown)
        gameObject.transform.position = player.transform.position;
    }
}
