using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject BranchPrefab;
    [SerializeField] private int maxDepth = 3;
    
    private Queue<GameObject> frontier = new Queue<GameObject>();
    private Queue<GameObject> newBranches = new Queue<GameObject>();

    private int currenBranches = 0;
    void Start()
    {
        GameObject root = Instantiate(BranchPrefab, transform);
        root.name = "branch[root]";
        frontier.Enqueue(root);
        GenerateTree();
    }
    private GameObject createBranch(GameObject prevBranch, float offsetAngle)
    {

        GameObject branch = Instantiate(BranchPrefab, transform);

        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        Quaternion rotation = prevBranch.transform.rotation;
        branch.transform.rotation = rotation * Quaternion.Euler(0f, 0f, offsetAngle);
        return branch;
    }
    private void GenerateTree()
    {
        if (currenBranches >= maxDepth)
        {
            return;
        }
        currenBranches++;

       
        while (frontier.Count > 0)
        {
            var prevRoot = frontier.Dequeue();

            
            var leftBranch = createBranch(prevRoot, Random.Range(15f, 40f));
            var rightBranch = createBranch(prevRoot, -Random.Range(15f, 40f));

            
            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(rightBranch);
        }

        
        int branches = newBranches.Count;
        for (int i = 0; i < branches; i++)
        {
            frontier.Enqueue(newBranches.Dequeue());
        }

       
        GenerateTree();
    }
}
