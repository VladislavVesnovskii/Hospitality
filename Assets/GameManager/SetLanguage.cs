using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLanguage : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<QuestTrigger> triggers = new List<QuestTrigger>();
    string iCannotUseItHere = "I cannot use it here";
    string iCannotUseItHereRU = "Я не могу использовать это здесь";
    string forSomeTypeofPistol = "For some type of pistol";
    string forSomeTypeOfPistolRU = "Для пистолета";
    string bullet = "Bullet";
    string bulletRU = "Патрон";
   
    public void SetGameLanguage()
    {
        if (GameObject.FindGameObjectWithTag("NoReboot").GetComponent<Menu>().language == 0)
        {
            SetEN();
        }
        else
        {
            SetRU();
        }
    }

    private void SetEN()
    {
        items[0].nameItem = "Door key";
        items[0].descriptionItem = "For some doors";
        items[1].nameItem = "Door key";
        items[1].descriptionItem = "For some doors";
        items[2].nameItem = "Bubble gum";
        items[2].descriptionItem = "Chewed bubble gum";
        items[3].nameItem = "Revolver";
        items[3].descriptionItem = "Magnum 44";
        items[4].nameItem = "Oil can";
        items[4].descriptionItem = "There is some liquid inside";
        items[5].nameItem = bullet;
        items[5].descriptionItem = forSomeTypeofPistol;
        items[6].nameItem = bullet;
        items[6].descriptionItem = forSomeTypeofPistol;
        items[7].nameItem = bullet;
        items[7].descriptionItem = forSomeTypeofPistol;
        items[8].nameItem = bullet;
        items[8].descriptionItem = forSomeTypeofPistol;
        items[9].nameItem = bullet;
        items[9].descriptionItem = forSomeTypeofPistol;
        items[10].nameItem = bullet;
        items[10].descriptionItem = forSomeTypeofPistol;
        items[11].nameItem = bullet;
        items[11].descriptionItem = forSomeTypeofPistol;
        items[12].nameItem = bullet;
        items[12].descriptionItem = forSomeTypeofPistol;
        items[13].nameItem = bullet;
        items[13].descriptionItem = forSomeTypeofPistol;
        items[14].nameItem = "Some note";
        items[14].descriptionItem = "Dead man's note";
        items[14].message = "I have something that will make it silent";
        items[15].nameItem = "Some note";
        items[15].descriptionItem = "Dead man's note";
        items[15].message = "They got angry because I had moved the beds";
        items[16].nameItem = "Apple";
        items[16].descriptionItem = "Fresh apple";
        items[17].nameItem = "Flashlight";
        items[17].descriptionItem = "It looks absolutely new";
        items[18].nameItem = "Some key";
        items[18].descriptionItem = "For some kind of lock";
        items[19].nameItem = "File";
        items[19].descriptionItem = "Quite sitable for work";

        triggers[0].sign1 = iCannotUseItHere;
        triggers[0].sign2 = "Alarm device";
        //triggers[0].sign3 = "";
        triggers[1].sign1 = iCannotUseItHere;
        triggers[1].sign2 = "Rust lock";
        //triggers[1].sign3 = "";
        triggers[2].sign1 = iCannotUseItHere;
        triggers[2].sign2 = "The lock is welded";
        //triggers[2].sign3 = "";
        triggers[3].sign1 = iCannotUseItHere;
        triggers[3].sign2 = "The lock is welded";
        //triggers[3].sign3 = "";
        triggers[4].sign1 = iCannotUseItHere;
        triggers[4].sign2 = "Room door";
        //triggers[4].sign3 = "";
        triggers[5].sign1 = iCannotUseItHere;
        triggers[5].sign2 = "Room door";
        //triggers[5].sign3 = "";
        triggers[6].sign1 = iCannotUseItHere;
        triggers[6].sign2 = "Room door";
        //triggers[6].sign3 = "";
        triggers[7].sign1 = "This lock is broken";
        triggers[7].sign2 = "Room door";
        //triggers[7].sign3 = "";
        triggers[8].sign1 = "This lock is broken";
        triggers[8].sign2 = "Second floor door";
        //triggers[8].sign3 = "";
        triggers[9].sign1 = iCannotUseItHere;
        triggers[9].sign2 = "Room door";
        //triggers[9].sign3 = "";
        triggers[10].sign1 = "This lock is broken";
        triggers[10].sign2 = "Room door";
        //triggers[10].sign3 = "";
        triggers[11].sign1 = "I cannot give it away";
        triggers[11].sign2 = "Pretty monkey";
        //triggers[11].sign3 = "";
        triggers[12].sign1 = iCannotUseItHere;
        triggers[12].sign2 = "Safe";
        //triggers[12].sign3 = "";
        triggers[13].sign1 = "Double door";
        triggers[13].sign2 = "Double door";
        //triggers[13].sign3 = "";
        triggers[14].sign1 = iCannotUseItHere;
        triggers[14].sign2 = "Iron chain";
        //triggers[14].sign3 = "";
        


    }
    private void SetRU()
    {
        items[0].nameItem = "Дверной ключ";
        items[0].descriptionItem = "Подходит для некоторых дверей";
        items[1].nameItem = "Дверной ключ";
        items[1].descriptionItem = "Подходит для некоторых дверей";
        items[2].nameItem = "Жевательная резинка";
        items[2].descriptionItem = "Пожеванная жевательная резинка";
        items[3].nameItem = "Револьвер";
        items[3].descriptionItem = "Магнум 44";
        items[4].nameItem = "Масленка";
        items[4].descriptionItem = "Внутри есть жидкость";
        items[5].nameItem = bulletRU;
        items[5].descriptionItem = forSomeTypeOfPistolRU;
        items[6].nameItem = bulletRU;
        items[6].descriptionItem = forSomeTypeOfPistolRU;
        items[7].nameItem = bulletRU;
        items[7].descriptionItem = forSomeTypeOfPistolRU;
        items[8].nameItem = bulletRU;
        items[8].descriptionItem = forSomeTypeOfPistolRU;
        items[9].nameItem = bulletRU;
        items[9].descriptionItem = forSomeTypeOfPistolRU;
        items[10].nameItem = bulletRU;
        items[10].descriptionItem = forSomeTypeOfPistolRU;
        items[11].nameItem = bulletRU;
        items[11].descriptionItem = forSomeTypeOfPistolRU;
        items[12].nameItem = bulletRU;
        items[12].descriptionItem = forSomeTypeOfPistolRU;
        items[13].nameItem = bulletRU;
        items[13].descriptionItem = forSomeTypeOfPistolRU;
        items[14].nameItem = "Записка";
        items[14].descriptionItem = "Записка мертвеца";
        items[14].message = "Я знаю как заставить ее замолчать";
        items[15].nameItem = "Записка";
        items[15].descriptionItem = "Записка мертвеца";
        items[15].message = "Они рассердились, когда я передвинул кровати";
        items[16].nameItem = "Яблоко";
        items[16].descriptionItem = "Свежее яблоко";
        items[17].nameItem = "Фонарик";
        items[17].descriptionItem = "Выглядит абсолютно новым";
        items[18].nameItem = "Ключ";
        items[18].descriptionItem = "Для определенного замка";
        items[19].nameItem = "Напильник";
        items[19].descriptionItem = "Вполне пригодный для работы";

        triggers[0].sign1 = iCannotUseItHereRU;
        triggers[0].sign2 = "Сигнализация";
        //triggers[0].sign3 = "";
        triggers[1].sign1 = iCannotUseItHereRU;
        triggers[1].sign2 = "Ржавый замок";
        //triggers[1].sign3 = "";
        triggers[2].sign1 = iCannotUseItHereRU;
        triggers[2].sign2 = "Замок заварен";
        //triggers[2].sign3 = "";
        triggers[3].sign1 = iCannotUseItHereRU;
        triggers[3].sign2 = "Замок заварен";
        //triggers[3].sign3 = "";
        triggers[4].sign1 = iCannotUseItHereRU;
        triggers[4].sign2 = "Дверь в комнату";
        //triggers[4].sign3 = "";
        triggers[5].sign1 = iCannotUseItHereRU;
        triggers[5].sign2 = "Дверь в комнату";
        //triggers[5].sign3 = "";
        triggers[6].sign1 = iCannotUseItHereRU;
        triggers[6].sign2 = "Дверь в комнату";
        //triggers[6].sign3 = "";
        triggers[7].sign1 = "Этот замок сломан";
        triggers[7].sign2 = "Дверь в комнату";
        //triggers[7].sign3 = "";
        triggers[8].sign1 = "Этот замок сломан";
        triggers[8].sign2 = "Дверь на второй этаж";
        //triggers[8].sign3 = "";
        triggers[9].sign1 = iCannotUseItHereRU;
        triggers[9].sign2 = "Дверь в комнату";
        //triggers[9].sign3 = "";
        triggers[10].sign1 = "Этот замок сломан";
        triggers[10].sign2 = "Дверь в комнату";
        //triggers[10].sign3 = "";
        triggers[11].sign1 = "Я не могу отдать это";
        triggers[11].sign2 = "Милая обезьянка";
        //triggers[11].sign3 = "";
        triggers[12].sign1 = iCannotUseItHereRU;
        triggers[12].sign2 = "Сейф";
        //triggers[12].sign3 = "";
        triggers[13].sign1 = "Двойная дверь";
        triggers[13].sign2 = "Двойная дверь";
       //triggers[13].sign3 = "";
        triggers[14].sign1 = iCannotUseItHereRU;
        triggers[14].sign2 = "Железная цепь";
        //triggers[14].sign3 = "";

    }
}
