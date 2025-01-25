using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    //atributos
    public Node currentNode;
    public List<Node> path= new List<Node>();
    public Node endNode;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, .8f);
    }

    void Update()
    {
        createPath();
        
    }

    public void createPath()
    {
        if (path.Count > 0)
        {
            int x = 0;
            enemyMovement(transform.position, path[x].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[x].transform.position.x, path[x].transform.position.y, -2), 3 * Time.deltaTime);

            if (Vector2.Distance(transform.position, path[x].transform.position) < 0.1f)
            {
                currentNode = path[x];
                path.RemoveAt(x);

            }



        }
        else
        {

            Node[] nodes = FindObjectsOfType<Node>();
            while (path == null || path.Count == 0)
            {
                
                path = AStartManager.instance.GeneratePath(currentNode, nodes[UnityEngine.Random.Range(0, nodes.Length)]);

            }

        }
    }

    public void enemyMovement(Vector3 enemyPosition, Vector3 playerPosition)
    {
        Vector3 direccion= (playerPosition-enemyPosition).normalized;
        animator.SetFloat("Horizontal", direccion.x);
        animator.SetFloat("Vertical", direccion .y);
     
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==3)
        {
            Debug.Log("Colision activa");
            GameObject player = collision.gameObject;
            PlayerMovement playerScript= player.GetComponent<PlayerMovement>();
            if (playerScript.getInvencibilidad()==false)
            {
                StartCoroutine(playerScript.color());
                Debug.Log("La cordura del jugador es " + playerScript.getCordura());
                playerScript.reducirCordura(1);
                Debug.Log("La cordura del jugador es " + playerScript.getCordura());


            }
            transform.position = new Vector2(transform.position.x - 10, transform.position.y - 10);

        }
    }




}
