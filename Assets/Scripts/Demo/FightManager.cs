using UnityEngine;
using System.Collections;
using System;

public class FightManager : MonoBehaviour {

    public static FightManager Inst = null;
    public int attackRoles = 0;
    public float unitAttackTime = 3f;
    public bool lockAttak = false;
    void Start()
    {
        Inst = this;
        curTurn = Turn.Player;
        attackRoles = GameObject.Find("Fight/Heroes").transform.childCount;
    }

	public enum Turn { Player, Enemy };
    public Turn curTurn = Turn.Player;

    public void ReverseTurn()
    {
        if (CheckCanReverse() == false) return;
        if (curTurn == Turn.Player)
        {
            lockAttak = false;

            SystemTools.ShowMessage("Enemy's Turn");

            curTurn = Turn.Enemy;
            attackRoles = GameObject.Find("Fight/Monsters").transform.childCount;
            for (int i = 0; i < attackRoles; ++i)
            {
                int idx = i;
                StartCoroutine(_WaitFor(i * unitAttackTime, () => {
                    GameObject.Find("Fight/Monsters").transform.GetChild(idx).GetComponent<TriggerSkills>().Trigger("A");
                }));
            }
        }
        else {
            lockAttak = false;

            SystemTools.ShowMessage("Player's Turn");

            curTurn = Turn.Player;
            attackRoles = GameObject.Find("Fight/Heroes").transform.childCount;

            GameObject.Find("Fight/Heroes").transform.GetChild(0).GetComponent<TriggerSkills>().isBao = false;
        }
    }

    public bool CheckCanReverse()
    {
        attackRoles -= 1;
        Debug.Log(attackRoles);
        return attackRoles <= 0;
    }

    IEnumerator _WaitFor(float delay,  Action Func)
    {
        yield return new WaitForSeconds(delay);
        Func();
    }
}
