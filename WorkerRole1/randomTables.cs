using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRole1
{
    public class RandomTables
    {
        private static Random r = new Random();
        private static RandomTree<String> WeaponsTable = new RandomTree<string>();
        private static RandomTree<String> ArmourTable = new RandomTree<string>();
        private static RandomTree<String> MedicineTable = new RandomTree<string>();
        private static RandomTree<FlagString> FuckeryTable = new RandomTree<FlagString>();

        public static uint ALLOW_ALL_MODES = 0xFFFF_FFFF;
        public static uint SIMON_MODE = 0x0000_0002;
        public static uint BONUS_CHALLENGE = 0xF000_0001;
        public static uint ALL_ONLY = 0x0000_0001;

        public uint FlagRule { get; set; }

        public RandomTables()
        {
            FlagRule = ALLOW_ALL_MODES;
            setWeapons();
            setArmour();
            setMedicine();
            setFuckery();

        }

        private static void setWeapons()
        {
            WeaponsTable.Add("Assault Rifles Only", 10, ALLOW_ALL_MODES);
            WeaponsTable.Add("Shotguns Only", 5, BONUS_CHALLENGE);
            WeaponsTable.Add("Pistols Only", 5, BONUS_CHALLENGE);
            WeaponsTable.Add("Crossbow Only", 5, BONUS_CHALLENGE);
            WeaponsTable.Add("Snipers Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("SMG Only", 10, ALLOW_ALL_MODES);

            WeaponsTable.Add("R1895 / R45 Revolver Only", 5, BONUS_CHALLENGE);
            WeaponsTable.Add("Melee Only", 2, BONUS_CHALLENGE);
            WeaponsTable.Add("Win94 / Shotgun only(if no Win94)", 5, BONUS_CHALLENGE);

            WeaponsTable.Add(".45 Weapons Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("9mm Weapons Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("7.62 Weapons Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("5.56 Weapons Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("Russian Weapons Only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("American Weapons Only", 5, ALLOW_ALL_MODES);

            WeaponsTable.Add("Any Weapon", 5, SIMON_MODE);
            WeaponsTable.Add("Only can use the first weapon you see", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("Only can use the first two weapons you see", 15, ALLOW_ALL_MODES);
            WeaponsTable.Add("CQB: Shotguns, SMGs and Pistols only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("CQB: Shotguns, SMGs and Pistols only", 5, ALLOW_ALL_MODES);
            WeaponsTable.Add("Marksmen: Rifles and Snipers only", 5, ALLOW_ALL_MODES);
        }

        public string getWeaponRule()
        {
            return WeaponsTable.GetRandom(FlagRule);
        }

        private static void setArmour()
        {
            ArmourTable.Add("Any vest or helmet", 30, ALLOW_ALL_MODES);
            ArmourTable.Add("Level 1 helmet only(no vest)", 10, BONUS_CHALLENGE);
            ArmourTable.Add("Level 1 vest only(no helmet)", 10, BONUS_CHALLENGE);
            ArmourTable.Add("Level 2 helmet only(no vest)", 10, BONUS_CHALLENGE);
            ArmourTable.Add("Level 2 vest only(no helmet)", 10, BONUS_CHALLENGE);
            ArmourTable.Add("Level 3 helmet only(no vest)", 2, BONUS_CHALLENGE);
            ArmourTable.Add("Level 3 vest only(no helmet)", 2, BONUS_CHALLENGE);
            ArmourTable.Add("Max level 1 vest and helmet", 25, BONUS_CHALLENGE);
            ArmourTable.Add("Max level 2 vest and helmet", 15, BONUS_CHALLENGE);
            ArmourTable.Add("No vest or helmet", 20, BONUS_CHALLENGE);
        }

        public string getArmourRule()
        {
            return ArmourTable.GetRandom(FlagRule);
        }

        private void setMedicine()
        {
            MedicineTable.Add("Any medical supplies", 30, ALLOW_ALL_MODES);
            MedicineTable.Add("Bandages & Energy Drinks only", 20, ALLOW_ALL_MODES);
            MedicineTable.Add("Bandages & Stimulants only", 10, ALLOW_ALL_MODES);
            MedicineTable.Add("Bandages only", 20, ALLOW_ALL_MODES);
            MedicineTable.Add("Energy Drinks only", 20, ALLOW_ALL_MODES);
            MedicineTable.Add("First Aid Kits & Stimulants only", 30, ALLOW_ALL_MODES);
            MedicineTable.Add("First Aid Kits only", 10, ALLOW_ALL_MODES);
            MedicineTable.Add("Med Kits & Stimulants only", 10, ALLOW_ALL_MODES);
            MedicineTable.Add("Med Kits only", 5, ALLOW_ALL_MODES);
            MedicineTable.Add("No medical supplies", 10, ALLOW_ALL_MODES);
            MedicineTable.Add("Painkillers only", 5, ALLOW_ALL_MODES);
            MedicineTable.Add("Stimulants (Painkiller & Energy Drinks) only", 20, ALLOW_ALL_MODES);
        }
        public string getMedicineRules()
        {
            return MedicineTable.GetRandom(FlagRule);
        }
        public string getLocation()
        {
            string[] l = { "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] m = { "I", "J", "K", "M", "N", "O", "P", "Q" };
            return "{ " + l[r.Next(l.Length)] + ":" + m[r.Next(m.Length)] + " }";
        }

        private void setFuckery()
        {
            FuckeryTable.Add(new FlagString("Lucky Duck: No special rules", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Choose Wisely: You can only loot one house (can loot bodies)", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Respect the Dead: No looting bodies", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Red or Dead: You can only loot red houses/structures", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Grounded: You can only loot the bottom story/floor of any building/house/structure", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Fuckboy: You can only loot fuckboy shacks", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Vehicular Manslaughter: If you are in a vehicle you must attempt run over any player you see", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Stay Low: You can only move around when crouched, prone or in a vehicle", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Dead Eye: You are not allowed to put any scopes on your weapons", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Bare Bones: You are not allowed to put any accessories on your weapons", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Pick Your Shots: You cannot carry more than one mag for each weapon at a time", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Weak Back: You cannot carry more than three items in your backpack", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Minimalism: You cannot use a backpack", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Cop Mode: you cannot shoot at someone until they start shooting at you", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Bird Watcher: You must go to every airdrop you see falling", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Lazy Looter: You cannot loot airdrops", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("You must go to the center of the circle as fast as you can every time the circle shrinks", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Slim Pickings: You can only loot airdrops, get a vehicle and find that drop", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("World War II: Kar98k, Double Barrel (S686), Pump Action (S1897), P1911, & Revolver (R1895), Win94 and DP-28 only. No attachments besides chokes and bullet loops and no sights besides 8X and higher. Bandages and First Aid Kits only.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Gephyrophobia: You are deathly afraid of bridges, you must swim or use boats every time you encounter a bridge", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Heads Up: You must fire at least 3 warning shots close to the enemy before hitting them", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Viking Funeral: If you have a Molotov you must throw it on an enemies body after killing them in order to send them to Valhalla", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("No Cowards: If you are standing and you are shot at you cannot lay down or crouch until the enemy is dead or you have gone far away from them", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Afraid of heights: you can't go above the first story of any building.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Max Payne Mode: Black trench coat, no backpack, level 1 vest only, Micro UZI and 9mm pistol only, and pain killers", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Spread Out: If in a group, all party members must pick separate locations to drop and then meet up", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Carpooling Sucks: If in a group, everyone must drive their own vehicle", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Big Target: You must try to find a red shirt and wear it", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("xxXMontageXxx: If you have a scoped weapon, you must do a 360 before you can shoot.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Road Warrior: Have to stay on roads, can be dirt, gravel, asphalt or tarmac(runway. You can loot buildings but must leave them as soon as you are done looting.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Roadrage: Only vehicle kills, no guns or grenades", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Punch-squad: Drop where the most people drop and try to get as many punch kills as possible before the first circle", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Guardian Angel: Follow the first player/squad you find and protect them from other without letting them know that you are there, you may not harm them. If they die they you commit suicide.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Paraglider: Jump in the middle of the plane path and pull your chute straight away. Glide to the furthest point away from the path.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Blitz: Jump as soon as possible and dive straight down. Find a gun and then hunt other players as fast as possible. No non-gun loot before the first circle.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("COD Master: No-scoping only.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Realism: Only one primary.Lean around every corner", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Lucky-campers: Pick a grid square (or the one the Strat Roulette generated) and do not leave it. Kill anyone who comes inside and pray for the circle to be kind.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("SEAL: Find a boat ASAP, no looting before finding it, then only travel in the boat and when you want to loot then you must keep your boat within viewing distance of the buildings you loot.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Squad roll out: Everyone in the squad takes a different vehicle.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Silence is Golden: No speaking to teammates only can communicate through in game movements", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Hitman: Silenced pistol only, any pistol attachment. No armor/helmet", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Farmer: Jump from plane with the AFK'ers", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("The Huntsman: Crossbow, shotguns, kar98k, revolver, m24, machete, sickle, win94 only. -/u/Anti_itch_cream", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Crossdresser: You must switch clothes with every person you kill. -/u/Anti_itch_cream", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("It's Quiet, too Quiet: Mute all game sounds.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Quiet as a Mouse: Crouch-control walk slowly through each compound you reach. -CrimsonVixen", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Low Profile: While moving outdoors on foot you can only crawl.(Once stationary any stance is allowed. Vehicles allowed.) -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Medieval: Your only weapons are Crossbow, grenades, and all melee weapons. -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Medic: If in a squad you must have a designated medic who can only carry medical supplies, they are not allowed to harm others. -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("VIP: If in a squad you must have a designated VIP who can only carry a pistol. If he dies, the squad must commit suiside in shame", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Designated Marksman: You take pride in your accuracy at long range, therefore you will not take any shots at targets closer than 300m because those are too easy. (Once the circle becomes to small disregard this rule) -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Vape Nation: You must throw a smoke grenade every time you see an enemy. -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Grenadier: Your only weapons are grenades and melee. -WaddlestheDuck", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("LEYROY JENKINS: You must always run into the red zone if close. No hiding/camping/staying in buildings except to loot. -Laximus", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Biker gang: Everyone in your squad must get their own bike and you have to find fingerless gloves and a level 1 helmet. -Itsmethemcb", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Duck and Cover: Any time you are shot at you must sprint to the nearest cover and lay down to fight.", FlagString.ALL), 5, ALLOW_ALL_MODES);
            FuckeryTable.Add(new FlagString("Sharing is Caring: You must take turns getting kills on other players. If at any time you have more then 2 kills then the lowest kill player, that player must kill you to regain his kill status", FlagString.ALL), 5, ALLOW_ALL_MODES);
        }
        public string getFuckeryRules()
        {
            return FuckeryTable.GetRandom(FlagRule).String;
        }
    }
}
