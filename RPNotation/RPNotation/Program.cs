for (; ; )
{
    Console.Write(
        "Supported operations:\n" +
        " Whole Numbers\n" +
        " + (addition), - (subtraction), * (multiplication), / (whole dicision), ^ (exponentation) operations\n" +
        "'SWAP' keyword swaps position of two latest numbers\n" +
        "( expression ) brackets\n" +
        "Enter a string separating operands with spaces:\n"
        );
    string[] input = Console.ReadLine().Split(' ');

    Console.Clear();

    int? output = RPN(input);
    
    if (output == null)
    {
        Console.WriteLine("wrong number of operands");
    }else
    {
        Console.WriteLine(output);
    }
}

int? RPN(string[] input)
{
    
    List<int> stack = new List<int>();
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == "+")
        {
            stack[stack.Count - 2] = stack[stack.Count - 2] + stack[stack.Count - 1];
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
        else if (input[i] == "SWAP")
        {
            int temp = stack[stack.Count - 2];
            stack[stack.Count - 2] = stack[stack.Count - 1];
            stack[stack.Count - 1] = temp;
        }
        else if (input[i] == "(")
        {
            List<string> brackets = new();
                
            for (int j = i + 1; j < input.Length; j++)
            {
                if (input[j] == ")")
                {
                i = j;
                    int? number = RPN(brackets.ToArray());
                    if (number != null)
                    {
                        stack.Add((int)number);
                    }
                }
                else
                {
                    brackets.Add(input[j]);
                }
            }                
        }
        else
        {
            stack.Add(Convert.ToInt32(input[i]));
        }
    }

    if (stack.Count != 1)
    {
        return null;
    }
    else
    {
        return stack[0];
    }        
}