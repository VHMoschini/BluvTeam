using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mecânica Palavra", menuName = "BluvTeam/Palavra")]
public class scriptable : ScriptableObject
{
    [Header("Posição")]
    public Vector2 angle;
    public Vector3 position;

    [Header("Colisor")]
    public Vector3 boxSize = new Vector3(2, 2, 2);

    [Header("Margem")]
    public float treshold = 1;
}
