using UnityEngine;
using System.Collections;

public interface IUseble  {
    //интерфейс применяется к обьектам на сцене, которые можно использовать(кнопка Е)
    void Use(params string[] args);
}
