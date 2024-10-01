using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats {
	public enum StatType {
        //Most of the stats are from https://leagueoflegends.fandom.com/wiki/Champion_statistic#Defensive

        //----------------Defensive-------------------
        Health,
		HealthRegeneration,
		HealAndShieldPwr,
		Armor,
		MagicResistance,
		Tenacity,
		SlowResistance,
		//----------------Offensive-------------------
		AttackSpeed, //AttackSpeed is still not calculated correctly, but isn't all that important, since abilities are more in focus
		AttackDamage,
		AbilityPower,
		CriticalStrikeChance,
		CriticalStrikeDmg,
		ArmorPenetration,
		MagicPenetration,
		LifeSteal,
		PhysicalVamp,
		OmniVamp,
		SpellVamp,
		//----------------Utility--------------------
		AbilityHaste,
		UltimateHaste,
		BasicAbiltyHaste,
		CooldownReduction,
		AttackRange,
		MovementSpeed,
		MovementSpeedPercentage,
		GoldGeneration,
		//resources
		Mana,
		ManaRegeneration,
		Energy,
		EnergyRegeneration,
	}
}
