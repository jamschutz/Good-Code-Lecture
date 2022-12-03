public string input;
private void Start()
{
    string r = "";
    for(int i = input.Length - 1; i >= 0; i--) {
        r += input[i];
    }

    for(int i = 0; i < r.Length; i += 3) {
        r[i] = r[i].ToUpper();
    }

    int n = 0;
    foreach(char c in r) {
        if(c.IsLower()) n++;
    }

    Debug.Log($"{r}; {n}");
}