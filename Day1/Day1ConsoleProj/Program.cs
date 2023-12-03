
using Day1ConsoleProj;

Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("input.txt");
int sum = 0;
string[] digits = {"one", "two", "three", "four", "five", "six", "seven", "eight", "eight"};
foreach(string line in lines) {
    
    int? firstVal = iterateLine(line, true);
    int? lastVal = iterateLine(line, false);
    // char firstInt = line.First(c => Char.IsDigit(c));
    // char lastInt = line.Last(c => Char.IsDigit(c));
    // int calbrationValue = Int32.Parse("" + firstInt + lastInt);
    if(firstVal == null || lastVal == null)
        throw new Exception("Sentence does not contain digit!");
    else 
        sum += Int32.Parse("" + firstVal + "" + lastVal);
}
Console.Write("Sum: " + sum);

int? iterateLine(string line, bool startFromBeginning) {
    int? value = null;
    Digits[] digits = Enum.GetValues<Digits>();
    if(startFromBeginning) 
    {
        for(int i = 0; i < line.Length; i ++) {
            string subLine = line.Substring(i);
            if(!String.IsNullOrEmpty(subLine) && Char.IsDigit(subLine[0])) 
            {
                return Int32.Parse("" + subLine[0]);
            }

            foreach(var digit in digits) {
                if(subLine.StartsWith(digit.ToString())){
                    value = (int) digit;
                    return value;
                }
            }
        }
    }
    else 
    {
        for(int i = line.Length-1; i >= 0; i --) {
            string subLine = line.Substring(i);
            if(!String.IsNullOrEmpty(subLine) && Char.IsDigit(subLine[0])) 
            {
                return Int32.Parse("" + subLine[0]);
            }

            foreach(var digit in digits) {
                if(subLine.StartsWith(digit.ToString())){
                    value = (int) digit;
                    return value;
                }
            }
        }
    }
    return value;
}