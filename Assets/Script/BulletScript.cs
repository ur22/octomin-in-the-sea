using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    public int damage = 1; // Danno inflitto dal proiettile

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
       // Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Controlla se il proiettile ha colpito il giocatore
        if (other.CompareTag("Player"))
        {
            
            
            PlayerController playerController = other.GetComponent<PlayerController>();

            // Se il giocatore ha il componente PlayerController, toglie vita
            if (playerController != null)
            {
                playerController.changeHealth(damage);
            }

            
            Destroy(gameObject);
        }
    }
}
