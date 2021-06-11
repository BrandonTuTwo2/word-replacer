# word-replacer
**Creator:** Brandon Tu

**Description:** A C# program that takes in a text file and replaces the user entered word with another word.

**Usage:**
for now it can for sure be run on WSL debian but it will most likely work on all other unix platforms

1) When running on unix mono must be installed
2) type `mcs wordReplacer.cs` to compile the code
3) type `mono wordReplacer.exe` to run
4) options to run are: mono wordReplacer [textFileName.txt] [word to be replaced] [word to be used] [severity]

[textFileName] is the name of the text file you want to use, must be in the same directory of the program

[word to be replaced] is the word in the text file you want to replace

[word to be used] is the word you want to use to replace the word in the text file

[severity] is how hard you want to replace the word.  severity 1 would replace only standalone instances of the word not ignoring caps and severity 2 would replace all instances of the word regardless of capitization and spacing.

ex if you want to replace the word 'to' with 'the' severity 1 would change the sentence "lets go to toronto" -> "lets go the Toronto" while severity 2 would look like "LETS GO THE THERONTHE"



**Additional Note:**  This is my first little project in C# to help me get familiar with it, I will most likely turn this into a WPF later on.


Last update on: 2021 06 11
