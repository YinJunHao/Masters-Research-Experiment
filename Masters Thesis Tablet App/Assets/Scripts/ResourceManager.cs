using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    private static List<string> ResourcesUsed = new List<string>();
    public static void AppendToList(string VariantName)
    {
        ResourcesUsed.Add(VariantName);
    }
    public static List<string> GetResourcesList()
    {
        return ResourcesUsed;
    }
}
