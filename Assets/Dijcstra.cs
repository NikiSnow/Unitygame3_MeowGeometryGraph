using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.Mathematics;

public class Dijcstra : MonoBehaviour
{

    class DijcstraData
    {
        public int price { get; set; }
        public int previos { get; set; }
    }
    public GameManager MainS;
    // Start is called before the first frame update
    public void Go()
    {
        clear();

        // Создание словаря с графом
        Dictionary<GameObject, Dictionary<string, int>> DictOfRebro = new Dictionary<GameObject, Dictionary<string, int>>()
        {
            { MainS.line12, new Dictionary<string, int> { { "nodefrom", 1 }, { "nodeto", 2 }, { "value", MainS.value12 } } },
            { MainS.line13, new Dictionary<string, int> { { "nodefrom", 1 }, { "nodeto", 3 }, { "value", MainS.value13 } } },
            { MainS.line14, new Dictionary<string, int> { { "nodefrom", 1 }, { "nodeto", 4 }, { "value", MainS.value14 } } },
            { MainS.line15, new Dictionary<string, int> { { "nodefrom", 1 }, { "nodeto", 5 }, { "value", MainS.value15 } } },
            { MainS.line23, new Dictionary<string, int> { { "nodefrom", 2 }, { "nodeto", 3 }, { "value", MainS.value23 } } },
            { MainS.line24, new Dictionary<string, int> { { "nodefrom", 2 }, { "nodeto", 4 }, { "value", MainS.value24 } } },
            { MainS.line25, new Dictionary<string, int> { { "nodefrom", 2 }, { "nodeto", 5 }, { "value", MainS.value25 } } },
            { MainS.line34, new Dictionary<string, int> { { "nodefrom", 3 }, { "nodeto", 4 }, { "value", MainS.value34 } } },
            { MainS.line35, new Dictionary<string, int> { { "nodefrom", 3 }, { "nodeto", 5 }, { "value", MainS.value35 } } },
            { MainS.line45, new Dictionary<string, int> { { "nodefrom", 4 }, { "nodeto", 5 }, { "value", MainS.value45 } } }
        };

        if (DictOfRebro[MainS.line45]["value"] != int.MaxValue | DictOfRebro[MainS.line35]["value"] != int.MaxValue | DictOfRebro[MainS.line25]["value"] != int.MaxValue | DictOfRebro[MainS.line15]["value"] != int.MaxValue)
        {
            if(DictOfRebro[MainS.line12]["value"] != int.MaxValue | DictOfRebro[MainS.line13]["value"] != int.MaxValue | DictOfRebro[MainS.line14]["value"] != int.MaxValue | DictOfRebro[MainS.line15]["value"] != int.MaxValue)
            {
                long v15 = DictOfRebro[MainS.line15]["value"];
                long v125 = DictOfRebro[MainS.line12]["value"] + DictOfRebro[MainS.line25]["value"];
                long v135 = DictOfRebro[MainS.line13]["value"] + DictOfRebro[MainS.line35]["value"];
                long v145 = DictOfRebro[MainS.line14]["value"] + DictOfRebro[MainS.line45]["value"];
                long v1235 = DictOfRebro[MainS.line12]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line35]["value"];
                long v1245 = DictOfRebro[MainS.line12]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line45]["value"];
                long v1325 = DictOfRebro[MainS.line13]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line25]["value"];
                long v1345 = DictOfRebro[MainS.line13]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line45]["value"];
                long v1425 = DictOfRebro[MainS.line14]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line25]["value"];
                long v1435 = DictOfRebro[MainS.line14]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line35]["value"];
                long v12345 = DictOfRebro[MainS.line12]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line45]["value"];
                long v12435 = DictOfRebro[MainS.line12]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line35]["value"];
                long v13245 = DictOfRebro[MainS.line13]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line45]["value"];
                long v13425 = DictOfRebro[MainS.line13]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line25]["value"];
                long v14235 = DictOfRebro[MainS.line14]["value"] + DictOfRebro[MainS.line24]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line35]["value"];
                long v14325 = DictOfRebro[MainS.line14]["value"] + DictOfRebro[MainS.line34]["value"] + DictOfRebro[MainS.line23]["value"] + DictOfRebro[MainS.line25]["value"];
                v125 = (v125 < 0) ? int.MaxValue : v125;
                v135 = (v135 < 0) ? int.MaxValue : v135;
                v145 = (v145 < 0) ? int.MaxValue : v145;
                if (MainS.line12.active == false)
                {
                    v1235= int.MaxValue;
                    v1245= int.MaxValue;
                    v12345= int.MaxValue;
                    v12435= int.MaxValue;
                }
                if (MainS.line13.active == false)
                {
                    v1325= int.MaxValue;
                    v1345 = int.MaxValue;
                    v13245 = int.MaxValue;
                    v13425 = int.MaxValue;

                }
                if (MainS.line23.active == false)
                {
                    v1235 = int.MaxValue;
                    v1325 = int.MaxValue;
                    v12345 = int.MaxValue;
                    v13245 = int.MaxValue;
                    v14235 = int.MaxValue;
                    v14325 = int.MaxValue;
                }
                if (MainS.line24.active == false)
                {
                    v1245 = int.MaxValue;
                    v1425 = int.MaxValue;
                    v12435 = int.MaxValue;
                    v13245 = int.MaxValue;
                    v13425 = int.MaxValue;
                    v14235 = int.MaxValue;
                }
                if (MainS.line25.active == false)
                {
                    v1325 = int.MaxValue;
                    v1425 = int.MaxValue;
                    v13425 = int.MaxValue;
                    v14325 = int.MaxValue;
                }
                if (MainS.line34.active == false)
                {
                    v1345 = int.MaxValue;
                    v1435 = int.MaxValue;
                    v12345 = int.MaxValue;
                    v12435 = int.MaxValue;
                    v13425 = int.MaxValue;
                    v14325 = int.MaxValue;
                }
                if (MainS.line35.active == false)
                {
                    v1235 = int.MaxValue;
                    v1435 = int.MaxValue;
                    v12435 = int.MaxValue;
                    v14235 = int.MaxValue;
                }
                if (MainS.line45.active == false)
                {
                    v1245 = int.MaxValue;
                    v1345 = int.MaxValue;
                    v12345 = int.MaxValue;
                    v13245 = int.MaxValue;
                }
                if (MainS.line15.active== true)
                {
                    Debug.Log("v15 " + v15);
                }
                Debug.Log("v125 " + v125);
                Debug.Log("v135 " + v135);
                Debug.Log("v145 " + v145);
                Debug.Log("v1235 " + v1235);
                Debug.Log("v1245 " + v1245);
                Debug.Log("v1235 " + v1325);
                Debug.Log("v1345 " + v1345);
                Debug.Log("v1425 " + v1425);
                Debug.Log("v1435 " + v1435);
                Debug.Log("v12345 " + v12345);
                Debug.Log("v12435 " + v12435);
                Debug.Log("v13245 " + v13245);
                Debug.Log("v13425 " + v13425);
                Debug.Log("v14235 " + v14235);
                Debug.Log("v14325 " + v14325);

                long min = long.MaxValue;
                int ind = -1;
                if (v15 < min)
                {
                    min = v15;
                    ind = 0;
                } //0
                if (v125 < min)
                {
                    min = v125;
                    ind = 1;
                } //1
                if (v135 < min)
                {
                    min = v135;
                    ind = 2;
                } //2
                if (v145 < min)
                {
                    min = v145;
                    ind = 3;
                } //3
                if (v1235 < min)
                {
                    min = v1235;
                    ind = 4;
                } //4
                if (v1245 < min)
                {
                    min = v1245;
                    ind = 5;
                } //5
                if (v1325 < min)
                {
                    min = v1325;
                    ind = 6;
                } //6
                if (v1345 < min)
                {
                    min = v1345;
                    ind = 7;
                } //7
                if (v1425 < min)
                {
                    min = v1425;
                    ind = 8;
                } //8
                if (v1435 < min)
                {
                    min = v1435;
                    ind = 9;
                } //9
                if (v12345 < min)
                {
                    min = v12345;
                    ind = 10;
                } //10
                if (v12435 < min)
                {
                    min = v12435;
                    ind = 11;
                } //11
                if (v13245 < min)
                {
                    min = v13245;
                    ind = 12;
                } //12
                if (v13425 < min)
                {
                    min = v13425;
                    ind = 13;
                } //13
                if (v14235 < min)
                {
                    min = v14235;
                    ind = 14;
                } //14
                if (v14325 < min)
                {
                    min = v14325;
                    ind = 15;
                } //15
                Debug.Log(ind);
                MainS.outp.gameObject.SetActive(true);
                MainS.outp.text = "Минимальный путь равен: " + min;
                if (ind == 0)
                {
                    Debug.Log("wha1");
                    StartCoroutine(c15());
                    Debug.Log("wha2");
                }
                if (ind == 1)
                {
                    Debug.Log("who1");
                    StartCoroutine(c125());
                    Debug.Log("who2");

                }
                if (ind == 2)
                {
                    StartCoroutine(c135());
                }
                if (ind == 3)
                {
                    StartCoroutine(c145());
                }
                if (ind == 4)
                {
                    StartCoroutine(c1235());
                }
                if (ind == 5)
                {
                    StartCoroutine(c1245());
                }
                if (ind == 6)
                {
                    StartCoroutine(c1325());
                }
                if (ind == 7)
                {
                    StartCoroutine(c1345());
                }
                if (ind == 8)
                {
                    StartCoroutine(c1425());
                }
                if (ind == 9)
                {
                    StartCoroutine(c1435());
                }
                if (ind == 10)
                {
                    StartCoroutine(c12345());
                }
                if (ind == 11)
                {
                    StartCoroutine(c12435());
                }
                if (ind == 12)
                {
                    StartCoroutine(c13245());
                }
                if (ind == 13)
                {
                    StartCoroutine(c13425());
                }
                if (ind == 14)
                {
                    StartCoroutine(c14235());
                }
                if (ind == 15)
                {
                    StartCoroutine(c14325());
                }

            }
            else
            {
                MainS.panelwork.SetActive(true);
            }
        }
        else
        {
            MainS.panelwork.SetActive(true);
        }

        Dictionary<int, Dictionary<int, int>> DictOfNodes = new Dictionary<int, Dictionary<int, int>>()
        {
            { 1, new Dictionary<int, int> { { 1, 0 } } },
            { 2, new Dictionary<int, int> { { 2, MainS.value12 } } },
            { 3, new Dictionary<int, int> { { 3, MainS.value13 } } },
            { 4, new Dictionary<int, int> { { 4, MainS.value14 } } },
            { 5, new Dictionary<int, int> { { 5, MainS.value15 } } }
        };
    }
    IEnumerator c15()
    {
        Debug.Log("c15");
        int x = -10;
        Renderer l15 = MainS.line15.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l15.material.color = Color.black;
            yield return new WaitForSeconds(1.5f);
            clear();
            yield return new WaitForSeconds(1f);
        }
        l15.material.color = Color.black;
    }
    IEnumerator c125()
    {
        Debug.Log("c125");
        int x = -10;
        Renderer l12 = MainS.line12.GetComponent<Renderer>();
        Renderer l25 = MainS.line25.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l12.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l25.material.color = Color.black;
            yield return new WaitForSeconds(1.5f);
            clear();
            yield return new WaitForSeconds(0.5f);
        }
        l12.material.color = Color.black;
        yield return new WaitForSeconds(0.7f);
        l25.material.color = Color.black;
    }
    IEnumerator c135()
    {
        int x = -10;
        Renderer l13 = MainS.line13.GetComponent<Renderer>();
        Renderer l35 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l13.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l35.material.color = Color.black;
            yield return new WaitForSeconds(1.5f);
            clear();
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator c145()
    {
        int x = -10;
        Renderer l14 = MainS.line14.GetComponent<Renderer>();
        Renderer l45 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l14.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l45.material.color = Color.black;
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }

    }
    IEnumerator c1235()
    {
        int x = -10;
        Renderer l12 = MainS.line12.GetComponent<Renderer>();
        Renderer l23 = MainS.line23.GetComponent<Renderer>();
        Renderer l35 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l12.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l23.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l35.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c1245()
    {
        int x = -10;
        Renderer l1 = MainS.line12.GetComponent<Renderer>();
        Renderer l2 = MainS.line24.GetComponent<Renderer>();
        Renderer l3 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c1325()
    {
        int x = -10;
        Renderer l1 = MainS.line13.GetComponent<Renderer>();
        Renderer l2 = MainS.line23.GetComponent<Renderer>();
        Renderer l3 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c1345()
    {
        int x = -10;
        Renderer l1 = MainS.line13.GetComponent<Renderer>();
        Renderer l2 = MainS.line34.GetComponent<Renderer>();
        Renderer l3 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c1425()
    {
        int x = -10;
        Renderer l1 = MainS.line14.GetComponent<Renderer>();
        Renderer l2 = MainS.line24.GetComponent<Renderer>();
        Renderer l3 = MainS.line25.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c1435()
    {
        int x = -10;
        Renderer l1 = MainS.line14.GetComponent<Renderer>();
        Renderer l2 = MainS.line34.GetComponent<Renderer>();
        Renderer l3 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c12345()
    {
        int x = -10;
        Renderer l1 = MainS.line12.GetComponent<Renderer>();
        Renderer l2 = MainS.line23.GetComponent<Renderer>();
        Renderer l3 = MainS.line34.GetComponent<Renderer>();
        Renderer l4 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c12435()
    {
        int x = -10;
        Renderer l1 = MainS.line12.GetComponent<Renderer>();
        Renderer l2 = MainS.line24.GetComponent<Renderer>();
        Renderer l3 = MainS.line34.GetComponent<Renderer>();
        Renderer l4 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c13245()
    {
        int x = -10;
        Renderer l1 = MainS.line13.GetComponent<Renderer>();
        Renderer l2 = MainS.line23.GetComponent<Renderer>();
        Renderer l3 = MainS.line24.GetComponent<Renderer>();
        Renderer l4 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c13425()
    {
        int x = -10;
        Renderer l1 = MainS.line13.GetComponent<Renderer>();
        Renderer l2 = MainS.line23.GetComponent<Renderer>();
        Renderer l3 = MainS.line24.GetComponent<Renderer>();
        Renderer l4 = MainS.line45.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c14235()
    {
        int x = -10;
        Renderer l1 = MainS.line14.GetComponent<Renderer>();
        Renderer l2 = MainS.line24.GetComponent<Renderer>();
        Renderer l3 = MainS.line23.GetComponent<Renderer>();
        Renderer l4 = MainS.line35.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator c14325()
    {
        int x = -10;
        Renderer l1 = MainS.line14.GetComponent<Renderer>();
        Renderer l2 = MainS.line34.GetComponent<Renderer>();
        Renderer l3 = MainS.line23.GetComponent<Renderer>();
        Renderer l4 = MainS.line25.GetComponent<Renderer>();
        while (x < 0)
        {
            x++;
            l1.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l2.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l3.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            l4.material.color = Color.black;
            yield return new WaitForSeconds(0.7f);
            yield return new WaitForSeconds(1.5f);
            if (x != 0)
            {
                clear();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    public void clear()
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer rend in renderers)
        {
            rend.material.color = Color.white;
        }
    }

}