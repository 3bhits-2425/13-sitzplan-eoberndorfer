using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject myParent;

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(prefab, myParent.transform);
        }
    }
}
