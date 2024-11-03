using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //atributos
    public GameObject player;
    public float velocidadMovimiento=10;
    public Rigidbody2D rb;
    public Animator animator;
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
         Vector3 direccion= new Vector3(movimientoH, movimientoV);
        AnimateMovement(direccion);

        rb.velocity = new Vector2(movimientoH * velocidadMovimiento, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, movimientoV * velocidadMovimiento);
 
    }

    void AnimateMovement(Vector3 direccion)
    {
        if (animator != null)
        {
            if (direccion.magnitude > 0)
            {
                animator.SetBool("Moving", true);
                animator.SetFloat("Horizontal", direccion.x);
                animator.SetFloat("Vertical", direccion.y);
                animator.SetFloat("LastHorizontal", direccion.x);
                animator.SetFloat("LastVertical", direccion.y);
            }
            else
            {
                animator.SetBool("Moving", false);

            }
        }


    }


}
