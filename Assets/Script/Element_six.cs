﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Element_six_State_1 : StateBlockTetris
{
    public Element_six_State_1(Cell c_0, Cell c_1, Cell c_2, Cell c_3)
    {
        cells = new Cell[4];
        cells[0] = c_0;
        cells[1] = c_1;
        cells[2] = c_2;
        cells[3] = c_3;
        Casper();
    }
    public override void Left()
    {
        if (cells[3].Y - 1 >= 0
            && CommonData.CommonArr[cells[3].X, cells[3].Y - 1] <= 0
            && CommonData.CommonArr[cells[1].X, cells[1].Y - 1] <= 0)
        {
            for (int i = cells.Length - 1; i >= 0; i--)
            {
                CommonData.CommonArr[cells[i].X, cells[i].Y - 1] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].Y -= 1;
            }
            Casper();
        }
    }
    public override void Right()
    {
        if (cells[0].Y + 1 < CommonData.Lenght
             && CommonData.CommonArr[cells[2].X, cells[2].Y + 1] <= 0
             && CommonData.CommonArr[cells[0].X, cells[0].Y + 1] <= 0)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                CommonData.CommonArr[cells[i].X, cells[i].Y + 1] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].Y += 1;
            }
            Casper();
        }
    }
    public override void DownAuto(BlockController bc)
    {
        CommonData.ResetCasper();
        if (cells[0].X == CommonData.Height - 1
            || CommonData.CommonArr[cells[0].X + 1, cells[0].Y] > 0
            || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] > 0
            || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] > 0)

        {
            if (cells[3].X == 0)
            {
                CommonData.Play = false;
                bc.GameOverPrint();
            }
            if (CommonData.Play)
            {
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
        if (cells[0].X < CommonData.Height - 1
            && CommonData.CommonArr[cells[0].X + 1, cells[0].Y] <= 0
            && CommonData.CommonArr[cells[3].X + 1, cells[3].Y] <= 0
            && CommonData.CommonArr[cells[1].X + 1, cells[1].Y] <= 0)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                CommonData.CommonArr[cells[i].X + 1, cells[i].Y] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].X += 1;
            }
            if (CommonData.Play)
            {
                Casper();
            }
            if (cells[0].X == CommonData.Height - 1
                 || CommonData.CommonArr[cells[0].X + 1, cells[0].Y] > 0
                 || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] > 0
                 || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] > 0)
            {
                bc.EnableLineAndCompress();
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
    }
    public override void DownOneStep(BlockController bc)
    {
        CommonData.ResetCasper();
        if (cells[0].X == CommonData.Height - 1
            || CommonData.CommonArr[cells[0].X + 1, cells[0].Y] != 0
            || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] != 0
            || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] != 0)

        {
            if (cells[3].X == 0)
            {
                CommonData.Play = false;
                bc.GameOverPrint();
            }
            if (CommonData.Play)
            {
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
        {
            int Count = 0;
            for (int m = 1; m < CommonData.Height; m++)
            {
                if (cells[0].X + m < CommonData.Height
                    && CommonData.CommonArr[cells[0].X + m, cells[0].Y] == 0
                    && CommonData.CommonArr[cells[3].X + m, cells[3].Y] == 0
                    && CommonData.CommonArr[cells[1].X + m, cells[1].Y] == 0)
                {
                    Count++;
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < cells.Length; i++)
            {
                CommonData.CommonArr[cells[i].X + Count, cells[i].Y] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].X += 1;
            }
            bc.EnableLineAndCompress();
            NextElement nextElement = new NextElement();
            bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
        }
    }
    public override void Rotate(BlockController bc)
    {
        if (CommonData.CommonArr[cells[3].X + 1, cells[3].Y] == 0
            && CommonData.CommonArr[cells[3].X + 2, cells[3].Y] == 0
            && CommonData.CommonArr[cells[0].X - 1, cells[0].Y] == 0)
        {
            CommonData.CommonArr[cells[3].X + 2, cells[3].Y] = CommonData.CommonArr[cells[3].X, cells[3].Y];
            CommonData.CommonArr[cells[3].X, cells[3].Y] = 0;

            CommonData.CommonArr[cells[2].X + 1, cells[2].Y - 1] = CommonData.CommonArr[cells[2].X, cells[2].Y];
            CommonData.CommonArr[cells[2].X, cells[2].Y] = 0;

            CommonData.CommonArr[cells[0].X - 1, cells[0].Y - 1] = CommonData.CommonArr[cells[0].X, cells[0].Y];
            CommonData.CommonArr[cells[0].X, cells[0].Y] = 0;

            cells[0].X -= 1;
            cells[0].Y -= 1;
            cells[2].X += 1;
            cells[2].Y -= 1;
            cells[3].X += 2;
            {
                Cell c_0 = new Cell(cells[0].X, cells[0].Y, 5);
                Cell c_1 = new Cell(cells[1].X, cells[1].Y, 5);
                Cell c_2 = new Cell(cells[2].X, cells[2].Y, 5);
                Cell c_3 = new Cell(cells[3].X, cells[3].Y, 5);
                Element_six_State_2 element_six_State_2 = new Element_six_State_2(c_0, c_1, c_2, c_3);
                bc.stateBlockTetris = element_six_State_2;
            }
        }

    }
    void Casper()
    {
        CommonData.ResetCasper();
        int Count = 0;
        int CountElement = 0;//
        for (int m = 1; m < CommonData.Height; m++)
        {
            if (cells[0].X + m < CommonData.Height
                && CommonData.CommonArr[cells[0].X + m, cells[0].Y] == 0
                && CommonData.CommonArr[cells[3].X + m, cells[3].Y] == 0
                && CommonData.CommonArr[cells[1].X + m, cells[1].Y] == 0)
            {
                Count++;
                CountElement++;
                if (CountElement >= 3)
                {
                    CountElement = 3;//
                }
            }
            else
            {
                break;
            }
        }
        switch (CountElement)
        {
            case 1:
                CommonData.CommonArr[cells[0].X + Count, cells[0].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;

                break;
            case 2:
                CommonData.CommonArr[cells[0].X + Count, cells[0].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;
                CommonData.CommonArr[cells[2].X + Count, cells[2].Y] = -1;
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;

                break;
            case 3:
                CommonData.CommonArr[cells[0].X + Count, cells[0].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;
                CommonData.CommonArr[cells[2].X + Count, cells[2].Y] = -1;
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;
                break;

        }
    }
}
class Element_six_State_2 : StateBlockTetris
{
    public Element_six_State_2(Cell c_0, Cell c_1, Cell c_2, Cell c_3)
    {
        cells = new Cell[4];
        cells[0] = c_0;
        cells[1] = c_1;
        cells[2] = c_2;
        cells[3] = c_3;
        Casper();
    }
    public override void Left()
    {
        if (cells[3].Y - 1 >= 0
            && CommonData.CommonArr[cells[3].X, cells[3].Y - 1] <= 0
            && CommonData.CommonArr[cells[2].X, cells[2].Y - 1] <= 0
            && CommonData.CommonArr[cells[0].X, cells[0].Y - 1] <= 0)
        {
            for (int i = cells.Length - 1; i >= 0; i--)
            {
                CommonData.CommonArr[cells[i].X, cells[i].Y - 1] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].Y -= 1;
            }
            Casper();
        }
    }
    public override void Right()
    {
        if (cells[0].Y + 1 < CommonData.Lenght
             && CommonData.CommonArr[cells[3].X, cells[3].Y + 1] <= 0
             && CommonData.CommonArr[cells[1].X, cells[1].Y + 1] <= 0
             && CommonData.CommonArr[cells[0].X, cells[0].Y + 1] <= 0)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                CommonData.CommonArr[cells[i].X, cells[i].Y + 1] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].Y += 1;
            }
            Casper();
        }
    }
    public override void DownAuto(BlockController bc)
    {
        CommonData.ResetCasper();
        if (cells[3].X == CommonData.Height - 1
            || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] > 0
            || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] > 0)
        {
            if (cells[0].X == 0)
            {
                CommonData.Play = false;
                bc.GameOverPrint();
            }
            if (CommonData.Play)
            {
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
        if (cells[3].X < CommonData.Height - 1
            && CommonData.CommonArr[cells[1].X + 1, cells[1].Y] <= 0
            && CommonData.CommonArr[cells[3].X + 1, cells[3].Y] <= 0)
        {
            for (int i = cells.Length - 1; i >= 0; i--)
            {
                CommonData.CommonArr[cells[i].X + 1, cells[i].Y] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].X += 1;
            }
            if (CommonData.Play)
            {
                Casper();
            }
            if (cells[3].X == CommonData.Height - 1
                 || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] > 0
                 || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] > 0)
            {
                bc.EnableLineAndCompress();
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
    }
    public override void DownOneStep(BlockController bc)
    {
        CommonData.ResetCasper();
        if (cells[3].X == CommonData.Height - 1
            || CommonData.CommonArr[cells[1].X + 1, cells[1].Y] != 0
            || CommonData.CommonArr[cells[3].X + 1, cells[3].Y] != 0)
        {
            if (cells[0].X == 0)
            {
                CommonData.Play = false;
                bc.GameOverPrint();
            }
            if (CommonData.Play)
            {
                NextElement nextElement = new NextElement();
                bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
            }
        }
        {
            int Count = 0;
            for (int m = 1; m < CommonData.Height; m++)
            {
                if (cells[3].X + m < CommonData.Height
                    && CommonData.CommonArr[cells[3].X + m, cells[3].Y] == 0
                    && CommonData.CommonArr[cells[1].X + m, cells[1].Y] == 0)
                {
                    Count++;
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < cells.Length; i++)
            {
                CommonData.CommonArr[cells[i].X + Count, cells[i].Y] = CommonData.CommonArr[cells[i].X, cells[i].Y];
                CommonData.CommonArr[cells[i].X, cells[i].Y] = 0;
                cells[i].X += 1;
            }
            bc.EnableLineAndCompress();
            NextElement nextElement = new NextElement();
            bc.stateBlockTetris = nextElement.GeneretedSBT(CommonData.hint.NumberElement);
        }
    }
    public override void Rotate(BlockController bc)
    {
        if (cells[1].Y == CommonData.Lenght- 1
    && CommonData.CommonArr[cells[3].X, cells[3].Y + 1] == 0
    && CommonData.CommonArr[cells[3].X, cells[3].Y - 1] == 0
    && CommonData.CommonArr[cells[2].X, cells[2].Y - 1] == 0
    && CommonData.CommonArr[cells[0].X, cells[0].Y - 1] == 0
    && CommonData.CommonArr[cells[0].X, cells[0].Y - 2] == 0)
        {
            CommonData.CommonArr[cells[3].X - 2, cells[3].Y - 1] = CommonData.CommonArr[cells[3].X, cells[3].Y];
            CommonData.CommonArr[cells[3].X, cells[3].Y] = 0;

            CommonData.CommonArr[cells[2].X - 1, cells[2].Y] = CommonData.CommonArr[cells[2].X, cells[2].Y];
            CommonData.CommonArr[cells[2].X, cells[2].Y] = 0;

            CommonData.CommonArr[cells[1].X , cells[1].Y -1] = CommonData.CommonArr[cells[2].X, cells[2].Y];
            CommonData.CommonArr[cells[1].X, cells[1].Y] = 0;

            CommonData.CommonArr[cells[0].X + 1, cells[0].Y] = CommonData.CommonArr[cells[0].X, cells[0].Y];
            CommonData.CommonArr[cells[0].X, cells[0].Y] = 0;


            cells[3].X -= 2;
            cells[3].Y -= 1;
            cells[2].X -= 1;
            cells[1].Y -= 1;
            cells[0].X += 1;

            Cell c_0 = new Cell(cells[0].X, cells[0].Y, 5);
            Cell c_1 = new Cell(cells[1].X, cells[1].Y, 5);
            Cell c_2 = new Cell(cells[2].X, cells[2].Y, 5);
            Cell c_3 = new Cell(cells[3].X, cells[3].Y, 5);
            Element_six_State_1 element_six_State_1 = new Element_six_State_1(c_0, c_1, c_2, c_3);
            bc.stateBlockTetris = element_six_State_1;
        }




        if (cells[0].Y < CommonData.Lenght - 1
            && CommonData.CommonArr[cells[0].X, cells[0].Y + 1] == 0
            && CommonData.CommonArr[cells[1].X, cells[1].Y + 1] == 0
            && CommonData.CommonArr[cells[0].X, cells[0].Y - 1] == 0)
        {
            CommonData.CommonArr[cells[0].X + 1, cells[0].Y + 1] = CommonData.CommonArr[cells[0].X, cells[0].Y];
            CommonData.CommonArr[cells[0].X, cells[0].Y] = 0;

            CommonData.CommonArr[cells[2].X - 1, cells[2].Y + 1] = CommonData.CommonArr[cells[2].X, cells[2].Y];
            CommonData.CommonArr[cells[2].X, cells[2].Y] = 0;

            CommonData.CommonArr[cells[3].X - 2, cells[3].Y] = CommonData.CommonArr[cells[3].X, cells[3].Y];
            CommonData.CommonArr[cells[3].X, cells[3].Y] = 0;

            cells[0].X += 1;
            cells[0].Y += 1;
            cells[2].X -= 1;
            cells[2].Y += 1;
            cells[3].X -= 2;

            Cell c_0 = new Cell(cells[0].X, cells[0].Y, 5);
            Cell c_1 = new Cell(cells[1].X, cells[1].Y, 5);
            Cell c_2 = new Cell(cells[2].X, cells[2].Y, 5);
            Cell c_3 = new Cell(cells[3].X, cells[3].Y, 5);
            Element_six_State_1 element_six_State_1 = new Element_six_State_1(c_0, c_1, c_2, c_3);
            bc.stateBlockTetris = element_six_State_1;
        }
    }
    void Casper()
    {
        CommonData.ResetCasper();
        int Count = 0;
        int CountElement = 0;//
        for (int m = 1; m < CommonData.Height; m++)
        {
            if (cells[3].X + m < CommonData.Height
                && CommonData.CommonArr[cells[3].X + m, cells[3].Y] == 0
                && CommonData.CommonArr[cells[1].X + m, cells[1].Y] == 0)
            {
                Count++;
                CountElement++;
                if (CountElement >= 3)
                {
                    CountElement = 3;//
                }
            }
            else
            {
                break;
            }
        }
        switch (CountElement)
        {
            case 1:
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;

                break;
            case 2:
                CommonData.CommonArr[cells[0].X + Count, cells[0].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;
                CommonData.CommonArr[cells[2].X + Count, cells[2].Y] = -1;
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;


                break;
            case 3:
                CommonData.CommonArr[cells[0].X + Count, cells[0].Y] = -1;
                CommonData.CommonArr[cells[1].X + Count, cells[1].Y] = -1;
                CommonData.CommonArr[cells[2].X + Count, cells[2].Y] = -1;
                CommonData.CommonArr[cells[3].X + Count, cells[3].Y] = -1;
                break;

        }
    }
}
