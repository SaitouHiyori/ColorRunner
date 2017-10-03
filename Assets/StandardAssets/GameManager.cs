using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager{

    private static int GameScore;

    private static float GameTimer;

    private static bool GameFlag;

    public static int Score{
        set{
            if (GameFlag)
            {
                GameScore += value;
            }
        }
        get{
            return GameScore;
        }
    }

    public static void Reset_GameScore(){
        GameScore = 0;
    }

    public static float Timer{
        set{
            GameTimer += value;
        }
        get{
            return GameTimer;
        }
    }

    public static void TimerReset(){
        GameTimer = 0;
    }

    public static bool Flag{
        set{
            GameFlag = value;
        }
        get{
            return GameFlag;
        }
    }

    public static void GameStart(){
        GameFlag = true;
    }
    public static void GameEnd(){
        GameFlag = false;
    }
}
