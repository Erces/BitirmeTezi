using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public List<NavMeshSurface> surfaces;
    public Transform[] objectsToRotate;
    public static NavigationBaker i;
    // Use this for initialization
    private void Awake()
    {
        i = this;
    }
    private void Start()
    {
        Invoke("Build", 3f);
    }
    void Update()
    {

        for (int j = 0; j < objectsToRotate.Length; j++)
        {
            //objectsToRotate[j].localRotation = Quaternion.Euler(new Vector3(0, 50 * Time.deltaTime, 0) + objectsToRotate[j].localRotation.eulerAngles);
        }

       
    }
    public void Build()
    {
        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

}