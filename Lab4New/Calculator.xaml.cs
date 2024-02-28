
namespace CalculatorApp;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
        InitializeComponent();

	}

    //Hold the numbers and operands
    string firstNumber = "";
    string secondNumber = "";
    double resultNumber = 0.0;
    //numberOperandChcker is to track the secondNumber. After the operand is clicked, it signals that the next number will be secondNumber and not firstNumber
    bool numberOperandChcker = true;
    string selectedOperand = "";
     
    //Updates the numbers holder according to the buttons clicked
    private void NumberClicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        string numberPressed = button.Text;

        if (numberOperandChcker)
        {
            firstNumber += numberPressed;
            result.Text = firstNumber;
        }
        else
        {
           secondNumber += numberPressed;
            result.Text = secondNumber;
            result.Text = $"{firstNumber}{selectedOperand}{secondNumber}";

        }


    }
    //Changes the sign of the number to positive or negative. Only changes sign when there is a number. Or else this method will not be implemented
    private void AdditionSubraction(object sender, EventArgs e)
    {
        if(result.Text != "0" || result.Text != null)
        {
          
            if (numberOperandChcker && firstNumber != "" && firstNumber != null)
            {
                double ChangeFirstNumberSign = double.Parse(firstNumber);

                ChangeFirstNumberSign *= -1;

                firstNumber = ChangeFirstNumberSign.ToString();
                result.Text = firstNumber;
            }
            else if (secondNumber != "" && secondNumber != null)
            {
                double ChangeSecondNumberSign = double.Parse(secondNumber);
                ChangeSecondNumberSign *= -1;
                secondNumber = ChangeSecondNumberSign.ToString();
                result.Text =  $"{firstNumber}{selectedOperand}{secondNumber}";
            }
        }
        else
        {
            return;
        }
    }

    //Clears all operation on screen, resetting all values to empty/null
    private void AllClear(object sender, EventArgs e)
    {
        firstNumber = "";
        secondNumber = "";
        resultNumber = 0;
        result.Text = "0";
        selectedOperand = "";
        numberOperandChcker = true;

    }

    //Calculates the operation that is shown on screen. Only shows the answer after the equal sign is clicked.

    private void Equal(object sender, EventArgs e)
    {
        //only works if there is a value on both firstNumber and secondNumber or else, it will reset the operation back to default.
        if (firstNumber != "" && secondNumber != "") 
        {
            double val1 = double.Parse(firstNumber);
            double val2 = double.Parse(secondNumber);
            if (selectedOperand == "+")
            {
                resultNumber = val1 + val2;
            }
            else if (selectedOperand == "-")
            {
                resultNumber = val1 - val2;
            }
            else if (selectedOperand == "X")
            {
                resultNumber = val1 * val2;

                //Checks if the value of secondNumber is 0 and its a division operand.
            }else if (val2 != 0 && selectedOperand == "/")
            {
                resultNumber = val1 / val2;
            }
            //returns a message that the operation cannot be divided by zero
            else
            {
                result.Text = "Cannot divide by zero";
                return;

            }
            //Reset values back to default after showing the result
            result.Text = resultNumber.ToString();
            firstNumber = "";
            secondNumber = "";
            resultNumber = 0;
            selectedOperand = "";
            numberOperandChcker = true;

        }
        //if method is clicked when there is still no value for firstNumber or secondNumber, the calculator will reset to default
        else
        {
            result.Text = resultNumber.ToString();
            firstNumber = "";
            secondNumber = "";
            resultNumber = 0;
            selectedOperand = "";
            numberOperandChcker = true;
        }
        


    }

    //The operand of the calculator Addition, subtraction...etc
    private void Operand(object sender, EventArgs e)
    {
        Button button = sender as Button;
        selectedOperand = button.Text;
        numberOperandChcker = false;
        
        //Displays number on screen 
        if (secondNumber != "")
        {
            result.Text = $"{firstNumber}{selectedOperand}{secondNumber}";
        }
        else if (secondNumber == "")
        {
            result.Text = $"{firstNumber}{selectedOperand}";
        }
    }
 
 




}