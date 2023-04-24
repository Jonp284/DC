using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefereeController : MonoBehaviour
{
    public GameObject monsterGO;
    public GameObject playerGO;
    public TextMeshPro monsterSB;
    public TextMeshPro playerSB;
    private Monster theMonster;
    private DeathMatch theMatch;
    private bool isPlayerTurn = true;
    private bool isMatchOver = false;
    private float pauseTime = 1.0f;

    // Start is called before the first frame update
    void Start()
{
    this.theMonster = new Monster("goblin");
    this.monsterSB.text = this.theMonster.getData();
    this.playerSB.text = MasterData.p.getData();
    this.theMatch = new DeathMatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO);
    StartCoroutine(playMatch());
}

// Loop to play the match
public IEnumerator playMatch()
{
    while (!isMatchOver)
    {
        // Wait for a short time
        float timeToWait = pauseTime;
        while (timeToWait > 0f)
        {
            timeToWait -= Time.deltaTime;
            yield return null;
        }

        if (isPlayerTurn)
        {
            bool hit = theMatch.attack(MasterData.p, theMonster);
            updateUI(playerGO, MasterData.p, monsterGO, theMonster, hit);
            if (theMonster.getHp() <= 0)
            {
                endMatch(monsterGO);
            }
        }
        else
        {
            bool hit = theMatch.attack(theMonster, MasterData.p);
            updateUI(monsterGO, theMonster, playerGO, MasterData.p, hit);
            if (MasterData.p.getHp() <= 0)
            {
                endMatch(playerGO);
            }
        }

        isPlayerTurn = !isPlayerTurn;
    }
}

private void endMatch(GameObject loserGO)
    {
        isMatchOver = true;
        Debug.Log(loserGO.GetComponent<Inhabitant>().getName() + " has been defeated!");
    }

    private void updateUI(GameObject attackerGO, Inhabitant attacker, GameObject targetGO, Inhabitant target, bool hit)
    {
        string message = "";
        if (hit)
        {
            int damage = attacker.getDamage();
            message = attacker.getName() + " hit " + target.getName() + " for " + damage + " damage!";
            target.getDamage();
        }
        else
        {
            message = attacker.getName() + " missed " + target.getName() + "!";
        }

        attackerGO.GetComponent<TextMeshPro>().text = attacker.getData();
        targetGO.GetComponent<TextMeshPro>().text = target.getData();
        Debug.Log(message);
    }
}
