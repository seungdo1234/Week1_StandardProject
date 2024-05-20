using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "QuestDataSO/Default", order = 0)]
public class QuestDataSO : ScriptableObject
{
    [Header("# QuestData")]
    public string qusetName;
    public int questRequiredLevel;
    public int questNPC;
    public List<int> questPrerequisites;
    
}