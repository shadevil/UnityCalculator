using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject soundBase;
    private SoundBase soundScript;
    private TextMesh displayText;
    private float first_numb;
    private float second_numb;
    private float intPart;
    private bool isFloat = false;
    private string param;
    private AudioSource audioSource;

    private void Start()
    {
        display.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        soundScript = soundBase.GetComponent<SoundBase>();
        displayText = display.GetComponent<TextMesh>();
    }

    private void Animate(RaycastHit hit) 
    {
        if (hit.transform.IsChildOf(transform))
        {
            Animator anim = hit.transform.GetComponentInParent<Animator>();
            anim.SetTrigger(Names.Click);
        }
    }

    private void ChangeAndPlay(string clip) 
    {
        audioSource.clip = soundScript.GetClip(clip);
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                Animate(hit);
                if (display.activeSelf)
                {
                    if (hit.transform.tag == Names.Off)
                    {

                        audioSource.Play();
                        display.SetActive(false);

                    }
                    if (hit.transform.tag == Names.Numb && displayText.text.Length < 7)
                    {
                        ChangeAndPlay(Names.Random);
                        if (!isFloat) displayText.text = (displayText.text == "0") ? hit.transform.name : (displayText.text + hit.transform.name);
                        else displayText.text = (displayText.text == "0") ? "0." + hit.transform.name : (displayText.text + hit.transform.name);
                        isFloat = false;
                    }

                    if (hit.transform.tag == Names.Add || hit.transform.tag == Names.Subtract || hit.transform.tag == Names.Multiply || hit.transform.tag == Names.Divide)
                    {
                        ChangeAndPlay(Names.Random);
                        param = hit.transform.tag;
                        first_numb = float.Parse(displayText.text);
                        displayText.text = "0";
                    }
                    if (hit.transform.tag == Names.Calculate)
                    {
                        ChangeAndPlay(Names.Random);
                        second_numb = float.Parse(displayText.text);

                        displayText.text = Calculator.Calculate(first_numb, second_numb, param, out int Error).ToString();
                        if (Error == 1)
                        {
                            ChangeAndPlay(Names.Error);
                            displayText.text = "can't";
                        }
                    }

                    if (hit.transform.tag == Names.Point)
                    {
                        ChangeAndPlay(Names.Random);
                        isFloat = true;
                        intPart = float.Parse(displayText.text);
                    }

                    if (hit.transform.tag == Names.C)
                    {
                        ChangeAndPlay(Names.Random);
                        displayText.text = "0";
                        isFloat = false;
                    }                    
                }
                else 
                {
                    if(hit.transform.tag == Names.On) 
                    {
                        ChangeAndPlay(Names.On);
                        display.SetActive(true);
                        displayText.text = "0";
                    }
                }
            }
        }
    }
}