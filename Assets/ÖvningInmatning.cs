using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÖvningInmatning : MonoBehaviour
{

    public int userValue;
    public int Dice1;
    public int Dice2;
    public int StartValue;
    public int AfterValue;
    public int Dragon;
    public int DragonLife;
    public int Player;
    public int PlayerLife;
    public int PlayerDamage;
    public int DragonHitChance;
    public int DragonDamage;
    public int DragonMiss;
    public int DragonBossChance;
    public int DragonBossPlusHP;
    public int PlayerMinDamage;
    public int PlayerMaxDamage;
    public int PlayerCrit;
    public int PlayerCritChance;
    public int GuessStartValue;
    public int GuessValue;
    public int GuessNextValue;
    public int GuessWinStreak;
    public int GuessLastValue;

    // Use this for initialization
    void Start()
    {

        StartValue = 10;
        AfterValue = StartValue;
        DragonLife = Random.Range(100, 150);
        DragonBossPlusHP = DragonLife;
        PlayerLife = 100;
        DragonBossChance = Random.Range(1, 11);
        if (DragonBossChance == 10)
        {
            DragonLife = DragonLife + DragonBossPlusHP;
        }
        PlayerMinDamage = Random.Range(1, 15);
        PlayerMaxDamage = Random.Range(20, 30);
        PlayerCrit = DragonLife;
        GuessValue = 50;
        GuessLastValue = GuessValue;
        GuessNextValue = GuessValue;
        GuessWinStreak = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GuessNextValue = Random.Range(1, 101);
            if (GuessValue <= GuessNextValue)
            {
                GuessWinStreak += 1;
                print(GuessNextValue + "   Win Streak " + GuessWinStreak);


            }
            else
            {
                print(GuessNextValue + " Wrong Answer");
                GuessWinStreak = 0;
            }
        }
            GuessValue = GuessNextValue;

                if (Input.GetKeyDown(KeyCode.H))
            {
                GuessNextValue = Random.Range(1, 101);
                if (GuessValue >= GuessNextValue)
                {
                    GuessWinStreak += 1;
                    print(GuessNextValue + "   Win Streak " + GuessWinStreak);


                }
                else
                {
                    print(GuessNextValue + " Wrong Answer");
                    GuessWinStreak = 0;
                }

                GuessValue = GuessNextValue;
            }



            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (DragonLife >= 0 && PlayerLife >= 0)
                {
                    PlayerCritChance = Random.Range(1, 21);

                    if (PlayerCritChance == 20)
                    {
                        DragonLife = DragonLife - PlayerCrit;
                        print("Critical Strike! Dragon Life " + DragonLife);
                    }
                    else
                        DragonHitChance = Random.Range(1, 3);

                    if (DragonHitChance == 2)
                    {
                        DragonDamage = Random.Range(10, 21);
                    }
                    if (DragonHitChance == 1)
                    {
                        DragonDamage = 0;
                        print("Dragon Missed!");
                    }
                    PlayerDamage = Random.Range(5, 26);

                    DragonLife = DragonLife - PlayerDamage;
                    PlayerLife = PlayerLife - DragonDamage;
                    print("Player Life " + PlayerLife);
                    print("Dragon Life " + DragonLife);

                    if (DragonLife <= 0 && PlayerLife >= 1)
                    {
                        print("Player Wins");
                    }
                    if (PlayerLife <= 0 && DragonLife >= 1)
                    {
                        print("Dragon Wins");

                    }
                    else print("Game Over");
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    userValue = (userValue + 2);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    userValue = (userValue / 2);
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    print(userValue);
                }


                if (Input.GetKeyDown(KeyCode.R))
                {
                    Dice1 = Random.Range(1, 6);
                    Dice2 = Random.Range(1, 6);
                    AfterValue = AfterValue + (Dice1 - Dice2);

                    print(AfterValue);

                    if (AfterValue >= 20)
                    {
                        print(AfterValue + " You Win");
                    }
                    if (AfterValue <= 0)
                    {
                        print(AfterValue + " You Lose");
                    }
                }
            }
        
    }
}
