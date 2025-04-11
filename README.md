# Magic Number 6174 (Kaprekar's Constant) Finder

This C# application demonstrates the mathematical phenomenon known as Kaprekar's constant (6174) by testing all 4-digit numbers from 1000 to 9999.

## About Kaprekar's Constant

Kaprekar's constant (6174) is a special number discovered by Indian mathematician D.R. Kaprekar. For any 4-digit number (with at least two different digits), the following process always converges to 6174 in at most 7 iterations:

1. Arrange the digits in descending order (largest number)
2. Arrange the digits in ascending order (smallest number)
3. Subtract the smaller number from the larger one
4. Repeat the process with the result

Learn more on [Wikipedia](https://en.wikipedia.org/wiki/6174).

## How It Works

The application:
1. Iterates through all numbers from 1000 to 9999
2. For each number, performs the Kaprekar routine:
   - Creates the largest and smallest numbers from the digits
   - Subtracts them
   - Repeats until reaching 6174 or detecting a non-changing result
3. Logs all steps to a `result.txt` file

## Code Structure

- `SOSF.cs`: Main logic class that performs the Kaprekar routine
- `Order.cs`: Enum for sorting direction (ascending/descending)
- `Program.cs`: Entry point that runs the application

## Usage

1. Clone the repository
2. Build and run the application
3. Check `result.txt` for the complete output

The output shows:
- Each tested number
- All subtraction steps
- Final verification when 6174 is reached
- Skipped numbers (those with identical digits)

## Example Output
```
Current number: 1000
1000 - 0001 = 999
9990 - 0999 = 8991
9981 - 1899 = 8082
8820 - 0288 = 8532
8532 - 2358 = 6174
Correct for 1000!
```

## Requirements
- .NET 6.0 or later
