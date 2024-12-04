using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTableLayout", menuName = "Seatplan/Tablelayout")]
public class TableStudentData : ScriptableObject
{
    public int rows;
    public int columns;
    public float tableSpacing;
    public float chairSpacing;

}
