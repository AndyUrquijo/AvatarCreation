using UnityEngine;
using System.Collections;
using System;

public class EnumUtil
{
    static int GetCount<EnumType>()
    {
        return Enum.GetNames(typeof(EnumType)).Length;
    }

    public static EnumType GetNext<EnumType>(EnumType value) where EnumType : IConvertible
    {
        int aux = ToInt(value);
        aux++;
        if (aux >= GetCount<EnumType>())
            aux = 0;
        return ToEnum<EnumType>(aux);
    }

    public static EnumType GetPrev<EnumType>(EnumType value) where EnumType : IConvertible
    {
        int aux = ToInt(value);
        aux--;
        if (aux < 0)
            aux = GetCount<EnumType>() - 1;
        return ToEnum<EnumType>(aux);
    }

    public static EnumType ToEnum<EnumType>(int value)
    {
        return (EnumType)Enum.ToObject(typeof(EnumType), value);
    }

    public static int ToInt<EnumType>(EnumType value)
    {
        return (int)Convert.ChangeType(value, typeof(int));
    }
}

