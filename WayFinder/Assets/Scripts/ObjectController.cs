using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public GameObject player;
    public GameObject crystal1, crystal2, crystal3, crystal4;
    public GameObject Walls, Wall;
    public GameObject candle;
    //this is a ghost object to reduce the strain on preexisting objects so I am not attaching that many things to the telepad

	public void Default()//resets the entire level because it needs something annoying
    {
        player.GetComponent<DefaultInfo>().Default();
        crystal1.GetComponent<CrystalTrigger>().Default();
        crystal2.GetComponent<CrystalTrigger>().Default();
        crystal3.GetComponent<CrystalTrigger>().Default();
        crystal4.GetComponent<CrystalTrigger>().Default();
        Walls.GetComponent<WallsVanish>().Default();
        Wall.GetComponent<WallVanish>().Default();
        candle.GetComponent<Candle>().Default();
    }
}
