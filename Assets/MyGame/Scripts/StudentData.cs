using UnityEngine;

[CreateAssetMenu(fileName = "NewStudent", menuName = "Sitzplan/StudentData")]
public class StudentData : ScriptableObject
{
    public string studentName;
    public Color eyecolor;
    public Sprite studentImage;
    public AudioClip studentClip;
}
