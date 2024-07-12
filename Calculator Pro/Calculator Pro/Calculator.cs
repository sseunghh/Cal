using System;
using System.Collections.Generic;

namespace Calculator_Pro
{
    public class Calculator
    {
        public double Calculate(List<double> numbers, List<char> operators)
        {
            // 연산자 우선순위에 따라 계산 수행
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '×' || operators[i] == '÷' || operators[i] == '%')
                {
                    double tempResult = numbers[i];
                    switch (operators[i])
                    {
                        case '×':
                            tempResult *= numbers[i + 1];
                            break;
                        case '÷':
                            tempResult /= numbers[i + 1];
                            break;
                        case '%':
                            tempResult %= numbers[i + 1];
                            break;
                    }
                    numbers[i] = tempResult;
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--; // 다시 한번 현재 위치에서 계산을 확인
                }
            }

            double result = numbers[0];
            for (int i = 0; i < operators.Count; i++)
            {
                switch (operators[i])
                {
                    case '+':
                        result += numbers[i + 1];
                        break;
                    case '-':
                        result -= numbers[i + 1];
                        break;
                }
            }

            return result;
        }
    }
}