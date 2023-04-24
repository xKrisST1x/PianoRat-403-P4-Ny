using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MIDITest : MonoBehaviour
{
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
        Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
    }

    void NoteOff(MidiChannel channel, int note)
    {
        Debug.Log("NoteOff: " + note);
    }

    void Update()
    {
        if(MidiMaster.GetKey(53) > 0.0f && MidiMaster.GetKey(57) > 0.0f && MidiMaster.GetKey(60) > 0.0f)
        {
            Debug.Log("Chord, pressed");
        }

        // Chord: 53, 57 and 60
        //if (MidiMaster.GetKeyDown(MidiChannel.Ch1, 53))
        //{
        //    Debug.Log("53, pressed");
        //}
    }
}
