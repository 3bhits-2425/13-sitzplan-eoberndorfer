using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private TableStudentData tableLayout; 
    [SerializeField] private StudentData[] students; 
    [SerializeField] private GameObject tablePrefab; 
    [SerializeField] private GameObject chairPrefab; 
    private int studentIndex = 0; 


    private void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);

               
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                
                Transform pos1 = table.transform.Find("pos1");
                Transform pos2 = table.transform.Find("pos2");
                if (pos1 != null)
                {
                    Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                }
                if (pos2 != null)
                {
                    Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                }

                
                Transform posh1 = table.transform.Find("posh1");
                Transform posh2 = table.transform.Find("posh2");

                if (posh1 != null)
                {
                    PlaceStudent(posh1.position, posh1.rotation, table.transform);
                }
                if (posh2 != null)
                {
                    PlaceStudent(posh2.position, posh2.rotation, table.transform);
                }
            }
        }
    }

    private void PlaceStudent(Vector3 position, Quaternion rotation, Transform parent)
    {
        if (studentIndex < students.Length)
        {
            GameObject studentPrefab = students[studentIndex].studentPrefab;

            //Prüfen ob student prefab vorhanden ist
            if (studentPrefab != null)
            {
                // Studenten instanzieren
                GameObject student = Instantiate(studentPrefab, position, rotation, parent);
                student.name = students[studentIndex].studentName;

                // Renderer suchen 
                Renderer renderer = student.GetComponentInChildren<Renderer>();
                if (renderer != null)
                {
                    // Neues Material erstellen und Albedo-Textur setzen
                    Material newMaterial = new Material(renderer.material);
                    newMaterial.mainTexture = students[studentIndex].albedoTexture;
                    renderer.material = newMaterial;
                }
            }

            studentIndex++;
        }
    }


}