﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonData
{
    public static int[,] CommonArr;
    public static int Height = 16;
    public static int Lenght = 10;

    public static int[,] HintArr;
    public static int Height_HintArr = 5;
    public static int Lenght_HintArr = 5;
    public static Hint hint;
    public static bool Play;
    public static void ResetCasper()
    {

        for (int i = 0; i <Height; i++)
        {
            for (int k = 0; k <Lenght; k++)
            {
                if (CommonArr[i, k] == -1)
                {
                    CommonArr[i, k] = 0;
                }
            }
        }

    }
    public static int Line;
    public static int Score;
    public static Main main;
    public static GameObject Logo;
    public static float timestep;
    public static bool timestep_Go;


}