using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievemenListener : MonoBehaviour
{
    private OnAchieveUpdate onAchieveUpdate;

    private Dictionary<string, float> conditions = new Dictionary<string, float>();

    void Start()
    {
        
    }

    void Update()
    {
        onAchieveUpdate.Invoke(conditions);
    }

    public void AddOnAchieveUpdate(OnAchieveUpdate onAchieveUpdate)
    {
        this.onAchieveUpdate += onAchieveUpdate;
    }

    public void AddConditions(Dictionary<string, float> conditions)
    {
        this.conditions = conditions;
        if (conditions.ContainsKey("survival"))
        {
            Debug.LogWarning("2111111");
        }
    }
}