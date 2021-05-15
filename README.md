# DEPRECATED
You don´t need to use this anymore, vosk-api has a nuget package you can already use from c#.

# windows-csharp-vosk-api
A hacky way of using python based vosk-api from windows using c#

# Python versions:
- Python: 3.8.6
- vosk: 0.3.7

# How to use it?

- Install Openal: http://www.openal.org/downloads/
- Enable access to microphone
- Install Vosk python: https://alphacephei.com/vosk/install
- Ensure Vosk is working running some of the example they provide
- Review the configuration files located in the Console App project
- Open the solution in Visual Studio 2019 and compile it (The console app is set to use net5, in case you don´t have it installed) 

# What about if I want to change the model?

The model is currently part of the source code:
- https://github.com/alvaromongon/windows-csharp-vosk-api/tree/main/Processor/VoskModel

And it gets copied over to the output directory when you build the project.

The script that runs Vosk python is also part of the source code:
- https://github.com/alvaromongon/windows-csharp-vosk-api/tree/main/Processor/pythonScripts

And it get copied over as well to the output directory.
The script tries to find the Vosk model in the folder "VoskModel" under the execution path.

As far as the python script is able to locate the model, it can be anywhere and be whatever vosk compatible model you want.

I am using "vosk-model-small-es-0.3" Spanish model.

# How does it work?

Well, I would prefer if you take a look at the code and investigate yourself. 

But in case you are too lazy for that. It is basically running a python script from C# and taking the output of the script. The script gets a wav file that is created on the fly.

It is very hacky, I know.
