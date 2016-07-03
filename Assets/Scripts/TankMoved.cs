using UnityEngine;
using System.Collections;

public class TankMoved : MonoBehaviour {

    public float speed = 5;
    public float angularSpeed = 10;
    public float number = 1;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;
    private Rigidbody rigidbody;
	void Start ()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        audio = this.GetComponent<AudioSource>();
	}
	void FixedUpdate ()
    {
        float v = Input.GetAxis("PlayerVertical"+number);
        rigidbody.velocity = transform.forward * v * speed;

        float h = Input.GetAxis("PlayerHorizontal"+number);
        rigidbody.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if(audio.isPlaying==false)
                audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            audio.Play();
        }
	}
}
