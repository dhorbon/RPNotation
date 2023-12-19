for(; ; )
{
    Console.Write(
        "Supported operations:\n" +
        " Whole Numbers\n" +
        " + (addition), - (subtraction), * (multiplication), / (whole dicision), ^ (exponentation) operations\n" +
        "Enter a string separating operands with spaces:\n"
        );
    string[] input = Console.ReadLine().Split(' ');

    List<int> stack = new List<int>();
    for(int i = 0; i < input.Length; i++)
    {
        if (input[i] == "+")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] + stack[stack.Count -1];
            stack.RemoveAt(stack.Count - 1);
        }
        else if (input[i] == "-")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] - stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
        }
        else if (input[i] == "*")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] * stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
        }
        else if (input[i] == "/")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] / stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
        }
        else if (input[i] == "^")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] ^ stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
        }
        else
        {
            stack.Add(Convert.ToInt32(input[i]));
        }
    }

    if(stack.Count != 1)
    {
        Console.WriteLine("wrong number of operands");
    }
    else
    {
        Console.WriteLine(stack[0]);
    }
}