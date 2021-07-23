using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;

    Player playerScript;

    public int damage;

    public GameObject explosion;

  // Start is called before the first frame update
    void Start()
    {
        //randomizing the speed of the enemies so that the game feels more challenging and not scripted
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed for enemy character movement 
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    //function for damage dealt to character
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            //function for adding particle effect
            Instantiate(explosion, transform.position, Quaternion.identity);
            //after colision with character, enemy object destroys itself
            Destroy(gameObject);
        }

        if (hitObject.tag=="Ground")
        {
            Destroy(gameObject);
            //function for adding particle effect
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
