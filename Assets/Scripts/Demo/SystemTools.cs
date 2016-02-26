using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public static class SystemTools {

    public static void ShowMessage(string message)
    {
        Text text = GameObject.Find("Canvas/Panel_top/Text").GetComponent<Text>();
        text.text = message;
    }

    public static void PlayAudio(string audioName)
    {
        Debug.Log(audioName);
        //Debug.Log(Resources.Load("Resources/Audio/" + audioName) as AudioClip);
        //Debug.Log(Resources.Load("Resources/Audio/" + audioName + ".mp3") as AudioClip);
        //Debug.Log(Resources.Load<AudioClip>("Resources/Audio/" + audioName + ".mp3"));
        //Debug.Log(Resources.Load<AudioClip>("Resources/Audio/" + audioName));

        //Debug.Log((AudioClip)Resources.Load("Audio/" + audioName + ".mp3", typeof(AudioClip)));

        GameObject audio = GameObject.Find("Audio");
        audio.SetActive(false);
        audio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/" + audioName, typeof(AudioClip));
        audio.SetActive(true);
    }

}
