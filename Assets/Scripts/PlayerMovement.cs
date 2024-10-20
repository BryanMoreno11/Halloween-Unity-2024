using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //atributos
    public GameObject player;
    public float velocidadMovimiento=10;
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    void Update()
    {
      

    }

    private void FixedUpdate()
    {
        movimiento();

    }

    void movimiento()
    {
        float movimientoH = Input.GetAxisRaw("Horizontal");
        float movimientoV = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movimientoH * velocidadMovimiento, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, movimientoV * velocidadMovimiento);
    }


}
