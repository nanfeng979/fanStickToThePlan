using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToThePlanAchievementSystemManager : AchievementSystemManager
{
    public override void Init()
    {
        // 添加成就。
        AddAchievement(new Achievement(
            GameObject.Find("PlayerTest1"),
            AchievementType.LevelMap, 
            "活下去", "存活 1 分钟",
            new Dictionary<string, string> { { "survival", "10" } },
            new Dictionary<string, float> { { "survival", 10.0f } },
            onAchieveUpdate: DOnAchieveUpdate));
    }

    public override void AllocatingAchievement()
    {
        // 分配成就。
        foreach (var achievement in unCompletedAchievements)
        {
            List<Achievement> achievements = achievement.Value;
            foreach (var a in achievements)
            {
                a.gameObject.GetComponent<AchievemenListener>().AddOnAchieveUpdate(a.onAchieveUpdate);
                a.gameObject.GetComponent<AchievemenListener>().AddConditions(a.testConditions);
            }
        }
    }

    private void DOnAchieveUpdate(Dictionary<string, float> conditions)
    {
        if (conditions.ContainsKey("survival"))
        {
            if (conditions["survival"] > 0)
            {
                conditions["survival"] -= Time.deltaTime;
                Debug.Log("survival: " + conditions["survival"]);
            }
            else
            {
                Debug.LogWarning("okkkkkkkkkk");
            }
        }
        else
        {
            Debug.Log("no survival");
        }
    }


}