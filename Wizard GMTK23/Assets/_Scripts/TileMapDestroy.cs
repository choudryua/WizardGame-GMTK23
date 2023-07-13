using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapDestroy : MonoBehaviour
{
    [SerializeField] private AudioClip _Deathclip;
    private Tilemap map;

    private void Start()
    {
        map = GetComponent<Tilemap>();
        Debug.Log("map is " + map);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack") && !collision.isTrigger)
        {

            GameObject FireBall = GameObject.FindGameObjectWithTag("Attack");

            Vector3 hitPosition = FireBall.transform.position + new Vector3(0f, -0.5f, 0f);
            map.SetTile(map.WorldToCell(hitPosition), null);
            SoundManager.instance.PlaySound(_Deathclip);
            StartCoroutine(CameraShake.instance.Shake(.10f, .2f));
        }

    }
}
