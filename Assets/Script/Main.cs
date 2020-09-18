using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// при створенні елемента провірка ма місце бо нова деталь стае на місце
//Cube prefab

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
                CommonData.CommonArr[3, 2] > 0
                )
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
            Cell c_0_rand_3 = new Cell(2, 2, 2);
            Cell c_1_rand_3 = new Cell(1, 2, 2);
            Cell c_2_rand_3 = new Cell(0, 2, 2);
            Cell c_3_rand_3 = new Cell(0, 3, 2);
            stateBlockTetris = new Element_two_State__1(c_0_rand_3, c_1_rand_3, c_2_rand_3, c_3_rand_3);
        }
        if (RandNum == 4)
        {
            Cell c_0_rand_4 = new Cell(0, 1, 2);
            Cell c_1_rand_4 = new Cell(0, 2, 2);
            Cell c_2_rand_4 = new Cell(0, 3, 2);
            Cell c_3_rand_4 = new Cell(1, 3, 2);
            stateBlockTetris = new Element_two_State__2(c_0_rand_4, c_1_rand_4, c_2_rand_4, c_3_rand_4);
        }
        if (RandNum == 5)
        {
            Cell c_0_rand_5 = new Cell(0, 3, 2);
            Cell c_1_rand_5 = new Cell(1, 3, 2);
            Cell c_2_rand_5 = new Cell(2, 3, 2);
            Cell c_3_rand_5 = new Cell(2, 2, 2);
            stateBlockTetris = new Element_two_State__3(c_0_rand_5, c_1_rand_5, c_2_rand_5, c_3_rand_5);
        }
        if (RandNum == 6)
        {
            Cell c_0_rand_6 = new Cell(1, 3, 2);
            Cell c_1_rand_6 = new Cell(1, 2, 2);
            Cell c_2_rand_6 = new Cell(1, 1, 2);
            Cell c_3_rand_6 = new Cell(0, 1, 2);
            stateBlockTetris = new Element_two_State__4(c_0_rand_6, c_1_rand_6, c_2_rand_6, c_3_rand_6);
        }
        if (RandNum == 7)
        {
            Cell c_0_rand_7 = new Cell(1, 1, 3);
            Cell c_1_rand_7 = new Cell(1, 2, 3);
            Cell c_2_rand_7 = new Cell(1, 3, 3);
            Cell c_3_rand_7 = new Cell(0, 2, 3);
            stateBlockTetris = new Element_three_State__1(c_0_rand_7, c_1_rand_7, c_2_rand_7, c_3_rand_7);
        }
        if (RandNum == 8)
        {
            Cell c_0_rand_8 = new Cell(0, 1, 3);
            Cell c_1_rand_8 = new Cell(1, 1, 3);
            Cell c_2_rand_8 = new Cell(2, 1, 3);
            Cell c_3_rand_8 = new Cell(1, 2, 3);
            stateBlockTetris = new Element_three_State__2(c_0_rand_8, c_1_rand_8, c_2_rand_8, c_3_rand_8);
        }
        if (RandNum == 9)
        {
            Cell c_0_rand_9 = new Cell(0, 3, 3);
            Cell c_1_rand_9 = new Cell(0, 2, 3);
            Cell c_2_rand_9 = new Cell(0, 1, 3);
            Cell c_3_rand_9 = new Cell(1, 2, 3);
            stateBlockTetris = new Element_three_State__3(c_0_rand_9, c_1_rand_9, c_2_rand_9, c_3_rand_9);
        }
        if (RandNum == 10)
        {
            Cell c_0_rand_10 = new Cell(2, 2, 3);
            Cell c_1_rand_10 = new Cell(1, 2, 3);
            Cell c_2_rand_10 = new Cell(0, 2, 3);
            Cell c_3_rand_10 = new Cell(1, 1, 3);
            stateBlockTetris = new Element_three_State__4(c_0_rand_10, c_1_rand_10, c_2_rand_10, c_3_rand_10);
        }
        if (RandNum == 11)
        {
            Cell c_0_rand_11 = new Cell(2, 2, 4);
            Cell c_1_rand_11 = new Cell(1, 2, 4);
            Cell c_2_rand_11 = new Cell(0, 2, 4);
            Cell c_3_rand_11 = new Cell(0, 1, 4);
            stateBlockTetris = new Element_four_State__1(c_0_rand_11, c_1_rand_11, c_2_rand_11, c_3_rand_11);
        }
        if (RandNum == 12)
        {
            Cell c_0_rand_12 = new Cell(0, 3, 4);
            Cell c_1_rand_12 = new Cell(0, 2, 4);
            Cell c_2_rand_12 = new Cell(0, 1, 4);
            Cell c_3_rand_12 = new Cell(1, 1, 4);
            stateBlockTetris = new Element_four_State__2(c_0_rand_12, c_1_rand_12, c_2_rand_12, c_3_rand_12);
        }
        if (RandNum == 13)
        {
            Cell c_0_rand_13 = new Cell(0, 2, 4);
            Cell c_1_rand_13 = new Cell(1, 2, 4);
            Cell c_2_rand_13 = new Cell(2, 2, 4);
            Cell c_3_rand_13 = new Cell(2, 3, 4);
            stateBlockTetris = new Element_four_State__3(c_0_rand_13, c_1_rand_13, c_2_rand_13, c_3_rand_13);
        }
        if (RandNum == 14)
        {
            Cell c_0_rand_14 = new Cell(1, 1, 4);
            Cell c_1_rand_14 = new Cell(1, 2, 4);
            Cell c_2_rand_14 = new Cell(1, 3, 4);
            Cell c_3_rand_14 = new Cell(0, 3, 4);
            stateBlockTetris = new Element_four_State__4(c_0_rand_14, c_1_rand_14, c_2_rand_14, c_3_rand_14);
        }
        if (RandNum == 15)
        {
            Cell c_0_rand_15 = new Cell(0, 1, 1);
            Cell c_1_rand_15 = new Cell(0, 2, 1);
            Cell c_2_rand_15 = new Cell(1, 1, 1);
            Cell c_3_rand_15 = new Cell(1, 2, 1);
            stateBlockTetris = new Element_five(c_0_rand_15, c_1_rand_15, c_2_rand_15, c_3_rand_15);
        }
        if (RandNum == 16)
        {
            Cell c_0_rand_16 = new Cell(1, 3, 5);
            Cell c_1_rand_16 = new Cell(1, 2, 5);
            Cell c_2_rand_16 = new Cell(0, 2, 5);
            Cell c_3_rand_16 = new Cell(0, 1, 5);
            stateBlockTetris = new Element_six_State_1(c_0_rand_16, c_1_rand_16, c_2_rand_16, c_3_rand_16);
        }
        if (RandNum == 17)
        {
            Cell c_0_rand_17 = new Cell(0, 2, 5);
            Cell c_1_rand_17 = new Cell(1, 2, 5);
            Cell c_2_rand_17 = new Cell(1, 1, 5);
            Cell c_3_rand_17 = new Cell(2, 1, 5);
            stateBlockTetris = new Element_six_State_2(c_0_rand_17, c_1_rand_17, c_2_rand_17, c_3_rand_17);
        }
        if (RandNum == 18)
        {
            Cell c_0_rand_18 = new Cell(1, 1, 6);
            Cell c_1_rand_18 = new Cell(1, 2, 6);
            Cell c_2_rand_18 = new Cell(0, 2, 6);
            Cell c_3_rand_18 = new Cell(0, 3, 6);
            stateBlockTetris = new Element_seven_State_1(c_0_rand_18, c_1_rand_18, c_2_rand_18, c_3_rand_18);
        }
        if (RandNum == 19)
        {
            Cell c_0_rand_19 = new Cell(0, 2, 6);
            Cell c_1_rand_19 = new Cell(1, 2, 6);
            Cell c_2_rand_19 = new Cell(1, 3, 6);
            Cell c_3_rand_19 = new Cell(2, 3, 6);
            stateBlockTetris = new Element_seven_State_2(c_0_rand_19, c_1_rand_19, c_2_rand_19, c_3_rand_19);
        }
        return stateBlockTetris;
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
    public int Line = 0;
    public int Score = 0;

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
    public void EnableLineAndCompress()
    {
        CommonData.Logo_Tetris.SetActive(false);
        Line = 0;
        Score = 0;
        for (int m = CommonData.Height - 1; m > 0; m--)//?While ??
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
                    for (int k = 0; k < CommonData.Lenght; k++)
                    {
                        CommonData.CommonArr[i, k] = 0;
                        int IndexUpCompress = i;
                        for (int p = IndexUpCompress; p > 0; p--)
                        {
                            CommonData.CommonArr[p, k] = CommonData.CommonArr[p - 1, k];
                        }
                    }
                }
                if (IsOk)
                {
                    Line += 1;
                    CommonData.Line += 1;
                }
            }
        }
        switch (Line)
        {
            case 1:
                Score += 100;

                break;

            case 2:
                Score += 300;

                break;

            case 3:
                Score += 700;
                break;

            case 4:
                Score += 1500;
                CommonData.timeforLogoTetris = 0;
                CommonData.Tetris_Logo_bool = true;
                CommonData.Logo_Tetris.SetActive(true);
                break;

        }
        CommonData.Score += Score;

    }
    public void GameOverPrint()
    {
        CommonData.Logo_GameOver.SetActive(true);
    }
}
public class Main : MonoBehaviour
{
    public GameObject CubePrefab;
    List<GameObject> PoolCubes;
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
    void Start()
    {
        CommonData.Logo_GameOver = Logo_Game_Over;
        CommonData.Logo_GameOver.SetActive(false);
        CommonData.Logo_Tetris = Logo_Tetris;
        CommonData.Logo_Tetris.SetActive(false);
        CommonData.Play = true;
        CommonData.timestep_Go = false;
        CommonData.Tetris_Logo_bool = false;
        CommonData.CommonArr = new int[CommonData.Height, CommonData.Lenght];
        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                CommonData.CommonArr[i, k] = 0;
            }
        }

        PoolCubes = new List<GameObject>();
        for (int i = 0; i < CommonData.Height * CommonData.Lenght; i++)
        {
            PoolCubes.Add(Instantiate(CubePrefab));
        }

        nextElement = new NextElement();
        blockController = new BlockController(nextElement.GeneretedSBT(CommonData.hint.NumberElement));
        ResetPosition();
        TimeLevelCount = 1;
    }
    void Update()
    {
        if (CommonData.timestep >= 0.35f && CommonData.timestep_Go)
        {
            blockController.EnableLineAndCompress();
            Next_Element(blockController);
            ResetPosition();
            CommonData.timestep_Go = false;
        }
        CommonData.timestep += Time.deltaTime;
        CommonData.timeforLogoTetris += Time.deltaTime;
        timeCountForHighSpeed += Time.deltaTime;
        timeCountForAvtoDown += Time.deltaTime;
        if (timeCountForAvtoDown > TimeLevelCount && CommonData.Play)
        {
            blockController.DownAuto();
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
            ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CommonData.Play)
        {
            CommonData.ResetCasper();
            blockController.Rotate();
            ResetPosition();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame(blockController);
            ResetPosition();
        }
        if (Input.GetKeyDown(KeyCode.Escape))//?
        {
            Application.Quit();
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
        int p = 0;
        for (int i = 0; i < CommonData.Height; i++)
        {
            for (int k = 0; k < CommonData.Lenght; k++)
            {
                PoolCubes[p].transform.position = new Vector3(i, 0, k);
                if (CommonData.CommonArr[i, k] == 0)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.white;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.gray;
                }
                if (CommonData.CommonArr[i, k] == 1)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.green;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.green;
                }
                if (CommonData.CommonArr[i, k] == 2)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.blue;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (CommonData.CommonArr[i, k] == 3)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (CommonData.CommonArr[i, k] == 4)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                if (CommonData.CommonArr[i, k] == 5)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.cyan;
                }
                if (CommonData.CommonArr[i, k] == 6)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (CommonData.CommonArr[i, k] == -1)
                {
                    //PoolCubes[p].GetComponent<MeshRenderer>().material.color = Color.red;
                    PoolCubes[p].GetComponent<SpriteRenderer>().color = Color.white;
                }
                p++;
            }
        }
    }
    public void Next_Element(BlockController bc)
    {
        bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
    }
    public void ResetGame(BlockController bc)
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
        bc.Line = 0;
        bc.Score = 0;
        CommonData.Line = 0;
        CommonData.Score = 0;
    }
}




