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
    private Color previousColor;
    private Animator displayAnim;

    private void Start()
    {
        display.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        soundScript = soundBase.GetComponent<SoundBase>();
        displayText = display.GetComponent<TextMesh>();
        displayAnim = display.GetComponent<Animator>();
        previousColor = displayText.color;
    }

    private void Animate(RaycastHit hit) 
    {
        if (hit.transform.IsChildOf(transform))
        {
            ChangeAndPlay(Names.Random);
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
            displayText.color = previousColor;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                Animate(hit);
        
                if (display.activeSelf)
                {
                    if (!float.TryParse(displayText.text, out float result)) displayText.text = "0";
                    if (hit.transform.tag == Names.Off)
                    {

                        audioSource.Play();
                        display.SetActive(false);

                    }
                    if (hit.transform.tag == Names.Numb && displayText.text.Length < 7)
                    {
                        if (!isFloat) displayText.text = (displayText.text == "0") ? hit.transform.name : (displayText.text + hit.transform.name);
                        else displayText.text = (displayText.text == "0") ? "0." + hit.transform.name : (displayText.text + hit.transform.name);
                        isFloat = false;
                    }

                    if (hit.transform.tag == Names.Add || hit.transform.tag == Names.Subtract || hit.transform.tag == Names.Multiply || hit.transform.tag == Names.Divide)
                    {
                        param = hit.transform.tag;
                        first_numb = float.Parse(displayText.text);
                        displayText.text = "0";
                    }
                    if (hit.transform.tag == Names.Calculate)
                    {
                        second_numb = float.Parse(displayText.text);

                        displayText.text = Calculator.Calculate(first_numb, second_numb, param, out int Error).ToString();
                        if (Error == 1)
                        {
                            ChangeAndPlay(Names.Error);
                            displayText.text = "can't";
                            previousColor = displayText.color;
                            displayText.color = Color.red;
                            displayAnim.SetTrigger(Names.Error);
                        }
                    }

                    if (hit.transform.tag == Names.Point)
                    {
                        isFloat = true;
                        intPart = float.Parse(displayText.text);
                    }

                    if (hit.transform.tag == Names.C)
                    {
                        displayText.text = "0";
                        isFloat = false;
                    }                    
                }
                else 
                {
                    if(hit.transform.tag == Names.On) 
                    {
                        display.SetActive(true);
                        displayText.text = "0";
                    }
                }
            }
        }
    }
}