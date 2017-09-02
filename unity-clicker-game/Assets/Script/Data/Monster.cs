using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Monster
{
	public int ID = 0;
	
	public string Type = "";
    
	public string Name = "";

	public string Prefab = "Monster/Slime";

	public int Damage = 1;

	public int Defense = 1;

	public int Health = 1;

	public int Exp = 1;
}
