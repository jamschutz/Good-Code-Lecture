using UnityEngine;

public class Functions_2 : MonoBehaviour
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
        string r = "";
        for(int i = input.Length - 1; i >= 0; i--) {
            r += s[i];
        }

        return r;
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

    public float moveSpeed = 5;
    private void Update()
    {
        // go up
        if(Input.GetKeyDown(KeyCode.W)) {
            transform.Translate(transform.forward * moveSpeed);
        }
        // go left
        if(Input.GetKeyDown(KeyCode.A)) {
            transform.Translate(-transform.right * moveSpeed);
        }
        // go back
        if(Input.GetKeyDown(KeyCode.S)) {
            transform.Translate(-transform.forward * moveSpeed);
        }
        // go right
        if(Input.GetKeyDown(KeyCode.D)) {
            transform.Translate(transform.right * moveSpeed);
        }
    }
}