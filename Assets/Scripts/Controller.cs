using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject display;
    private TextMesh displayText;
    private float first_numb;
    private float second_numb;
    private float intPart;
    private bool isFloat = false;
    private string param;
    [SerializeField] private AudioSource onSound;
    [SerializeField] private AudioSource offSound;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource errorSound;

    [SerializeField] private Animator _onAnimator;
    [SerializeField] private Animator _offAnimator;
    [SerializeField] private Animator _equalsAnimator;
    [SerializeField] private Animator _cAnimator;
    [SerializeField] private Animator _pointAnimator;
    [SerializeField] private Animator _oneAnimator;
    [SerializeField] private Animator _twoAnimator;
    [SerializeField] private Animator _threeAnimator;
    [SerializeField] private Animator _fourAnimator;
    [SerializeField] private Animator _fiveAnimator;
    [SerializeField] private Animator _sixAnimator;
    [SerializeField] private Animator _sevenAnimator;
    [SerializeField] private Animator _eightAnimator;
    [SerializeField] private Animator _nineAnimator;
    [SerializeField] private Animator _zeroAnimator;

    void Start()
    {
        display.SetActive(false);
        displayText = display.GetComponent<TextMesh>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (display.activeSelf)
                {
                    if (hit.transform.tag == Names.Off)
                    {
                        offSound.Play();
                        _offAnimator.SetTrigger(Names.Click);
                        display.SetActive(false);

                    }
                    if (hit.transform.tag == Names.Numb && displayText.text.Length < 7)
                    {
                        clickSound.Play();
                        if (!isFloat) displayText.text = (displayText.text == "0") ? hit.transform.name : (displayText.text + hit.transform.name);
                        else displayText.text = (displayText.text == "0") ? "0." + hit.transform.name : (displayText.text + hit.transform.name);
                        isFloat = false;
                    }

                    if (hit.transform.tag == Names.Add || hit.transform.tag == Names.Subtract || hit.transform.tag == Names.Multiply || hit.transform.tag == Names.Divide)
                    {
                        clickSound.Play();
                        param = hit.transform.tag;
                        first_numb = float.Parse(displayText.text);
                        displayText.text = "0";
                    }
                    if (hit.transform.tag == Names.Calculate)
                    {
                        clickSound.Play();
                        _equalsAnimator.SetTrigger(Names.Click);
                        second_numb = float.Parse(displayText.text);

                        displayText.text = Calculator.Calculate(first_numb, second_numb, param, out int Error).ToString();
                        if (Error == 1)
                        {
                            errorSound.Play();
                            displayText.text = "can't";
                        }
                    }

                    if (hit.transform.tag == Names.Point)
                    {
                        clickSound.Play();
                        _pointAnimator.SetTrigger(Names.Click);
                        isFloat = true;
                        intPart = float.Parse(displayText.text);
                    }

                    if (hit.transform.tag == Names.C)
                    {
                        _cAnimator.SetTrigger(Names.Click);
                        displayText.text = "0";
                        isFloat = false;
                        clickSound.Play();
                    }

                    
                    //    switch (hit.transform.tag)
                    //{
                    //    case "1b":
                    //        _oneAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "2b":
                    //        _twoAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "3b":
                    //        _threeAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "4b":
                    //        _fourAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "5b":
                    //        _fiveAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "6b":
                    //        _sixAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "7b":
                    //        _sevenAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "8b":
                    //        _eightAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    case "9b":
                    //        _nineAnimator.SetTrigger(Names.Click);
                    //        break;
                    //    //case "0b":
                    //    //    _zeroAnimator.SetTrigger(Names.Click);
                    //    //    break;
                    //}
                    
                }
                else 
                {
                    if(hit.transform.tag == Names.On) 
                    {
                        onSound.Play();
                        _onAnimator.SetTrigger(Names.Click);
                        display.SetActive(true);
                        displayText.text = "0";
                    }
                }
            }
        }
    }
}