using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControler : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rig;
    private AudioSource somCoin;
    void Start()
    {
         rig = GetComponent<Rigidbody2D>();
         somCoin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();  // plays sound when collided.
            Destroy(gameObject,0.1f);
         }
    }
}
