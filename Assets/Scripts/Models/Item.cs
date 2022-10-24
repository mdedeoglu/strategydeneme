using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace FactorySample
{
    public abstract class Item
    {
        public abstract string Name { get; }
        public abstract string SpriteName { get; }
        public abstract int DimensionX { get; }
        public abstract int DimensionY { get; }
        public abstract void Build();

    }

    public abstract class BuildingItem : Item
    {
        //public abstract void Build();
    }

    public class BarrackItem : BuildingItem
    {
        public override string Name => "Barrack";

        public override string SpriteName => "Barrack";

        public override int DimensionX => 4;

        public override int DimensionY => 4;

        public override void Build()
        {
            string prefabPath = @"Prefabs\";
            GameObject go = Resources.Load(prefabPath + "Barrack") as GameObject;
            GameObject temp = MonoBehaviour.Instantiate(go);//.GetComponent<Building>();            
            temp.GetComponent<Building>().buildingName = Name;
            temp.GetComponent<Building>().spriteName = SpriteName;
            temp.GetComponent<Building>().dimensionX = DimensionX;
            temp.GetComponent<Building>().dimensionY = DimensionY;
            //GameObject.FindObjectOfType<GridBuildingSystem>().InitializeWithBuilding(go);
            GameObject.FindObjectOfType<GridBuildingSystem>().InitializeWithBuilding2(temp);

        }
    }

    /*
    public class BarrackBuilding : BarrackItem
    {
        public override string Name => "Barrack";

        public override string SpriteName => "Barrack";

        public override int DimensionX => 4;

        public override int DimensionY => 4;

        public override void Build()
        {
            string prefabPath = @"Prefabs\";
            GameObject go = Resources.Load(prefabPath + "Barrack") as GameObject;
            GameObject.FindObjectOfType<GridBuildingSystem>().InitializeWithBuilding(go);

        }
    }

    */


    public class PowerPlantItem : BuildingItem
    {
        public override string Name => "PowerPlant";

        public override string SpriteName => "PowerPlant";

        public override int DimensionX => 2;

        public override int DimensionY => 3;

        public override void Build()
        {
            string prefabPath = @"Prefabs\";
            GameObject go = Resources.Load(prefabPath + "PowerPlant") as GameObject;
            GameObject.FindObjectOfType<GridBuildingSystem>().InitializeWithBuilding(go);
        }
    }
    public abstract class SoldierItem : BarrackItem
    {
        //public abstract void Build();
    }

    public class Soldier1Item : SoldierItem
    {
        public override string Name => "Soldier1";

        public override string SpriteName => "Soldier1";

        public override int DimensionX => 1;

        public override int DimensionY => 1;

        public override void Build()
        {

        }
    }

    public class Soldier2Item : SoldierItem
    {
        public override string Name => "Soldier2";

        public override string SpriteName => "Soldier2";

        public override int DimensionX => 1;

        public override int DimensionY => 1;

        public override void Build()
        {

        }
    }


    public class Soldier3Item : SoldierItem
    {
        public override string Name => "Soldier3";

        public override string SpriteName => "Soldier3";

        public override int DimensionX => 1;

        public override int DimensionY => 1;

        public override void Build()
        {

        }
    }
    
    public static class BarrackFactory
    {
        public static Dictionary<string, Type> itemsByName;
        private static bool IsInitialized => itemsByName != null;


        public static void InitializeFactory()
        {
            if (IsInitialized)
                return;
            //var itemTypes = Assembly.GetAssembly(typeof(BuildingItem)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BuildingItem)));
            var itemTypes = Assembly.GetAssembly(typeof(SoldierItem)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BarrackItem)));
            itemsByName = new Dictionary<string, Type>();

            foreach (var type in itemTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Item;
                itemsByName.Add(tempEffect.Name, type);
            }
        }
        public static Item GetItem(string itemType)
        {
            InitializeFactory();
            if (itemsByName.ContainsKey(itemType))
            {
                Type type = itemsByName[itemType];
                var item = Activator.CreateInstance(type) as Item;
                return item;
            }
            return null;
        }
        internal static IEnumerable<string> GetItemNames()
        {
            InitializeFactory();
            return itemsByName.Keys;
        }
    }
    
    public static class ItemFactory
    {
        public static Dictionary<string, Type> itemsByName;
        private static bool IsInitialized => itemsByName != null;


        public static void InitializeFactory()
        {
            if (IsInitialized)
                return;
            //var itemTypes = Assembly.GetAssembly(typeof(BuildingItem)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BuildingItem)));
            var itemTypes = Assembly.GetAssembly(typeof(BuildingItem)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BuildingItem)) && !myType.IsSubclassOf(typeof(SoldierItem)));
            itemsByName = new Dictionary<string, Type>();

            foreach (var type in itemTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Item;
                itemsByName.Add(tempEffect.Name, type);
            }
        }
        public static Item GetItem(string itemType)
        {
            InitializeFactory();
            if (itemsByName.ContainsKey(itemType))
            {
                Type type = itemsByName[itemType];
                var item = Activator.CreateInstance(type) as Item;
                return item;
            }
            return null;
        }               
        internal static IEnumerable<string> GetItemNames()
        {
            InitializeFactory();
            return itemsByName.Keys;
        }  
    }
}