﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {

    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;

    private int hpTotal;
	void Start ()
    {
        hpTotal = hp;
	}
	
	void Update ()
    {
	
	}

    void TankDamage()
    {
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0)
            return;
        hp -= Random.Range(10, 20);
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

}
