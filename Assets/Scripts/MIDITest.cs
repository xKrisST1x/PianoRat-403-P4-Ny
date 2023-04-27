using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MIDITest : MonoBehaviour
{
    float C1; // 48 -
    float Cs1; // 49
    float D1; // 50
    float Ds1; // 51
    float E1; // 52 -
    float F1; // 53
    float Fs1; // 54
    float G1; // 55 -
    float Gs1; // 56
    float A1; // 57 +
    float As1; // 58
    float B1; // 59

    float C2; // 60 +
    float Cs2; // 61
    float D2; // 62
    float Ds2; // 63
    float E2; // 64 +
    float F2; // 65
    float Fs2; // 66
    float G2; // 67
    float Gs2; // 68
    float A2; // 69
    float As2; // 70
    float B2; // 71

    float C3; // 72

    private void OnEnable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
    }

    void OnDisable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
    }

    void NoteOn(MidiChannel channel, int note, float velocity)
    {
        //Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
    }

    void NoteOff(MidiChannel channel, int note)
    {
        //Debug.Log("NoteOff: " + note);
    }

    void Update()
    {
        C1 = MidiMaster.GetKey(48);
        Cs1 = MidiMaster.GetKey(49);
        D1 = MidiMaster.GetKey(50);
        Ds1 = MidiMaster.GetKey(51);
        E1 = MidiMaster.GetKey(52);
        F1 = MidiMaster.GetKey(53);
        Fs1 = MidiMaster.GetKey(54);
        G1 = MidiMaster.GetKey(55);
        Gs1 = MidiMaster.GetKey(56);
        A1 = MidiMaster.GetKey(57);
        As1 = MidiMaster.GetKey(58);
        B1 = MidiMaster.GetKey(59);

        C2 = MidiMaster.GetKey(60);
        Cs2 = MidiMaster.GetKey(61);
        D2 = MidiMaster.GetKey(62);
        Ds2 = MidiMaster.GetKey(63);
        E2 = MidiMaster.GetKey(64);
        F2 = MidiMaster.GetKey(65);
        Fs2 = MidiMaster.GetKey(66);
        G2 = MidiMaster.GetKey(67);
        Gs2 = MidiMaster.GetKey(68);
        A2 = MidiMaster.GetKey(69);
        As2 = MidiMaster.GetKey(70);
        B2 = MidiMaster.GetKey(71);

        C3 = MidiMaster.GetKey(72);


        if (C1 > 0.0f && E1 > 0.0f && G1 > 0.0f)
        {
            Debug.Log("C, Played");
        }

        if (G1 > 0.0f && B1 > 0.0f && D2 > 0.0f)
        {
            Debug.Log("G, Played");
        }

        if (A1 > 0.0f && C2 > 0.0f && E2 > 0.0f)
        {
            Debug.Log("Am, Played");
        }

        if (F1 > 0.0f && A1 > 0.0f && C2 > 0.0f)
        {
            Debug.Log("F, Played");
        }
    }
}
