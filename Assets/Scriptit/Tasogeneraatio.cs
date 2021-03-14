using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasogeneraatio : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity); 
    }

    private void Update()
    {
        
    }

    // Update is called once per frame

}
