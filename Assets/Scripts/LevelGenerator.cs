using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]private GameObject trackGround;
    [SerializeField]private GameObject cube;
    [SerializeField]private List<GameObject> walls;
    [SerializeField]private List<GameObject> objects;
    
    private Vector3 position = new Vector3(3, 0, 0);
    private int count = 1;
    
    void Start()
    {
        StartCoroutine(GeneratingRoutine());
        StartCoroutine(DeleteObjects());
    }

    private IEnumerator GeneratingRoutine()
    {
        for(int i = 0; i < 5; i++)
        {
            Generate();
        }

        while(true)
        {
            yield return new WaitForSeconds(2.5f);
            Generate();
            yield return null;
        }
    }

    private IEnumerator DeleteObjects()
    {
        while(true)
        {
            yield return new WaitForSeconds(7);
            for(int i = 0; i < 20; i++)
            {
                Destroy(objects[0]);
                objects.RemoveAt(0);

            }
            yield return null;
        }
    }

    private void Generate()
    {
        for(int i = 1; i <= 20; i++)
        {
            GameObject newTrackGround = Instantiate(trackGround, position, Quaternion.identity);
            objects.Add(newTrackGround);
            if(count % 20 == 0)
            {
                GameObject myWall = Instantiate(walls[Random.Range(0, 4)], new Vector3(position.x, position.y, position.z - 0.5f), Quaternion.identity);
                objects.Add(myWall);
                i++;
                count++;
            }
            if((count - 6) % 20 == 0 || (count - 9) % 20 == 0 || (count - 12) % 20 == 0)
            {
                GameObject myCube = Instantiate(cube, new Vector3(position.x, 0.5f, Random.Range(1, 5)), Quaternion.identity);
                i++;
                count++;
            }
            position.x++;
            count++;
        }
    }
}
