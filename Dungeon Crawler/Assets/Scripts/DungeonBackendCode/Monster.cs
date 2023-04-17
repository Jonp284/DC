using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private string name;
    private int hp;
    private int armor;
    private int attack;

    public Monster(string name)
    {
        this.name = name;
        this.hp = Random.Range(10, 21);
        this.armor = Random.Range(10, 18);
        this.attack = Random.Range(1, 6);
    }

    public string getName()
    {
        return this.name;
    }

    public int getHp()
    {
        return this.hp;
    }

    public int getArmor()
    {
        return this.armor;
    }

    public int getAttack()
    {
        return this.attack;
    }
}
