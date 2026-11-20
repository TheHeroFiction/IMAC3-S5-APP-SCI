using System.Collections;
using System.Collections.Generic;
using TreeTutorial;
using Unity.VisualScripting;
using UnityEngine;

public class lsystem : MonoBehaviour
{
    private string tree;
    [SerializeField] private string axiom;
    [SerializeField] private int iterations;
    Stack<TransformInfoHelper> stack = new Stack<TransformInfoHelper>();
    private TransformInfoHelper helper;

    [SerializeField] private float length;

    private List<List<Vector3>> limeList =  new List<List<Vector3>>();
    [SerializeField] private float angle;

    void Expand_Tree_String()
    {
        string expanded_tree;
        for (int i = 0; i < iterations; i++)
        {
            expanded_tree ="";
            foreach(char j in tree)
            {
                expanded_tree += j switch
                {
                    'F' => "FF",
                    'B' => "[lFB][rFB]",
                    _ => j.ToString()
                }; 
            }
            tree = expanded_tree;
            Debug.Log("Tree at iteration" + i + " is "+ tree);
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree = axiom;
        Debug.Log("Starting tree" + tree);
        Expand_Tree_String();
        CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        foreach(List<Vector3> line in limeList)
        {
            Gizmos.DrawLine(line[0],line[1]);
        }
    }

    void CreateMesh()
    {
        Vector3 init_pos;
        foreach(char j in tree)
        {
            switch(j)
            {
                case 'F':
                    init_pos = transform.position;
                    transform.Translate(Vector3.up * length);
                    limeList.Add(new List<Vector3>(){init_pos, transform.position});
                    init_pos = transform.position;
                    break;
                case 'B':
                    break;
                case '[':
                    stack.Push(new TransformInfoHelper(){position = transform.position, rotation = transform.rotation}); 
                    break;
                case ']':
                    helper = stack.Pop();
                    transform.position = helper.position;
                    transform.rotation = helper.rotation;
                    break;
                case 'l':
                    transform.Rotate(Vector3.back , angle);
                    break;
                case 'r':
                    transform.Rotate(Vector3.forward , angle);
                    break;
            }
        }
    }
}
