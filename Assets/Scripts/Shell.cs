using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public GameObject shellExplosionPrefab;
    public float time;

    public AudioClip shellExplosionAudio;

    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject,time);

        if (collider.tag == "tank")
        {
            collider.SendMessage("TankDamage");
        }
    }
}
