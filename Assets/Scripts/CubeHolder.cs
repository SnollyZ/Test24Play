using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField]private GameObject stackEffect;
    [SerializeField]private GameObject collectCubeText;
    [SerializeField]private Transform player;

    private Transform currentCube;
    private Coroutine currentStackEffect;
    
    public List<Transform> cubes;

    void Update()
    {
        MoveCubes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube" && !cubes.Contains(other.transform))
        {
            if(currentStackEffect != null)
            {
                StopCoroutine(currentStackEffect);
                stackEffect.SetActive(false);
            }
            currentStackEffect = StartCoroutine(StackEffect());
            StartCoroutine(CollectCubeText());
            currentCube = other.transform;
            cubes.Add(other.transform);
            player.position = new Vector3(player.position.x, player.position.y + 1f, player.position.z);
            //other.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            other.transform.position = player.transform.position;
        }
    }

    public void MoveCubes()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        foreach (var cube in cubes)
        {
            cube.position = new Vector3(player.transform.position.x, cube.transform.position.y, player.transform.position.z);
        }      
    }

    private IEnumerator StackEffect()
    {
        stackEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        stackEffect.SetActive(false);
        yield break;
    }

    private IEnumerator CollectCubeText()
    {
        GameObject currentCollectCubeText = Instantiate(collectCubeText, player.position, Quaternion.Euler(0, 90, 0));
        RectTransform rectTransform = currentCollectCubeText.GetComponent<RectTransform>();
        float dir = rectTransform.position.y + 8;
        while(rectTransform.position.y < dir - 0.1f)
        {Debug.Log("111");
            float yVelocity = 0.0f;
            float newPosition = Mathf.SmoothDamp(rectTransform.position.y, dir, ref yVelocity, 0.1f);
            rectTransform.position = new Vector3(rectTransform.position.x, newPosition, rectTransform.position.z);
            yield return null;
        }
        yield break;
    }

}
