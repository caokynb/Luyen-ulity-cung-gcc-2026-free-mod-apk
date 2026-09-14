using UnityEngine;

public class Utility 
{
    public static void swap<T>(ref T a, ref T b)
    {
        T c = a;
        a = b;
        b = c;
    }
    public static void swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
}
