using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    //atributos
    public Node currentNode;
    public List<Node> path= new List<Node>();
    public Node endNode;

    
    void Start()
    {
        
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
                //path = AStartManager.instance.GeneratePath(currentNode, nodes[Random.Range(0, nodes.Length)]);
                path = AStartManager.instance.GeneratePath(currentNode, endNode);




            }

        }
    }




}
