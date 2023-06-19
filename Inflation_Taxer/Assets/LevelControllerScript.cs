using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    public int levelCounter = 1;







    public float HowMuchDollarsDeclineAmount()
    {
        switch (levelCounter)
        {

            case 1:
                return 0.10f; // 10 kuru� 1'e kadar 10 pipe
            case 2:
                return 0.5f; //50 kuru� azalacak 2'ye kadar 15 pipe
            case 3:
                return 1; // 1 muz azalacak 9.5'e kadar 20 pipe
            case 4:
                return 3; // 3 muz azalacak 25'e kadar 25 pipe
            case 5:
                return 10; //10 muz azalacak 9'a kadar 110 pipe E�ER OYUNCU BA�ARAMAZSA YAPTI�I KADARIYLA DA OYUNU B�T�REB�L�R...
            default:
                return 0.10f;
        }
    }

    public float HowMuchOneDollar()
    {
        switch (levelCounter)
        {

            case 1:
                return 2; // 10 kuru� 1'e kadar 10 pipe
            case 2:
                return 9.5f; //50 kuru� azalacak 2'ye kadar 15 pipe
            case 3:
                return 29.5f; // 1 muz azalacak 9.5'e kadar 20 pipe
            case 4:
                return 100; // 3 muz azalacak 25'e kadar 25 pipe
            case 5:
                return 999; //10 muz azalacak 9'a kadar 110 pipe E�ER OYUNCU BA�ARAMAZSA YAPTI�I KADARIYLA DA OYUNU B�T�REB�L�R...
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


}