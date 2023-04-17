using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player
{
    private string name;
    private Room currentRoom;
    private int hp;
    private int armor;
    private int attack;

    public Player(string name)
    {
        this.name = name;
        this.hp = Random.Range(10, 21);
        this.armor = Random.Range(10, 18);
        this.attack = Random.Range(1, 6);
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        if (r != null)
        {
            this.currentRoom = r;
        }
    }

    //getter (accessor) for read only access to the private field name
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
