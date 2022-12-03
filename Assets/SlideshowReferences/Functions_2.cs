using UnityEngine;

public class Functions_2
{
    public string input;
    private void Start()
    {
        string r = GetReversedString(input);
        CapitalizeEveryThirdCharacter(ref r);
        int n = GetNumLowercaseLetters(r);

        Debug.Log($"{r}; {n}");
    }


    private string GetReversedString(string s)
    {
        string reversed = "";
        for(int i = input.Length - 1; i >= 0; i--) {
            reversed += s[i];
        }

        return reversed;
    }


    private void CapitalizeEveryThirdCharacter(ref string s)
    {
        char[] charArray = s.ToCharArray();
        for(int i = 0; i < charArray.Length; i += 3) {
            charArray[i] = char.ToUpper(charArray[i]);
        }
        s = new string(charArray);
    }


    private int GetNumLowercaseLetters(string s)
    {
        int n = 0;
        foreach(char c in s) {
            if(char.IsLower(c)) n++;
        }

        return n;
    }
}