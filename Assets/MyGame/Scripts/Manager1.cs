using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager1 : MonoBehaviour
{

    [SerializeField] private TableLayoutData tableLayout; // Ref zu TableLayout ScriptableObject
    [SerializeField] private StudentData[] students;
    [SerializeField] private GameObject tablePrefab; //Prefab für Tisch
    [SerializeField] private GameObject chairPrefab; //Prefab für Stuhl
    [SerializeField] private GameObject studentPrefab; //Prefab für Student
    // Start is called before the first frame update
    private void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                
                //Tische plazieren
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                //Sessel plazieren
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

                //Studenten plazieren
                Transform posstd1 = table.transform.Find("posstd1");
                Transform posstd2 = table.transform.Find("posstd2");
                if (posstd1 != null)
                {
                    GameObject student = Instantiate(studentPrefab, posstd1.position, posstd1.rotation, table.transform);
                }
                if (posstd2 != null)
                {
                    GameObject student = Instantiate(studentPrefab, posstd2.position, posstd2.rotation, table.transform);
                }
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
