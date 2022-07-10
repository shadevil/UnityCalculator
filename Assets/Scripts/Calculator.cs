public static class Calculator
{
    public static float Calculate(float first_numb, float second_numb, string param, out int Error)
    {
        Error = 0;
        if (param == Names.Add)
        {
            return first_numb + second_numb;
        }
        if (param == Names.Subtract)
        {
            return first_numb - second_numb;
        }
        if (param == Names.Multiply)
        {
            return first_numb * second_numb;
        }
        if (param == Names.Divide)
        {
            if (second_numb == 0)
            {
                Error = 1;
                return 0;
            }
            else return first_numb / second_numb;
        }
        return 0;
    }
}

