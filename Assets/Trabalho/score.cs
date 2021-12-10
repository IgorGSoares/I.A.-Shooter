using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public int acertos = 0, erros = 0;
    public void Acertou()
    {
        acertos++;
    }

    public void Errou()
    {
        erros++;
    }
}
