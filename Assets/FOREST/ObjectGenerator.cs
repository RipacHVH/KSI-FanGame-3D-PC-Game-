using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public int Trees;
    public int Stones;
    public int npcs;
    public float Range;

    public GameObject Tree;
    public GameObject Stone;
    public GameObject npc;

    RaycastHit hit;
    void Start()
    {
        SpawnStones();
        SpawnTrees();
        SpawnNpc();


    }
    void SpawnNpc()
    {
        for (int i = 0; i < npcs; i++)
        {
            Vector3 position = new Vector3(Random.Range(-Range, Range), 0, Random.Range(-Range, Range));
            //Do a raycast along Vector3.down -> if you hit something the result will be given to you in the "hit" variable
            //This raycast will only find results between +-100 units of your original"position" (ofc you can adjust the numbers as you like)
            if (Physics.Raycast(position + new Vector3(0, 100.0f, 0), Vector3.down, out hit, 200.0f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {
                    Instantiate(npc, hit.point, npc.transform.localRotation);
                }
            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }
        }
    }    
    void SpawnStones()
    {
        for (int i = 0; i < Stones; i++)
        {
            //range
            Vector3 position = new Vector3(Random.Range(-Range, Range), 0, Random.Range(-Range, Range));
            //Do a raycast along Vector3.down -> if you hit something the result will be given to you in the "hit" variable
            //This raycast will only find results between +-100 units of your original"position" (ofc you can adjust the numbers as you like)
            if (Physics.Raycast(position + new Vector3(0, 100.0f, 0), Vector3.down, out hit, 200.0f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {
                    Instantiate(Stone, hit.point, Stone.transform.localRotation);
                }
            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }
        }
    }    

    void SpawnTrees()
    {
        for (int i = 0; i < Trees; i++)
        {
            Vector3 position = new Vector3(Random.Range(-Range, Range), 0, Random.Range(-Range, Range));
            //Do a raycast along Vector3.down -> if you hit something the result will be given to you in the "hit" variable
            //This raycast will only find results between +-100 units of your original"position" (ofc you can adjust the numbers as you like)
            if (Physics.Raycast(position + new Vector3(0, 100.0f, 0), Vector3.down, out hit, 200.0f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {
                    Instantiate(Tree, hit.point, Tree.transform.localRotation);
                    //  Instantiate(npc, hit.point, coin.transform.localRotation);
                }

            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }
        }
    }
}
