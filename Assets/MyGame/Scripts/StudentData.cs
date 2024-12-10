using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStudent", menuName = "Seatplan/Student")]
public class StudentData : ScriptableObject
{
    public string studentName;
    public Color eyecolor;
    public Sprite studentImage;
    public AudioClip studentClip;
    public GameObject studentPrefab;
    public Texture2D albedoTexture;
}