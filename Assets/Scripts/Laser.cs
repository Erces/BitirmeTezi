using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class Laser : MonoBehaviour
{
    public Transform loc1;
    public Transform loc2;

    public Transform target;
    public LineRenderer line;

    GameObject enemyobj;
    Enemy enemyscript;

    LaserTurret turretscript;
    GameObject turretobj;

    public int damage=1;
    private float timePassed = 0f;

    

    public void Seek(Transform _target,Transform _turret)
    {
        loc1 = _turret;
        loc2 = _target;


        enemyobj = loc2.gameObject;
        Enemy enemyscript = enemyobj.GetComponent<Enemy>();
        enemyscript.lasered = true;

        

    }

    void Start()
    {

        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        turretobj = loc1.gameObject;
        LaserTurret turretscript = turretobj.GetComponent<LaserTurret>();

        float distance;

        if (loc2 != null) 
        {
            line.SetPosition(0, loc1.position);
            line.SetPosition(1, loc2.position);
            distance = Vector3.Distance(loc1.position, loc2.position);
            

            timePassed += Time.deltaTime;
            if (timePassed > 0.5f)
            {
                Enemy enemyscript = loc2.GetComponent<Enemy>();
                enemyscript.losehp(damage);
                timePassed = 0f;
            }

            if (distance > turretscript.range || loc2 == null)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

        


    }
}
