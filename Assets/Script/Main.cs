﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    public GameObject CubePrefab;
    BlockController blockController;
    NextElement nextElement;
    float timeCountForAvtoDown;
    float timeCountForHighSpeed;
    float TimeLevelCount;
    public Text Line;
    public Text Score;
    public Text Level;
    public GameObject Logo_Game_Over;
    public GameObject Logo_Tetris;
    public GameObject logo_Pause;
    bool Anim_Full;
    public AudioSource Audio_Rotation;
    public AudioSource Audio_Line_Complite;
    public int Line_table = 0;
    public int Score_table = 0;
    bool IsOk;
    GameObject Parent_lines;
    void Start()
    {
        CommonData.Play = true;
        CommonData.Logo_GameOver = Logo_Game_Over;
        CommonData.Logo_GameOver.SetActive(false);
        CommonData.Logo_Tetris = Logo_Tetris;
        CommonData.Logo_Tetris.SetActive(false);
        CommonData.Logo_Pause = logo_Pause;
        CommonData.Logo_Pause.SetActive(false);
        CommonData.timestep_Go = false;
        CommonData.Tetris_Logo_bool = false;
        CommonData.animation_1_active = false;
        CommonData.animation_2_active = false;
        CommonData.compressactive = false;
        CommonData.stepafteranimation = true;
        CommonData.CommonArr = new int[CommonData.Height, CommonData.Lenght];
        CommonData.PoolCubes = new GameObject[CommonData.Height, CommonData.Lenght];
        Parent_lines = new GameObject();

        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                CommonData.CommonArr[i, k] = 0;
                CommonData.PoolCubes[i, k] = Instantiate(CubePrefab);
            }
        }
        nextElement = new NextElement();
        blockController = new BlockController(nextElement.GeneretedSBT(CommonData.hint.NumberElement));
        ResetPosition();
        TimeLevelCount = 1;
    }
    void Update()
    {
        if (CommonData.timestep >= 0.25 && CommonData.timestep_Go && CommonData.stepafteranimation)
        {
            Next_Element(blockController);
            ResetPosition();
            CommonData.timestep_Go = false;
        }
        CommonData.timestep += Time.deltaTime;
        CommonData.timeforLogoTetris += Time.deltaTime;
        CommonData.countforanimation += Time.deltaTime;
        timeCountForHighSpeed += Time.deltaTime;
        timeCountForAvtoDown += Time.deltaTime;

        if (CommonData.animation_1_active)
        {
            Animation_1_lines();
        }
        if (CommonData.animation_2_active)
        {
            StartCoroutine(anim_fall_lines());
            CommonData.animation_2_active = false;
            CommonData.animation_1_active = false;
        }

        if (CommonData.compressactive)
        {
            CompressLine();
            CommonData.compressactive = false;
            CommonData.stepafteranimation = true;

        }

        if (timeCountForAvtoDown > TimeLevelCount && CommonData.stepafteranimation && CommonData.Play)
        {
            blockController.DownAuto();
            if (CommonData.timestep_Go)
            {
                CommonData.countforanimation = 0;
                CommonData.animation_1_active = true;
            }
            ResetPosition();
            timeCountForAvtoDown = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow) && CommonData.Play)
        {
            if (timeCountForHighSpeed > 0.1)
            {
                blockController.Right();
                timeCountForHighSpeed = 0;
                ResetPosition();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && CommonData.Play)
        {
            if (timeCountForHighSpeed > 0.1)
            {
                blockController.Left();
                timeCountForHighSpeed = 0;
                ResetPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && CommonData.Play)
        {
            blockController.DownOneStep();
            CommonData.countforanimation = 0;
            CommonData.animation_1_active = true;
            ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CommonData.Play)
        {
            Sound_Rotation();
            CommonData.ResetCasper();
            blockController.Rotate();
            CommonData.animation_1_active = false;
            ResetPosition();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame(blockController);
            ResetPosition();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CommonData.Play)
            {
                CommonData.Play = false;
                CommonData.Logo_Pause.SetActive(true);
            }
            else
            {
                CommonData.Play = true;
                CommonData.Logo_Pause.SetActive(false);
            }
        }

        Line.text = "Line " + CommonData.Line;
        Score.text = "Score " + CommonData.Score;
        LevelTimeAvtoDownStep();
        Set_Logo_Tetris();
    }
    void Set_Logo_Tetris()
    {
        if (CommonData.Tetris_Logo_bool && CommonData.timeforLogoTetris >= 0.8f)
        {

            CommonData.Logo_Tetris.SetActive(false);
            CommonData.Tetris_Logo_bool = false;
        }

    }
    void LevelTimeAvtoDownStep()
    {
        switch (CommonData.Line / 20)
        {
            case 0:
                TimeLevelCount = 1;
                Level.text = "Level 1 ";
                break;

            case 1:
                TimeLevelCount = 0.8f;
                Level.text = "Level 2 ";
                break;

            case 2:
                TimeLevelCount = 0.6f;
                Level.text = "Level 3 ";
                break;

            default:
                TimeLevelCount = 0.4f;
                Level.text = "Level 4 ";
                break;
        }

    }
    void ResetPosition()
    {
        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                CommonData.PoolCubes[i, k].transform.position = new Vector3(i, 0, k);
                CommonData.PoolCubes[i, k].transform.eulerAngles = new Vector3(-90, 0, 0);
                if (CommonData.CommonArr[i, k] == 0)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.gray;
                }
                if (CommonData.CommonArr[i, k] == 1)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.green;
                }
                if (CommonData.CommonArr[i, k] == 2)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (CommonData.CommonArr[i, k] == 3)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (CommonData.CommonArr[i, k] == 4)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                if (CommonData.CommonArr[i, k] == 5)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.cyan;
                }
                if (CommonData.CommonArr[i, k] == 6)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (CommonData.CommonArr[i, k] == -1)
                {
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
    public void Next_Element(BlockController bc)
    {
        bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
    }

    void ResetGame(BlockController bc)
    {
        CommonData.Play = true;
        CommonData.CommonArr = new int[CommonData.Height, CommonData.Lenght];
        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                CommonData.CommonArr[i, k] = 0;
            }
        }
        NextElement nextElement = new NextElement();
        bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
        Line_table = 0;
        Score_table = 0;
        CommonData.Line = 0;
        CommonData.Score = 0;
    }
    void Animation_1_lines()
    {
        bool IsOk = false;
        for (int i = CommonData.Height - 1; i >= 0; i--)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                if (CommonData.CommonArr[i, k] > 0)
                {
                    IsOk = true;
                }
                else
                {
                    IsOk = false;
                    break;
                }
            }
            if (IsOk)
            {
                CommonData.stepafteranimation = false;
                setanimation();
                for (int k = 0; k < CommonData.Lenght; k++)
                {
                    CommonData.PoolCubes[i, k].transform.eulerAngles = new Vector3(-CommonData.rotatecoef_2, 90, -90);
                }
                if (CommonData.countforanimation >= 0.25f)
                {
                    default_position();
                    CommonData.animation_2_active = true;

                }
            }
        }

    }
    void setanimation()
    {
        if (CommonData.skalecoef < 0.5f && !CommonData.reversforpulse)
        {
            CommonData.skalecoef += 0.005f;
            if (CommonData.skalecoef >= 0.5)
            {
                CommonData.reversforpulse = true;
            }
        }
        if (CommonData.reversforpulse)
        {
            CommonData.skalecoef -= 0.005f;
            if (CommonData.skalecoef <= 0.25f)
            {
                CommonData.reversforpulse = false;
            }
        }
        {
            CommonData.rotatecoef += 5;
            CommonData.rotatecoef_2 += 5;
        }
    }
    void default_position()
    {
        for (int i = CommonData.Height - 1; i >= 0; i--)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                CommonData.PoolCubes[i, k].transform.eulerAngles = new Vector3(-90, 0, 0);
            }
        }
        bool IsOk = false;
        for (int i = CommonData.Height - 1; i >= 0; i--)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                if (CommonData.CommonArr[i, k] > 0)
                {
                    IsOk = true;
                }
                else
                {
                    IsOk = false;
                    break;
                }
            }
            if (IsOk)
            {
                for (int k = 0; k < CommonData.Lenght; k++)
                {
                    //CommonData.PoolCubes[i, k].transform.eulerAngles = new Vector3(-205, 90, -90);
                    CommonData.PoolCubes[i, k].GetComponent<SpriteRenderer>().color = Color.gray;

                }
            }
        }

        CommonData.rotatecoef = 0;
        CommonData.rotatecoef_2 = 0;
    }
    IEnumerator anim_fall_lines()
    {
        int CountLines = 0;
        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                if (CommonData.CommonArr[i, k] > 0)
                {
                    Anim_Full = true;
                }
                else
                {
                    Anim_Full = false;
                    break;

                }
            }
            if (!Anim_Full)
            {
                for (int k = 0; k < CommonData.Lenght; k++)
                {
                    CommonData.PoolCubes[i, k].transform.SetParent(Parent_lines.transform);
                }

            }
            if (Anim_Full)
            {
                CountLines++;
                yield return new WaitForSeconds(0.25f);
                Sound_Line_Complite();
                for (int k = 0; k < CommonData.Lenght; k++)
                {
                    CommonData.PoolCubes[i, k].transform.position = new Vector3(CountLines - 1, 0, k);
                }


                Parent_lines.transform.position += new Vector3(1, 0.01f, 0);
            }
        }
        Parent_lines.transform.DetachChildren();
        Parent_lines.transform.position = new Vector3(0, 0, 0);
        CommonData.compressactive = true;
    }
    void Sound_Rotation()
    {
        Audio_Rotation.Play();
    }
    void Sound_Line_Complite()
    {
        Audio_Line_Complite.Play();
    }
    public void CompressLine()
    {
        Line_table = 0;
        Score_table = 0;

        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {

                if (CommonData.CommonArr[i, k] > 0)
                {
                    IsOk = true;
                }
                else
                {
                    IsOk = false;
                    break;
                }
            }
            if (IsOk)
            {
                for (int k = 0; k < CommonData.Lenght; k++)
                {
                    for (int p = i; p > 0; p--)
                    {
                        CommonData.CommonArr[p, k] = CommonData.CommonArr[p - 1, k];
                    }
                }
            }
            if (IsOk)
            {

                Line_table += 1;
                CommonData.Line += 1;
            }
        }
        CountScore();
    }
    void CountScore()
    {
        CommonData.Logo_Tetris.SetActive(false);
        switch (Line_table)
        {
            case 1:
                Score_table += 100;

                break;

            case 2:
                Score_table += 300;

                break;

            case 3:
                Score_table += 700;
                break;

            case 4:
                Score_table += 1500;
                CommonData.timeforLogoTetris = 0;
                CommonData.Tetris_Logo_bool = true;
                CommonData.Logo_Tetris.SetActive(true);
                break;

        }
        CommonData.Score += Score_table;

    }

}
public class Cell
{
    public int X;
    public int Y;
    public Cell(int x, int y, int fc)
    {
        X = x;
        Y = y;
        CommonData.CommonArr[X, Y] = fc;
    }


}
public abstract class StateBlockTetris
{
    public Cell[] cells;
    public abstract void Left();
    public abstract void Right();
    public abstract void DownOneStep(BlockController bc);
    public abstract void DownAuto(BlockController bc);
    public abstract void Rotate(BlockController bc);
}
public class BlockController
{
    public BlockController(StateBlockTetris sbt)
    {
        stateBlockTetris = sbt;
    }
    public StateBlockTetris stateBlockTetris;

    public void Left()
    {
        stateBlockTetris.Left();
    }
    public void Right()
    {
        stateBlockTetris.Right();
    }
    public void DownOneStep()
    {
        stateBlockTetris.DownOneStep(this);
    }
    public void DownAuto()
    {
        stateBlockTetris.DownAuto(this);
    }
    public void Rotate()
    {
        stateBlockTetris.Rotate(this);
    }

    public void GameOverPrint()
    {
        CommonData.Logo_GameOver.SetActive(true);
    }

}
public class NextElement
{
    public StateBlockTetris GeneretedSBT(int RandNum)
    {
        StateBlockTetris stateBlockTetris = null;
        if (RandNum == 1)
        {
            Cell c_0_rand_1 = new Cell(0, 1, 1);
            Cell c_1_rand_1 = new Cell(0, 2, 1);
            Cell c_2_rand_1 = new Cell(0, 3, 1);
            Cell c_3_rand_1 = new Cell(0, 4, 1);
            stateBlockTetris = new Horizontal(c_0_rand_1, c_1_rand_1, c_2_rand_1, c_3_rand_1);
        }
        if (RandNum == 2)
        {
            if (
                CommonData.CommonArr[0, 2] > 0 &&
                CommonData.CommonArr[1, 2] > 0 &&
                CommonData.CommonArr[2, 2] > 0 &&
                CommonData.CommonArr[3, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_2 = new Cell(0, 2, 1);
            Cell c_1_rand_2 = new Cell(1, 2, 1);
            Cell c_2_rand_2 = new Cell(2, 2, 1);
            Cell c_3_rand_2 = new Cell(3, 2, 1);
            stateBlockTetris = new Vertical(c_0_rand_2, c_1_rand_2, c_2_rand_2, c_3_rand_2);

        }
        if (RandNum == 3)
        {
            if (
    CommonData.CommonArr[2, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_3 = new Cell(2, 2, 2);
            Cell c_1_rand_3 = new Cell(1, 2, 2);
            Cell c_2_rand_3 = new Cell(0, 2, 2);
            Cell c_3_rand_3 = new Cell(0, 3, 2);
            stateBlockTetris = new Element_two_State__1(c_0_rand_3, c_1_rand_3, c_2_rand_3, c_3_rand_3);
        }
        if (RandNum == 4)
        {
            if (
    CommonData.CommonArr[0, 1] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 3] > 0 &&
    CommonData.CommonArr[1, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_4 = new Cell(0, 1, 2);
            Cell c_1_rand_4 = new Cell(0, 2, 2);
            Cell c_2_rand_4 = new Cell(0, 3, 2);
            Cell c_3_rand_4 = new Cell(1, 3, 2);
            stateBlockTetris = new Element_two_State__2(c_0_rand_4, c_1_rand_4, c_2_rand_4, c_3_rand_4);
        }
        if (RandNum == 5)
        {
            if (
    CommonData.CommonArr[0, 3] > 0 &&
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[2, 3] > 0 &&
    CommonData.CommonArr[2, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_5 = new Cell(0, 3, 2);
            Cell c_1_rand_5 = new Cell(1, 3, 2);
            Cell c_2_rand_5 = new Cell(2, 3, 2);
            Cell c_3_rand_5 = new Cell(2, 2, 2);
            stateBlockTetris = new Element_two_State__3(c_0_rand_5, c_1_rand_5, c_2_rand_5, c_3_rand_5);
        }
        if (RandNum == 6)
        {
            if (
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[0, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_6 = new Cell(1, 3, 2);
            Cell c_1_rand_6 = new Cell(1, 2, 2);
            Cell c_2_rand_6 = new Cell(1, 1, 2);
            Cell c_3_rand_6 = new Cell(0, 1, 2);
            stateBlockTetris = new Element_two_State__4(c_0_rand_6, c_1_rand_6, c_2_rand_6, c_3_rand_6);
        }
        if (RandNum == 7)
        {
            if (
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[0, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_7 = new Cell(1, 1, 3);
            Cell c_1_rand_7 = new Cell(1, 2, 3);
            Cell c_2_rand_7 = new Cell(1, 3, 3);
            Cell c_3_rand_7 = new Cell(0, 2, 3);
            stateBlockTetris = new Element_three_State__1(c_0_rand_7, c_1_rand_7, c_2_rand_7, c_3_rand_7);
        }
        if (RandNum == 8)
        {
            if (
    CommonData.CommonArr[0, 1] > 0 &&
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[2, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_8 = new Cell(0, 1, 3);
            Cell c_1_rand_8 = new Cell(1, 1, 3);
            Cell c_2_rand_8 = new Cell(2, 1, 3);
            Cell c_3_rand_8 = new Cell(1, 2, 3);
            stateBlockTetris = new Element_three_State__2(c_0_rand_8, c_1_rand_8, c_2_rand_8, c_3_rand_8);
        }
        if (RandNum == 9)
        {
            if (
    CommonData.CommonArr[0, 3] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_9 = new Cell(0, 3, 3);
            Cell c_1_rand_9 = new Cell(0, 2, 3);
            Cell c_2_rand_9 = new Cell(0, 1, 3);
            Cell c_3_rand_9 = new Cell(1, 2, 3);
            stateBlockTetris = new Element_three_State__3(c_0_rand_9, c_1_rand_9, c_2_rand_9, c_3_rand_9);
        }
        if (RandNum == 10)
        {
            if (
    CommonData.CommonArr[2, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[1, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_10 = new Cell(2, 2, 3);
            Cell c_1_rand_10 = new Cell(1, 2, 3);
            Cell c_2_rand_10 = new Cell(0, 2, 3);
            Cell c_3_rand_10 = new Cell(1, 1, 3);
            stateBlockTetris = new Element_three_State__4(c_0_rand_10, c_1_rand_10, c_2_rand_10, c_3_rand_10);
        }
        if (RandNum == 11)
        {
            if (
    CommonData.CommonArr[2, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_11 = new Cell(2, 2, 4);
            Cell c_1_rand_11 = new Cell(1, 2, 4);
            Cell c_2_rand_11 = new Cell(0, 2, 4);
            Cell c_3_rand_11 = new Cell(0, 1, 4);
            stateBlockTetris = new Element_four_State__1(c_0_rand_11, c_1_rand_11, c_2_rand_11, c_3_rand_11);
        }
        if (RandNum == 12)
        {
            if (
    CommonData.CommonArr[0, 3] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 1] > 0 &&
    CommonData.CommonArr[1, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_12 = new Cell(0, 3, 4);
            Cell c_1_rand_12 = new Cell(0, 2, 4);
            Cell c_2_rand_12 = new Cell(0, 1, 4);
            Cell c_3_rand_12 = new Cell(1, 1, 4);
            stateBlockTetris = new Element_four_State__2(c_0_rand_12, c_1_rand_12, c_2_rand_12, c_3_rand_12);
        }
        if (RandNum == 13)
        {
            if (
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[2, 2] > 0 &&
    CommonData.CommonArr[2, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_13 = new Cell(0, 2, 4);
            Cell c_1_rand_13 = new Cell(1, 2, 4);
            Cell c_2_rand_13 = new Cell(2, 2, 4);
            Cell c_3_rand_13 = new Cell(2, 3, 4);
            stateBlockTetris = new Element_four_State__3(c_0_rand_13, c_1_rand_13, c_2_rand_13, c_3_rand_13);
        }
        if (RandNum == 14)
        {
            if (
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[0, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_14 = new Cell(1, 1, 4);
            Cell c_1_rand_14 = new Cell(1, 2, 4);
            Cell c_2_rand_14 = new Cell(1, 3, 4);
            Cell c_3_rand_14 = new Cell(0, 3, 4);
            stateBlockTetris = new Element_four_State__4(c_0_rand_14, c_1_rand_14, c_2_rand_14, c_3_rand_14);
        }
        if (RandNum == 15)
        {
            if (
    CommonData.CommonArr[0, 1] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_15 = new Cell(0, 1, 1);
            Cell c_1_rand_15 = new Cell(0, 2, 1);
            Cell c_2_rand_15 = new Cell(1, 1, 1);
            Cell c_3_rand_15 = new Cell(1, 2, 1);
            stateBlockTetris = new Element_five(c_0_rand_15, c_1_rand_15, c_2_rand_15, c_3_rand_15);
        }
        if (RandNum == 16)
        {
            if (
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_16 = new Cell(1, 3, 5);
            Cell c_1_rand_16 = new Cell(1, 2, 5);
            Cell c_2_rand_16 = new Cell(0, 2, 5);
            Cell c_3_rand_16 = new Cell(0, 1, 5);
            stateBlockTetris = new Element_six_State_1(c_0_rand_16, c_1_rand_16, c_2_rand_16, c_3_rand_16);
        }
        if (RandNum == 17)
        {
            if (
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[2, 1] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_17 = new Cell(0, 2, 5);
            Cell c_1_rand_17 = new Cell(1, 2, 5);
            Cell c_2_rand_17 = new Cell(1, 1, 5);
            Cell c_3_rand_17 = new Cell(2, 1, 5);
            stateBlockTetris = new Element_six_State_2(c_0_rand_17, c_1_rand_17, c_2_rand_17, c_3_rand_17);
        }
        if (RandNum == 18)
        {
            if (
    CommonData.CommonArr[1, 1] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[0, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_18 = new Cell(1, 1, 6);
            Cell c_1_rand_18 = new Cell(1, 2, 6);
            Cell c_2_rand_18 = new Cell(0, 2, 6);
            Cell c_3_rand_18 = new Cell(0, 3, 6);
            stateBlockTetris = new Element_seven_State_1(c_0_rand_18, c_1_rand_18, c_2_rand_18, c_3_rand_18);
        }
        if (RandNum == 19)
        {
            if (
    CommonData.CommonArr[0, 2] > 0 &&
    CommonData.CommonArr[1, 2] > 0 &&
    CommonData.CommonArr[1, 3] > 0 &&
    CommonData.CommonArr[2, 3] > 0)
            {
                CommonData.Logo_GameOver.SetActive(true);
                CommonData.Play = false;
            }
            Cell c_0_rand_19 = new Cell(0, 2, 6);
            Cell c_1_rand_19 = new Cell(1, 2, 6);
            Cell c_2_rand_19 = new Cell(1, 3, 6);
            Cell c_3_rand_19 = new Cell(2, 3, 6);
            stateBlockTetris = new Element_seven_State_2(c_0_rand_19, c_1_rand_19, c_2_rand_19, c_3_rand_19);
        }
        return stateBlockTetris;
    }
}




