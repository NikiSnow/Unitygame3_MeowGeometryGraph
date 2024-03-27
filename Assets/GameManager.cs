using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using Unity.VisualScripting;
using System;
using Unity.Properties;

public class GameManager : MonoBehaviour
{
    //Dictionary<int, Dictionary<string, int>> DictOfline = new Dictionary<int, Dictionary<string, int>>()
    //{
    //    { 1, new Dictionary<string, int> { { "attached1", 1 }, { "attached2", 2 }, { "value", 2147483647 } } },
    //    { 2, new Dictionary<string, int> { { "attached1", 2 }, { "attached2", 3 }, { "value", 2147483647 } } },
    //    { 3, new Dictionary<string, int> { { "attached1", 1 }, { "attached2", 4 }, { "value", 2147483647 } } },
    //    { 4, new Dictionary<string, int> { { "attached1", 1 }, { "attached2", 3 }, { "value", 2147483647 } } },
    //    { 5, new Dictionary<string, int> { { "attached1", 2 }, { "attached2", 4 }, { "value", 2147483647 } } },
    //    { 6, new Dictionary<string, int> { { "attached1", 1 }, { "attached2", 5 }, { "value", 2147483647 } } },
    //    { 7, new Dictionary<string, int> { { "attached1", 3 }, { "attached2", 5 }, { "value", 2147483647 } } },
    //    { 8, new Dictionary<string, int> { { "attached1", 3 }, { "attached2", 4 }, { "value", 2147483647 } } },
    //    { 9, new Dictionary<string, int> { { "attached1", 4 }, { "attached2", 5 }, { "value", 2147483647 } } },
    //    { 10, new Dictionary<string, int> { { "attached1", 2 }, { "attached2", 5 }, { "value", 2147483647 } } },
    //};
    public TMP_Text outp;
    public GameObject panel;
    public GameObject panelwork;

    public TMP_InputField text1_2;
    public GameObject line12;
    public int value12 = 147483647;
    public TMP_InputField text2_3;
    public GameObject line23;
    public int value23 = 147483647;
    public TMP_InputField text1_4;
    public GameObject line14;
    public int value14 = 147483647;
    public TMP_InputField text1_3;
    public GameObject line13;
    public int value13 = 147483647;
    public TMP_InputField text2_4;
    public GameObject line24;
    public int value24 = 147483647;
    public TMP_InputField text1_5;
    public GameObject line15;
    public int value15 = 147483647;
    public TMP_InputField text3_5;
    public GameObject line35;
    public int value35 = 147483647;
    public TMP_InputField text3_4;
    public GameObject line34;
    public int value34 = 147483647;
    public TMP_InputField text4_5;
    public GameObject line45;
    public int value45 = 147483647;
    public TMP_InputField text2_5;
    public GameObject line25;
    public int value25 = int.MaxValue;

    private int input;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Addline()
    {
        panelwork.SetActive(false);
        panel.SetActive(true);
    }
    public void Refresh()
    {
        value12 = linecheck(text1_2, line12, value12);

        value13 = linecheck(text1_3, line13, value13);

        value14 = linecheck(text1_4, line14, value14);

        value15 = linecheck(text1_5, line15, value15);

        value23 = linecheck(text2_3, line23, value23);

        value24 = linecheck(text2_4, line24, value24);

        value25 = linecheck(text2_5, line25, value25);

        value34 = linecheck(text3_4, line34, value34);

        value35 = linecheck(text3_5, line35, value35);

        value45 = linecheck(text4_5, line45, value45);

        panel.SetActive(false);
    }
    public int linecheck(TMP_InputField text, GameObject activobj, int val)
    {
        int meow = Convert.ToInt32(text.text);
        if (meow != 0)
        {
            val = meow;
            activobj.SetActive(true);
            return val;

        }
        else
        {
            activobj.SetActive(false);
            val = int.MaxValue;
            return val;
        }
    }
    public void check(TMP_InputField inputField)
    {
        int inputtext;
        if (inputField.text.Length == 0)
        {
            inputtext = 0;
        }
        else
        {
            inputtext = Convert.ToInt32(inputField.text);
        }
        if (inputtext < 0)
        {
            inputtext = 0;
        }
        inputField.text = inputtext.ToString();

    }
}

