using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickTest : MonoBehaviour {
    public string audioName;
	public void AppendCommand(string s) {
        SkillCommands sc = GameObject.Find("Canvas").transform.Find("Panel/Image/Text").GetComponent<SkillCommands>();
        sc.Append(s);
        SystemTools.PlayAudio(audioName);
	}
}
