using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class Hint : MonoBehaviour
{
    int number;
    public GameObject CubeHint;
    List<GameObject> PoolCubes_Hint;

    public int NumberElement
    {
        get
        {
            return GetNumber();
        }
        set
        { }
    }
    private void Awake()
    {
        CommonData.hint = this;
        CommonData.HintArr = new int[CommonData.Height_HintArr, CommonData.Lenght_HintArr];
        for (int i = 0; i < CommonData.Height_HintArr; i++)
        {
            for (int k = 0; k < CommonData.Lenght_HintArr; k++)
            {
                CommonData.HintArr[i, k] = 0;
            }
        }
        PoolCubes_Hint = new List<GameObject>();

        for (int i = 0; i < CommonData.Height_HintArr * CommonData.Lenght_HintArr; i++)
        {
            PoolCubes_Hint.Add(Instantiate(CubeHint));
        }
        SetNumber();
    }
    void ResetHintArr()
    {
        int p = 0;
        for (int i = 0; i < CommonData.Height_HintArr; i++)
        {
            for (int k = 0; k < CommonData.Lenght_HintArr; k++)
            {
                PoolCubes_Hint[p].transform.position = new Vector3(i, 0, k + 12);

                if (CommonData.HintArr[i, k] == 0)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.white;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.gray;
                }
                if (CommonData.HintArr[i, k] == 1)
                {
                    // PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.green;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.green;
                }
                if (CommonData.HintArr[i, k] == 2)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.blue;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (CommonData.HintArr[i, k] == 3)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (CommonData.HintArr[i, k] == 4)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                if (CommonData.HintArr[i, k] == 5)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.cyan;
                }
                if (CommonData.HintArr[i, k] == 6)
                {
                    //PoolCubes_Hint[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes_Hint[p].GetComponent<SpriteRenderer>().color = Color.red;
                }


                p++;
            }
        }
    }
    int GetNumber()
    {
        int nb = number;
        SetNumber();
        return nb;
    }
    void SetNumber()
    {
        for (int i = 0; i < CommonData.Height_HintArr; i++)
        {
            for (int k = 0; k < CommonData.Lenght_HintArr; k++)
            {
                CommonData.HintArr[i, k] = 0;
            }
        }
        number = Random.Range(1, 20);
        number = 2;
        switch (number)
        {
            case 1:
                CommonData.HintArr[0, 1] = 1;
                CommonData.HintArr[0, 2] = 1;
                CommonData.HintArr[0, 3] = 1;
                CommonData.HintArr[0, 4] = 1;

                break;
            case 2:
                CommonData.HintArr[0, 2] = 1;
                CommonData.HintArr[1, 2] = 1;
                CommonData.HintArr[2, 2] = 1;
                CommonData.HintArr[3, 2] = 1;

                break;
            case 3:
                CommonData.HintArr[2, 2] = 2;
                CommonData.HintArr[1, 2] = 2;
                CommonData.HintArr[0, 2] = 2;
                CommonData.HintArr[0, 3] = 2;
                break;
            case 4:
                CommonData.HintArr[0, 1] = 2;
                CommonData.HintArr[0, 2] = 2;
                CommonData.HintArr[0, 3] = 2;
                CommonData.HintArr[1, 3] = 2;
                break;
            case 5:
                CommonData.HintArr[0, 3] = 2;
                CommonData.HintArr[1, 3] = 2;
                CommonData.HintArr[2, 3] = 2;
                CommonData.HintArr[2, 2] = 2;
                break;
            case 6:
                CommonData.HintArr[1, 3] = 2;
                CommonData.HintArr[1, 2] = 2;
                CommonData.HintArr[1, 1] = 2;
                CommonData.HintArr[0, 1] = 2;
                break;
            case 7:
                CommonData.HintArr[1, 1] = 3;
                CommonData.HintArr[1, 2] = 3;
                CommonData.HintArr[1, 3] = 3;
                CommonData.HintArr[0, 2] = 3;

                break;
            case 8:
                CommonData.HintArr[0, 1] = 3;
                CommonData.HintArr[1, 1] = 3;
                CommonData.HintArr[2, 1] = 3;
                CommonData.HintArr[1, 2] = 3;
                break;
            case 9:
                CommonData.HintArr[0, 3] = 3;
                CommonData.HintArr[0, 2] = 3;
                CommonData.HintArr[0, 1] = 3;
                CommonData.HintArr[1, 2] = 3;
                break;
            case 10:
                CommonData.HintArr[2, 2] = 3;
                CommonData.HintArr[1, 2] = 3;
                CommonData.HintArr[0, 2] = 3;
                CommonData.HintArr[1, 1] = 3;
                break;
            case 11:
                CommonData.HintArr[2, 1] = 4;
                CommonData.HintArr[1, 1] = 4;
                CommonData.HintArr[0, 1] = 4;
                CommonData.HintArr[0, 0] = 4;

                break;
            case 12:
                CommonData.HintArr[1, 2] = 4;
                CommonData.HintArr[1, 1] = 4;
                CommonData.HintArr[1, 0] = 4;
                CommonData.HintArr[2, 0] = 4;
                break;
            case 13:
                CommonData.HintArr[0, 1] = 4;
                CommonData.HintArr[1, 1] = 4;
                CommonData.HintArr[2, 1] = 4;
                CommonData.HintArr[2, 2] = 4;
                break;
            case 14:
                CommonData.HintArr[1, 0] = 4;
                CommonData.HintArr[1, 1] = 4;
                CommonData.HintArr[1, 2] = 4;
                CommonData.HintArr[0, 2] = 4;
                break;
            case 15:
                CommonData.HintArr[0, 1] = 1;
                CommonData.HintArr[0, 2] = 1;
                CommonData.HintArr[1, 1] = 1;
                CommonData.HintArr[1, 2] = 1;
                break;
            case 16:
                CommonData.HintArr[0, 0] = 5;
                CommonData.HintArr[0, 1] = 5;
                CommonData.HintArr[1, 1] = 5;
                CommonData.HintArr[1, 2] = 5;
                break;
            case 17:
                CommonData.HintArr[2, 1] = 5;
                CommonData.HintArr[1, 1] = 5;
                CommonData.HintArr[1, 2] = 5;
                CommonData.HintArr[0, 2] = 5;
                break;
            case 18:
                CommonData.HintArr[1, 0] = 6;
                CommonData.HintArr[1, 1] = 6;
                CommonData.HintArr[0, 1] = 6;
                CommonData.HintArr[0, 2] = 6;
                break;
            case 19:
                CommonData.HintArr[0, 1] = 6;
                CommonData.HintArr[1, 1] = 6;
                CommonData.HintArr[1, 2] = 6;
                CommonData.HintArr[2, 2] = 6;
                break;

        }
        ResetHintArr();
    }
}
