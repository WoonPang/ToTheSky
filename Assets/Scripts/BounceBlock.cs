using UnityEngine;

public class BounceBlock : MonoBehaviour
{
    public AudioClip soundClip;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(soundClip, transform.position);
        }
    }
}