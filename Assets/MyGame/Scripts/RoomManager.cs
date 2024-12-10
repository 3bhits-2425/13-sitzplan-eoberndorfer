using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private TableStudentData tableLayout;
    [SerializeField] private StudentData[] students; // Array von StudentData
    [SerializeField] private GameObject tablePrefab;
    [SerializeField] private GameObject chairPrefab;
    [SerializeField] private GameObject humanPrefab; // Prefab für den Menschen

    private void Start()
    {
        int studentIndex = 0; // Index, um die Studenten zu durchlaufen

        // Durchlaufe alle Zeilen und Spalten, um die Tische zu platzieren
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);

                // Instanziiere den Tisch
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                // Finde die Positionen für die Stühle
                Transform pos1 = table.transform.Find("pos1");
                Transform pos2 = table.transform.Find("pos2");

                // Stuhl 1
                if (pos1 != null)
                {
                    GameObject chair1 = Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                    // Wenn noch Studenten übrig sind, setze den ersten Schüler auf den Stuhl
                    if (studentIndex < students.Length)
                    {
                        SpawnStudentOnChair(chair1, students[studentIndex]);
                        studentIndex++;
                    }
                }

                // Stuhl 2
                if (pos2 != null)
                {
                    GameObject chair2 = Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                    // Wenn noch Studenten übrig sind, setze den nächsten Schüler auf den Stuhl
                    if (studentIndex < students.Length)
                    {
                        SpawnStudentOnChair(chair2, students[studentIndex]);
                        studentIndex++;
                    }
                }
            }
        }
    }

    // Methode, um den Studenten auf den Stuhl zu setzen
    private void SpawnStudentOnChair(GameObject chair, StudentData studentData)
    {
        // Finde die HumanPosition im Stuhl (bzw. Kopf des Menschen-Prefabs)
        Transform humanPosition = chair.transform.Find("HumanPosition");

        if (humanPosition == null)
        {
            Debug.LogError($"HumanPosition nicht gefunden im Stuhl: {chair.name}");
            return;
        }

        // Instanziiere den Menschen (Schüler)
        GameObject human = Instantiate(humanPrefab, humanPosition.position, humanPosition.rotation, chair.transform);

        // Setze den Namen des Schülers
        human.name = studentData.studentName;

        // Finde die Sphere, die den Kopf des Menschen darstellt
        Transform headTransform = human.transform.Find("Head"); // Stelle sicher, dass "Head" der Name des Kopf-Teils im Prefab ist
        if (headTransform != null)
        {
            // Setze das Material der Kopf-Sphere
            Renderer headRenderer = headTransform.GetComponent<Renderer>();
            if (headRenderer != null)
            {
                // Verwende das Sprite des Schülers als Textur
                Texture2D studentTexture = studentData.albedoTexture; // Hier kannst du die Textur verwenden, falls du keine Sprite hast

                if (studentTexture != null)
                {
                    // Setze die Textur auf das Material
                    headRenderer.material.mainTexture = studentTexture;
                }
                else
                {
                    // Wenn du ein Sprite hast, konvertiere es in eine Textur und wende es an
                    headRenderer.material.mainTexture = studentData.studentImage.texture;
                }
            }
            else
            {
                Debug.LogError("Kein Renderer für den Kopf gefunden!");
            }
        }
        else
        {
            Debug.LogError("Kein 'Head' Objekt im Prefab gefunden!");
        }

        // Falls nötig, setze andere Daten, wie Augenfarbe oder AudioClip
        // Beispiel: human.GetComponent<Renderer>().material.color = studentData.eyecolor;
    }
}
