using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asyncs
{
    public delegate void Callback();

    public async static void Delay(Callback callback, float time)
    {
        int delayTime = (int)(time * 1000);
        await Task.Delay(delayTime);
        callback();
    }
}
