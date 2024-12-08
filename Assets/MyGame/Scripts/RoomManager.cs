using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private TableStudentData tableLayout;
    [SerializeField] private StudentData[] students;
    [SerializeField] private GameObject tablePrefab;
    [SerializeField] private GameObject chairPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                Transform pos1 = table.transform.Find("pos1");
                Transform pos2 = table.transform.Find("pos2");

                if (pos1)
                {
                    Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                }
                if (pos2)
                {
                    Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                }
            }
        }
    }
}
