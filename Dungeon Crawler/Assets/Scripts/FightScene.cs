using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FightScene : MonoBehaviour
{

    public GameObject Monster, Monster1, Player;
    public Text P, M, M1;
    private Player player;
    private Monster monster;
    private Monster monster1;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player("Player");
        monster = new Monster("Monster");
        monster1 = new Monster("Monster1");

        Monster.GetComponent<PlayerController>().setStats(monster.getHp(), monster.getArmor(), monster.getAttack());
        Monster1.GetComponent<PlayerController>().setStats(monster1.getHp(), monster1.getArmor(), monster1.getAttack());
        Player.GetComponent<PlayerController>().setStats(player.getHp(), player.getArmor(), player.getAttack());

        P.text = $"Player\nHP: {player.getHp()}\nArmor: {player.getArmor()}\nAttack: {player.getAttack()}";
        M.text = $"Monster\nHP: {monster.getHp()}\nArmor: {monster.getArmor()}\nAttack: {monster.getAttack()}";
        M1.text = $"Monster1\nHP: {monster1.getHp()}\nArmor: {monster1.getArmor()}\nAttack: {monster1.getAttack()}";
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

}
