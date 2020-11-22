using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new task", menuName = "task")]
public class Task : ScriptableObject
{
    public string TaskName;
    public bool completed;

    public bool longTask;
    public int TaskNumber = 1;
}
