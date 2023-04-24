using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant dude1;
    private Inhabitant dude2;
    private GameObject dude1GO;
    private GameObject dude2GO;

    public DeathMatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1GO, GameObject dude2GO)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1GO = dude1GO;
        this.dude2GO = dude2GO;
    }

    public IEnumerator fight()
    {
        Inhabitant attacker = dude1;
        Inhabitant defender = dude2;
        GameObject attackerGo = dude1GO;
        GameObject defenderGo = dude2GO;


        while(dude1.getHp() > 0 && dude2.getHp() > 0)
        {
            if(attacker == dude1)
            {
                attacker = dude2;
                defender = dude1;
                attackerGo = dude2GO;
                defenderGo = dude1GO;
            }
            else
            {
                attacker = dude1;
                defender = dude2;
                attackerGo = dude1GO;
                defenderGo = dude2GO;
            }

            int roll = Random.Range(1, 21);
            if(roll >= defender.getArmor())
            {
                int damage = attacker.getDamage();
                defender.reduceHp(damage);
                Debug.Log(attacker.getName() + " hit " + defender.getName() + " for " + damage + " damage.");
            }
            else
            {
                Debug.Log(attacker.getName() + " missed " + defender.getName() + ".");
            }
            

            yield return new WaitForSeconds(1);
        }

        if (dude1.getHp() > 0)
        {
            Debug.Log(dude1.getName() + " wins!");
        }
        else
        {
            Debug.Log(dude2.getName() + " wins!");
        }
        
    }

    public bool attack(Inhabitant attacker, Inhabitant target)
    {
        int roll = Random.Range(1, 21);
        bool hit = roll >= target.getArmor();
        if (hit)
        {
            int damage = attacker.getDamage();
            target.reduceHp(damage);
        }
        return hit;
    }
}

