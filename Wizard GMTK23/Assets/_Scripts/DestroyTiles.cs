using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    Tilemap destructableTilemap;

    [SerializeField] private AudioClip _Deathclip;


    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x ;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                print(destructableTilemap.WorldToCell(hitPosition));
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
                SoundManager.instance.PlaySound(_Deathclip);
                StartCoroutine(CameraShake.instance.Shake(.10f, .2f));

            }

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {

            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                print(destructableTilemap.WorldToCell(hitPosition));
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
            }

        }

    }

}
