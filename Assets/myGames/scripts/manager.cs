using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject myParent;
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(myParent.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
