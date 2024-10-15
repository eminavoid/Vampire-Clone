using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{

    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        playerCollector.radius = player.CurrentMagnet;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

            col.gameObject.GetComponent<BobbingAnimation>().enabled = false;

            //item 2 player
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            //force 2 item
            rb.AddForce(forceDirection * pullSpeed);

            collectible.Collect();
        }
    }
}
