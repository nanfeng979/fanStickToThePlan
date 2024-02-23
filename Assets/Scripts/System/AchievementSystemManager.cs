using System.Collections.Generic;
using UnityEngine;
using Y9g;

public abstract class AchievementSystemManager : Singleton<AchievementSystemManager>
{
    // 已完成的成就。
    protected Dictionary<AchievementType, List<Achievement>> completedAchievements = new Dictionary<AchievementType, List<Achievement>>();

    // 未完成的成就。
    protected Dictionary<AchievementType, List<Achievement>> unCompletedAchievements = new Dictionary<AchievementType, List<Achievement>>();

    void Start()
    {
        // 初始化成就系统。
        Init();

        // 分配未完成的成就。
        AllocatingAchievement();
        Debug.Log("uncompletedAchievements count: " + UnCompletedAchievementCount());
    }

    // 初始化成就系统。
    public abstract void Init();

    // 分配未完成的成就。
    public abstract void AllocatingAchievement();

    public void AddAchievement(Achievement achievement)
    {
        AchievementType type = achievement.type;
        // 如果成就已经解锁，添加到已完成的成就列表中。
        if (achievement.isUnlocked)
        {
            // 如果已完成的成就列表中没有该类型的成就，添加一个新的列表。
            if (!completedAchievements.ContainsKey(type))
            {
                completedAchievements.Add(type, new List<Achievement>());
            }
            // 添加到已完成的成就列表中。
            completedAchievements[type].Add(achievement);
        }
        // 如果成就未解锁，添加到未完成的成就列表中。
        else
        {
            // 如果未完成的成就列表中没有该类型的成就，添加一个新的列表。
            if (!unCompletedAchievements.ContainsKey(type))
            {
                unCompletedAchievements.Add(type, new List<Achievement>());
            }
            // 添加到未完成的成就列表中。
            unCompletedAchievements[type].Add(achievement);
        }
    }

    public int UnCompletedAchievementCount()
    {
        return unCompletedAchievements.Count;
    }
}

public enum AchievementType
{
    Always,
    LevelMap,
}

public class Achievement
{
    public GameObject gameObject;
    public AchievementType type;
    public string title;
    public string description;
    public Dictionary<string, string> conditions;
    public Dictionary<string, float> testConditions;
    public bool isUnlocked;
    public OnAchieveUpdate onAchieveUpdate;
    public Callback onLock;

    public Achievement(GameObject gameObject, AchievementType type, string title, string description, Dictionary<string, string> conditions, Dictionary<string, float> testConditions, OnAchieveUpdate onAchieveUpdate = null, Callback onLock = null)
    {
        this.gameObject = gameObject;
        this.type = type;
        this.title = title;
        this.description = description;
        this.conditions = new Dictionary<string, string>();
        foreach (var condition in conditions)
        {
            AddCondition(condition.Key, condition.Value);
        }
        this.testConditions = new Dictionary<string, float>();
        this.testConditions = testConditions;
        this.onAchieveUpdate = onAchieveUpdate;
        this.onLock = onLock;
    }

    public void AddCondition(string key, string value)
    {
        if (conditions.ContainsKey(key))
        {
            conditions[key] = value;
        }
        else
        {
            conditions.Add(key, value);
        }
    }
}

public delegate void Callback();
public delegate void OnAchieveUpdate(Dictionary<string, float> conditions);
