using System;
using UnityEngine;
public class Hello
{
    private int hp;
    private int attack;
    public Hello(int hp, int attack)
    {
        this.hp = hp;
        this.attack = attack;
    }

    public Hello Hello1 = new Hello(100,20);
    
    public int Tung = 3;

    void Dec(ref int Tung)
    {
        Tung--;
        Debug.Log(Tung);
    }

    void Dec1(out int tug)
    {
        tug = 3;
        Console.WriteLine(tug);
    }

}
