using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragSlider : MonoBehaviour {

    public float _maxValue = 0;
    public float maxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            _maxValue = value;
            if (_maxValue >= 100) _maxValue = 100;
            Qi.text = string.Format("{0:0.0}", maxValue) + "%";
        }
    }
    public Text Qi;

	public void SetState()
    {
        if (GetComponent<Slider>().value > maxValue / 100) GetComponent<Slider>().value = maxValue / 100;
        
        if (GetComponent<Slider>().value == 1)
        {
            Button sword = GameObject.Find("Canvas").transform.Find("Panel/Button_Sword").GetComponent<Button>();
            Button shield = GameObject.Find("Canvas").transform.Find("Panel/Button_Shield").GetComponent<Button>();
            Button bow = GameObject.Find("Canvas").transform.Find("Panel/Button_Bow").GetComponent<Button>();
            Button pike = GameObject.Find("Canvas").transform.Find("Panel/Button_Pike").GetComponent<Button>();

            ColorBlock cb = sword.colors;
            cb.normalColor = new Color(1, 90f / 255, 90f / 255);
            cb.highlightedColor = new Color(1, 0, 0);

            sword.colors = cb;
            shield.colors = cb;
            bow.colors = cb;
            pike.colors = cb;

            GameObject.Find("Canvas").transform.Find("Panel/Image/Text").GetComponent<Text>().color = new Color(1, 0, 0);

        } else
        {
            Button sword = GameObject.Find("Canvas").transform.Find("Panel/Button_Sword").GetComponent<Button>();
            Button shield = GameObject.Find("Canvas").transform.Find("Panel/Button_Shield").GetComponent<Button>();
            Button bow = GameObject.Find("Canvas").transform.Find("Panel/Button_Bow").GetComponent<Button>();
            Button pike = GameObject.Find("Canvas").transform.Find("Panel/Button_Pike").GetComponent<Button>();

            ColorBlock cb = sword.colors;
            cb.normalColor = new Color(1, 1, 1);
            cb.highlightedColor = new Color(245f / 255, 245f / 255, 245f / 255);

            sword.colors = cb;
            shield.colors = cb;
            bow.colors = cb;
            pike.colors = cb;

            GameObject.Find("Canvas").transform.Find("Panel/Image/Text").GetComponent<Text>().color = new Color(50f / 255, 50f / 255, 50f / 255);
        }
    }
}
