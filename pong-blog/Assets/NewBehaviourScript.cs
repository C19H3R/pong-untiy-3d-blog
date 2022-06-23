using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    MonoBehaviour test;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(test.gameObject.name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
