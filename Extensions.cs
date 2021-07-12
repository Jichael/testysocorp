using UnityEngine;

public static class Extensions
{

    public static void Shuffle<T>(this T[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            T tmp = list[i];
            int rand = Random.Range(0, list.Length);
            list[i] = list[rand];
            list[rand] = tmp;
        }
    }

    public static Color GetColor(this ColorCollision c)
    {
        return c switch
        {
            ColorCollision.Blue => Color.blue,
            ColorCollision.Green => Color.green,
            ColorCollision.Red => Color.red,
            ColorCollision.White => Color.white,
            _ => Color.magenta
        };
    }


}
