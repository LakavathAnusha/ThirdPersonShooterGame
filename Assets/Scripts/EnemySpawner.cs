using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;
        if (time >= 3f)
        {
            // GameObject temp=Instantiate(ObjectPoolScript.instance.GetObjectsFromPool("Asteroid"),new Vector3(Random.Range(-8.0f, 8f),4f,0f),Quaternion.identity);
            GameObject tempEnemy = PoolScript.instance.GetObjectsFromPool("Enemy");
            if (tempEnemy != null)
            {
                tempEnemy.transform.position = new Vector3(Random.Range(-8.0f, 8f), 1f, Random.Range(-7,7));
                tempEnemy.SetActive(true);
            }
            time = 0;

            /* if (temp != null)
             {
                 this.transform.position = temp.transform.position+new Vector3(Random.Range(-8.0f, 8f), 4f, 0f);
                 temp.SetActive(true);
                 time = 0;
             }*/
        }
    }
}
