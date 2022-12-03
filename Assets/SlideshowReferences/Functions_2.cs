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
    for(int i = 0; i < s.Length; i += 3) {
        s[i] = s[i].ToUpper();
    }
}


private int GetNumLowercaseLetters(string s)
{
    int numLowercaseLetters = 0;
    foreach(char c in reversed) {
        if(c.IsLower()) numLowercaseLetters++;
    }

    return numLowercaseLetters;
}



