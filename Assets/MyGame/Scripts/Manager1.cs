using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager1 : MonoBehaviour
{
    [SerializeField] private TableLayoutData tableLayout; // Ref zu TableLayout ScriptableObject
    [SerializeField] private StudentData[] students; // Array mit StudentData-Objekten
    [SerializeField] private GameObject tablePrefab; // Prefab für Tisch
    [SerializeField] private GameObject chairPrefab; // Prefab für Stuhl
    private int studentIndex = 0; // Index für Studentenliste

    // Start is called before the first frame update
    private void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);

                // Tische platzieren
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                // Sessel platzieren
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

                // Studenten platzieren
                Transform posstd1 = table.transform.Find("posstd1");
                Transform posstd2 = table.transform.Find("posstd2");

                if (posstd1 != null)
                {
                    PlaceStudent(posstd1.position, posstd1.rotation, table.transform);
                }
                if (posstd2 != null)
                {
                    PlaceStudent(posstd2.position, posstd2.rotation, table.transform);
                }
            }
        }
    }

    private void PlaceStudent(Vector3 position, Quaternion rotation, Transform parent)
    {
        if (studentIndex < students.Length)
        {
            // Das Prefab des jetzigen Schüler aus dem Array holen
            GameObject studentPrefab = students[studentIndex].studentPrefab;

            //Prüfen ob student prefab vorhanden ist
            if (studentPrefab != null)
            {
                // Studenten instanzieren
                GameObject student = Instantiate(studentPrefab, position, rotation, parent);
                student.name = students[studentIndex].studentName;

                // Renderer suchen / Get Component in Children wird verwendet falls der Renderer nicht direkt auf dem Hauptobjekt liegt
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
