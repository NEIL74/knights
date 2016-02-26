using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderUpOnScreen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Vector2 enterPosition;
    public Vector2 leavePosition;
    public DragSlider ds;
    public SkillCommands sc;

    public void OnPointerDown(PointerEventData eventData)
    {
        enterPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leavePosition = eventData.position;

        if (leavePosition.y > enterPosition.y && FightManager.Inst.curTurn == FightManager.Turn.Player && FightManager.Inst.lockAttak == false)
        {
            FightManager.Inst.lockAttak = true;
            TriggerSkill();
        }
    }

    public void TriggerSkill()
    {
        Debug.Log("trigger skill");

        if (ds.GetComponent<Slider>().value == 1) GameObject.Find("Fight/Heroes/knight0").GetComponent<TriggerSkills>().isBao = true;
        GameObject.Find("Fight/Heroes/knight0").GetComponent<TriggerSkills>().Trigger(sc.GetComponent<Text>().text);

        if (ds)
        {
            ds.GetComponent<Slider>().value = 0;
            ds.SetState();
        }
        if (sc)
        {
            sc.Reset();
        }
    }
}
