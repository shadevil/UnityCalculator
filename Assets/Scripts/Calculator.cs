public class Calculator
{
    public float Equal(float first_numb, float second_numb, string param, out int Error)
    {
        if (second_numb != 0)
        {
            Error = 0;
            switch (param)
            {
                case Names.Add:
                    return first_numb + second_numb;
                case Names.Multiply:
                    return first_numb * second_numb;
                case Names.Subtract:
                    return first_numb - second_numb;
                case Names.Divide:
                    return first_numb / second_numb;
                default:
                    return 0;
            }
        }
        else
        {
            Error = 1;
            return 0;
        }
    }
}
