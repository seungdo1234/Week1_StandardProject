using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    public MonsterQuestDataSO[] monsterQuestDatas;
    public EncounterQuestDataSO[] encounterQuestDatas;
    
    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject questManager = new GameObject("QuestManager");
                    questManager.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }
    
    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < monsterQuestDatas.Length; i++)
        {
            Debug.Log($"Monster Quset {monsterQuestDatas[i].qusetName} - {monsterQuestDatas[i].qusetName} (최소 레벨{monsterQuestDatas[i].questRequiredLevel})\n" +
                      $"");
        }
        
        for (int i = 0; i < encounterQuestDatas.Length; i++)
        {
            Debug.Log($"Encounter Quset {encounterQuestDatas[i].qusetName} - {encounterQuestDatas[i].qusetName} (최소 레벨{encounterQuestDatas[i].questRequiredLevel})\n" +
                      $"");
        }
    }
}