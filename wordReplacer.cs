using System;
using System.IO;
using System.Windows;

class wordReplacer {
  
  //this function does the actual swapping of words
  private static string wordSwap(string line, string wordToBeReplaced, string replacedWord, int level) {
    string editedWordToBeReplaced = wordToBeReplaced + " ";
    string editedReplacedWord = replacedWord + " ";
    string editedLine;

    //if its severity/level 2 then it converts all the letter to upper case and changes all instants of the word
    if(level == 2) {
      line = line.ToUpper();
      editedWordToBeReplaced = wordToBeReplaced.ToUpper();
      editedReplacedWord = replacedWord.ToUpper();
    }
    editedLine = line.Replace(editedWordToBeReplaced,editedReplacedWord);

    return editedLine;
  }


  static void Main(string[] args) {
    string textFileName = "";
    string line = "";
    string edited = "";
    StreamReader textFile = null;
    StreamWriter textFileEdited = null;
    string fileExtensionChecker = "";
    string directoryOfFile = Directory.GetCurrentDirectory();
    //should be the second arg and the word to be replaced
    string wordToBeReplaced = "";
    //should be the 3rd arg and the word that will replace the first word
    string replacedWord = "";
    int fileExtensionStart = 0;
    int level = 1;
    bool validLevel = true;

    //this is for checking OS version which would be used later on if I make this into a WPF
    //var os = Environment.OSVersion;
    //Console.WriteLine(os.Platform);

    //if not enough arguments are given then it alerts the user
    if(args.Length != 4 || args == null) {
      Console.WriteLine("usage: wordReplacer.exe [textFileName.txt] [word to be replaced] [word to be used] [severity (1 or 2)]");
    } else {
      //gets all the data from the args
      textFileName = args[0];
      wordToBeReplaced = args[1];
      replacedWord = args[2];
      //if the number is invalid then it alerts the user
      try {
        level = Int32.Parse(args[3]);
      } catch (FormatException) {
          validLevel = false;
      }

      if(textFileName.Length >= 5 &&  validLevel && (level == 1 || level == 2)) {
        fileExtensionStart = textFileName.Length - 4;
        fileExtensionChecker = textFileName.Substring(fileExtensionStart);
        //checks if its actually a txt file
        if(fileExtensionChecker.Equals(".txt")) {
          //if so then it opens it up via StreamReader and opens up a text file to write into
          //it then goes through each line and uses the word swap function
          //close both text files when finished
          try{
            textFile = new StreamReader(@directoryOfFile + "/" + textFileName);
            textFileEdited = new StreamWriter(@directoryOfFile + "/" + "edited_" + textFileName);
            while((line = textFile.ReadLine()) != null) {
              edited = wordSwap(line,wordToBeReplaced,replacedWord,level);
              textFileEdited.WriteLine(edited);
            }
          }catch(Exception e) {
            Console.WriteLine("Exception: " + e.Message);
          } finally {
            Console.WriteLine("done");
            textFile.Close();
            textFileEdited.Close();
          }
        }
      } else {
        Console.WriteLine("invalid input");
      }
    }
  }
}
