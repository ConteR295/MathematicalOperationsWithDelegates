using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathematicalOperationsWithDelegates.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;

namespace MathematicalOperationsWithDelegates.ViewModels
{
    partial class MathematicalViewModel : ObservableObject
    {
        public double GetDoubleValue(string num)
        {
            if(double.TryParse(num, out double value)) return value;
            else
            {
                return double.NaN; 
            }
        }
        private void CheckResult()
        {
            double.TryParse(Result, out double x);
            if (Equals(x, double.NaN))
            {
                Result = "Ошибка : входные данные невалидны - должны быть ввиде чисел";
            }
        }

        [ObservableProperty]
        public string _result;

        [ObservableProperty]
        public string num1;

        [ObservableProperty]
        public string num2;

        private readonly OperationsWithTwoNumbers operationWithTwoNumbers = new();
        private readonly IsItPrime _IsPrime = new();
        private readonly OperationsWithSingleNumber operationsWithSingleNumber = new();
        private readonly Publisher publisher = new();

        //--Action--
        [RelayCommand]
        public void Multiply()
        {
            operationWithTwoNumbers.Multiply(GetDoubleValue(Num1), GetDoubleValue(Num2), r => Result = r);
            CheckResult();
        }

        [RelayCommand]
        public void Add()
        {
            operationWithTwoNumbers.Add(GetDoubleValue(Num1), GetDoubleValue(Num2), r => Result = r);
            CheckResult();
        }

        [RelayCommand]
        public void Subtract()
        {
            operationWithTwoNumbers.Subtract(GetDoubleValue(Num1), GetDoubleValue(Num2), r => Result = r);
            CheckResult();
        }

        [RelayCommand]
        public void Divide()
        {
            operationWithTwoNumbers.Divide(GetDoubleValue(Num1), GetDoubleValue(Num2), r => Result = r);
            CheckResult();
        }
        //--Action--

        //--Predicate--
        [RelayCommand]
        public void IsPrime()
        {
            //При double.Nan IsPrime возвращает False,а не double.Nan,
            //поэтому сразу проверяю исходное число.
            //В теории можно в других командах тоже проверять сразу два входных числа,
            //но в этом нужды нет,так как критерии по производительности не установлены,а сами
            //операции занимают ничтожно малое количество времени и ресурсов.
            //Проверять результат просто удобнее

            var isNumer = double.TryParse(Num1, out double x);
            if(!isNumer)
            {
                Result = "Ошибка : входные данные невалидны - должны быть ввиде чисел";
            }
            else
            { Result = _IsPrime.IsPrime(GetDoubleValue(Num1)).ToString(); }
        }
        //--Predicate--

        //--Func--
        [RelayCommand]
        public void ToDouble()
        {
            Result = operationsWithSingleNumber.ToDouble(GetDoubleValue(Num1)).ToString();
            CheckResult();
        }

        [RelayCommand]
        public void ToSquare()
        {
            Result = operationsWithSingleNumber.ToSquare(GetDoubleValue(Num1)).ToString();
            CheckResult();
        }
        //--Func--

        //--Event--
        [RelayCommand]
        public void Event()
        {
            publisher.OnNotify += message => Result = message;
            publisher.Trigger("Событие сработало!");
        }
        //--Event--
    }
}
