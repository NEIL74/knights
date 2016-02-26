using UnityEngine;
using System.Collections;
using System;

public class TriggerSkills : MonoBehaviour {

    public string commands = "";
    public string[] commandsSeq;
    public string[] commandsName;
    public float attackInterval = 1f;
    public float stayInterval = 0.5f;
    public Vector3 offset = Vector3.zero;
    public bool isBao = false;
    public DragSlider ds;

    public RoleInfo SelectTargets()
    {
        RoleInfo info = null;
        System.Random rnd = new System.Random();
        if (GetComponent<RoleInfo>().role == RoleInfo.Role.Player)
        {
            int heroesCount = GameObject.Find("Fight").transform.Find("Monsters").childCount;
            int targetIndex = rnd.Next(heroesCount);
            info = GameObject.Find("Fight").transform.Find("Monsters").GetChild(targetIndex).GetComponent<RoleInfo>();
            offset = new Vector3(-1.5f, -1.5f, 0);
        } else if (GetComponent<RoleInfo>().role == RoleInfo.Role.Enemy)
        {
            int heroesCount = GameObject.Find("Fight").transform.Find("Heroes").childCount;
            int targetIndex = rnd.Next(heroesCount);
            info = GameObject.Find("Fight").transform.Find("Heroes").GetChild(targetIndex).GetComponent<RoleInfo>();
            offset = new Vector3(1.5f, 1.5f, 0);
        }
        return info;
    }

    IEnumerator _WaitForSeconds(float delay, Action Func)
    {
        yield return new WaitForSeconds(delay);
        Func();
    }

    public void Attack(string skill, string skillName)
    {
        RoleInfo info = SelectTargets();
        if (info == null) return;

        Vector3 origin = transform.localPosition;
        Vector3 target = info.transform.localPosition + offset;
    
        transform.localPosition = target;

        SystemTools.ShowMessage(isBao ? "666 " + skillName + " 233" : skillName);

        Debug.Log(skill);

        StartCoroutine(_WaitForSeconds(attackInterval, () => {
            transform.localPosition = origin;

            StartCoroutine(_WaitForSeconds(stayInterval, () =>
            {
                Trigger(commands);
            }));
        }));
    }

    public void Trigger(string sequences)
    {
        Debug.Log(sequences);

        commands = sequences;

        if (commands == "")
        {
            FightManager.Inst.ReverseTurn();
        } else
        {
            if (ds)
            {
                ds.maxValue += 50;
            }

            string bestMatch = "";
            string name = "";
            for (int i = 0; i < commandsSeq.Length; ++i)
            {
                if (commands.StartsWith(commandsSeq[i]))
                {
                    if (commandsSeq[i].Length > bestMatch.Length)
                    {
                        bestMatch = commandsSeq[i];
                        name = commandsName[i];
                    }
                }
            }

            if (bestMatch == "")
            {
                FightManager.Inst.ReverseTurn();
                Debug.Log("NO!!!! fuck");
                return;
            }

            Debug.Log("ohohoh");
            Attack(bestMatch, name);
            commands = commands.Substring(bestMatch.Length, commands.Length - bestMatch.Length);
        }
    }
}
