using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !collision.isTrigger)
        {

            Destroy(collision.gameObject);
        } else if ( collision.CompareTag("Ladder") && collision.isTrigger)
        {
            Destroy(collision.gameObject.GetComponent<Tile>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            
        }
    }

}
