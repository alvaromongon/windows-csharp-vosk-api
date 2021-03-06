#!/usr/bin/env python3

# https://softwarerecs.stackexchange.com/questions/74532/speech-recognition-free-software-and-complete-privacy

from vosk import Model, KaldiRecognizer, SetLogLevel
import sys
import os
import wave
import json

SetLogLevel(0)

if not os.path.exists("VoskModel"):
    print ("Please download the model from https://alphacephei.com/vosk/models and unpack as 'model' in the current folder.")
    exit (1)

wf = wave.open(sys.argv[1], "rb")
if wf.getnchannels() != 1 or wf.getsampwidth() != 2 or wf.getcomptype() != "NONE":
    print ("Audio file must be WAV format mono PCM.")
    exit (1)

model = Model("VoskModel")
rec = KaldiRecognizer(model, wf.getframerate())

text = ""
while True:
    data = wf.readframes(4000)
    if len(data) == 0:
        break
    if rec.AcceptWaveform(data):
        jres = json.loads(rec.Result())
        text = text + " " + jres['text']

finalResult = rec.FinalResult()
jres = json.loads(finalResult)
text = text + " " + jres['text']

print(text)
