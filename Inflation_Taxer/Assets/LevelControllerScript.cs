using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    public static int levelCounter = 1; // Singleton pattern will be using for this variable
    public static int maxLevel = 5; // Final Level



    public float HowMuchDollarsDeclineAmount()
    {
        switch (levelCounter)
        {

            case 1:
                return 0.10f; // 10 kuruþ 1'e kadar 10 pipe
            case 2:
                return 0.5f; //50 kuruþ azalacak 2'ye kadar 15 pipe
            case 3:
                return 1; // 1 muz azalacak 9.5'e kadar 20 pipe
            case 4:
                return 3; // 3 muz azalacak 25'e kadar 25 pipe
            case 5:
                return 10; //10 muz azalacak 9'a kadar 110 pipe EÐER OYUNCU BAÞARAMAZSA YAPTIÐI KADARIYLA DA OYUNU BÝTÝREBÝLÝR...
            default:
                return 0.10f;
        }
    }

    public float HowMuchOneDollar()
    {
        switch (levelCounter)
        {

            case 1:
                return 2; // 10 kuruþ 1'e kadar 10 pipe
            case 2:
                return 9.5f; //50 kuruþ azalacak 2'ye kadar 15 pipe
            case 3:
                return 29.5f; // 1 muz azalacak 9.5'e kadar 20 pipe
            case 4:
                return 100; // 3 muz azalacak 25'e kadar 25 pipe
            case 5:
                return 999; //10 muz azalacak 9'a kadar 110 pipe EÐER OYUNCU BAÞARAMAZSA YAPTIÐI KADARIYLA DA OYUNU BÝTÝREBÝLÝR...
            default:
                return 2;
        }
    }

        public string ChangePlayersSprite()
    {
        string currentName = "emoticon";

        switch (levelCounter)
        {
            case 1:
                return currentName;
            case 2:
                return currentName+"1";
            case 3:
                return currentName + "2";
            case 4:
                return currentName + "3";
            case 5:
                return currentName + "4";
            default:
                return currentName;
        }

    }
    public float GiveMinDollarValueForLevel()
    {
        switch (levelCounter)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 9.5f;
            case 4:
                return 25;
            case 5:
                return 9;
            default:
                return 1;
        }

    }

    public Coordinates GetCoordinateFromLevel()
    {
        switch (levelCounter)
        {
            case 1:
                return new Coordinates(-0.14f, 0.67f, 3.25f);
            case 2:
                return new Coordinates(0.25f, 0.02f, 2.9f);
            case 3:
                return new Coordinates(0.22f, 0.18f, 2.9f);
            case 4:
                return new Coordinates(0.28f, 0.1f, 3.3f);
            case 5:
                return new Coordinates(0.1f, 0.43f, 3.25f);
            default:
                return new Coordinates(-0.14f, 0.67f, 3.25f);
        }

    }


    public class Coordinates
    {
        public float X;
        public float Y;
        public float R; // radius

        public Coordinates(float x, float y, float r)
        {
            X = x;
            Y = y;
            R = r;
        }
    }
}
