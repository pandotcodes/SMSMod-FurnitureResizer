using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FurnitureResizer
{
    public class Resizer<T> where T : Component
    {
        public List<T> Objects { get; set; } = new();
        public ConfigEntry<float> xScale { get; set; }
        public ConfigEntry<float> yScale { get; set; }
        public ConfigEntry<float> zScale { get; set; }
        public Resizer(string name, ConfigFile Config)
        {
            xScale = Config.Bind(name + " Scale", "X Scale", 1f, "The scale factor on the X axis.");
            yScale = Config.Bind(name + " Scale", "Y Scale", 1f, "The scale factor on the Y axis.");
            zScale = Config.Bind(name + " Scale", "Z Scale", 1f, "The scale factor on the Z axis.");

            xScale.SettingChanged += (a, b) => Apply();
            yScale.SettingChanged += (a, b) => Apply();
            zScale.SettingChanged += (a, b) => Apply();
        }
        public void Add(T instance)
        {
            Objects.Add(instance);
            Apply();
        }
        public void Apply()
        {
            foreach (var item in Objects)
            {
                try
                {
                    item.transform.localScale = new Vector3(xScale.Value, yScale.Value, zScale.Value);
                } catch(Exception e)
                {
                    Console.WriteLine("Resizing failed.");
                }
            }
        }
    }
}
