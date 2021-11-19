using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coletavel", menuName = "BluvTeam/Coletavel")]
public class ColectableScriptable : ScriptableObject
{
    [Space(10)]
    public string Nome;
    [Space(10)]
    [TextArea]
    public string Descricao;
    [Space (10)]
    [TextArea]
    public string feedbackMessage = "Colecionável encontrado!";
}
