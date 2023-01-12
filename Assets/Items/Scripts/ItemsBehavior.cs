using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehavior : MonoBehaviour
{
    /*
        Items tags and details:
            - Coin: only add coin
            - Feather: shield character from debuff
            - Slow Pill: slow down move speed and jump force
            - Bomb: Instantly destroy character
            - Super Power Potion: effect from feather + slow down obstacle
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
