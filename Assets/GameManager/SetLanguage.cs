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
    string iCannotUseItHereRU = "� �� ���� ������������ ��� �����";
    string forSomeTypeofPistol = "For some type of pistol";
    string forSomeTypeOfPistolRU = "��� ���������";
    string bullet = "Bullet";
    string bulletRU = "������";
   
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
        items[0].nameItem = "������� ����";
        items[0].descriptionItem = "�������� ��� ��������� ������";
        items[1].nameItem = "������� ����";
        items[1].descriptionItem = "�������� ��� ��������� ������";
        items[2].nameItem = "����������� �������";
        items[2].descriptionItem = "���������� ����������� �������";
        items[3].nameItem = "���������";
        items[3].descriptionItem = "������ 44";
        items[4].nameItem = "��������";
        items[4].descriptionItem = "������ ���� ��������";
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
        items[14].nameItem = "�������";
        items[14].descriptionItem = "������� ��������";
        items[14].message = "� ���� ��� ��������� �� ���������";
        items[15].nameItem = "�������";
        items[15].descriptionItem = "������� ��������";
        items[15].message = "��� ������������, ����� � ���������� �������";
        items[16].nameItem = "������";
        items[16].descriptionItem = "������ ������";
        items[17].nameItem = "�������";
        items[17].descriptionItem = "�������� ��������� �����";
        items[18].nameItem = "����";
        items[18].descriptionItem = "��� ������������� �����";
        items[19].nameItem = "���������";
        items[19].descriptionItem = "������ ��������� ��� ������";

        triggers[0].sign1 = iCannotUseItHereRU;
        triggers[0].sign2 = "������������";
        //triggers[0].sign3 = "";
        triggers[1].sign1 = iCannotUseItHereRU;
        triggers[1].sign2 = "������ �����";
        //triggers[1].sign3 = "";
        triggers[2].sign1 = iCannotUseItHereRU;
        triggers[2].sign2 = "����� �������";
        //triggers[2].sign3 = "";
        triggers[3].sign1 = iCannotUseItHereRU;
        triggers[3].sign2 = "����� �������";
        //triggers[3].sign3 = "";
        triggers[4].sign1 = iCannotUseItHereRU;
        triggers[4].sign2 = "����� � �������";
        //triggers[4].sign3 = "";
        triggers[5].sign1 = iCannotUseItHereRU;
        triggers[5].sign2 = "����� � �������";
        //triggers[5].sign3 = "";
        triggers[6].sign1 = iCannotUseItHereRU;
        triggers[6].sign2 = "����� � �������";
        //triggers[6].sign3 = "";
        triggers[7].sign1 = "���� ����� ������";
        triggers[7].sign2 = "����� � �������";
        //triggers[7].sign3 = "";
        triggers[8].sign1 = "���� ����� ������";
        triggers[8].sign2 = "����� �� ������ ����";
        //triggers[8].sign3 = "";
        triggers[9].sign1 = iCannotUseItHereRU;
        triggers[9].sign2 = "����� � �������";
        //triggers[9].sign3 = "";
        triggers[10].sign1 = "���� ����� ������";
        triggers[10].sign2 = "����� � �������";
        //triggers[10].sign3 = "";
        triggers[11].sign1 = "� �� ���� ������ ���";
        triggers[11].sign2 = "����� ���������";
        //triggers[11].sign3 = "";
        triggers[12].sign1 = iCannotUseItHereRU;
        triggers[12].sign2 = "����";
        //triggers[12].sign3 = "";
        triggers[13].sign1 = "������� �����";
        triggers[13].sign2 = "������� �����";
       //triggers[13].sign3 = "";
        triggers[14].sign1 = iCannotUseItHereRU;
        triggers[14].sign2 = "�������� ����";
        //triggers[14].sign3 = "";

    }
}
