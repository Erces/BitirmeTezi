using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
public class GridOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshSurface surf;
    public GameObject tower;
    public GameObject decorations;
    MeshRenderer renderer;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        surf = GetComponent<NavMeshSurface>();
        NavigationBaker.i.surfaces.Add(surf);
        Invoke("SetDecorationsActive", 3.2f);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.i.CanBuy(GameManager.i.selectedTurret.GetComponent<PlayerTower>().price))
        {
            Debug.Log("Place");
            Instantiate(GameManager.i.selectedTurret, transform.position, transform.rotation);
        }
    }
    public void SetDecorationsActive()
    {
        decorations.SetActive(true);
        renderer.enabled = false;
    }
}
