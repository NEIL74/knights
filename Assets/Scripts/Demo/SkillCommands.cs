using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillCommands : MonoBehaviour {

    public string commands = "";
    public Text text;

    public void Append(string command)
    {
        if (commands.Length >= 10) return;
        commands += command;
        text.text = commands;
    }

    public void Reset()
    {
        commands = "";
        text.text = commands;
    }

}
