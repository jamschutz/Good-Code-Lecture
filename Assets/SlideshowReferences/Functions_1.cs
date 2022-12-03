using UnityEngine;

public class Functions_1 
{
    public string input;
    private void Start()
    {
        string r = "";
        for(int i = input.Length - 1; i >= 0; i--) {
            r += input[i];
        }

        char[] rArray = r.ToCharArray();
        for(int i = 0; i < rArray.Length; i += 3) {
            rArray[i] = char.ToUpper(rArray[i]);
        }
        r = new string(rArray);

        int n = 0;
        foreach(char c in r) {
            if(char.IsLower(c)) n++;
        }

        Debug.Log($"{r}; {n}");
    }
}
