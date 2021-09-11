using System;
using System.Collections.Generic;

namespace TesteNeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Qual valor deseja sacar?");
            decimal valorSaque = Convert.ToDecimal(Console.ReadLine()); //525

            var listaCedula = new List<Cedula>();
            var cedula = new Cedula();

            while (valorSaque > 1)
            {
                if (valorSaque > 99)
                {
                    cedula = VerificarNota100(valorSaque);

                    listaCedula.Add(cedula);

                    valorSaque = valorSaque % 100;
                }
                else if (valorSaque > 9 && valorSaque < 100)
                {
                    cedula = VerificaNota50(valorSaque);

                    if (cedula != null)
                    {
                        listaCedula.Add(cedula);

                        valorSaque = valorSaque % 50;
                    }

                    if (valorSaque > 0)
                    {
                        cedula = VerificaNota20(valorSaque);

                        if (cedula != null)
                        {
                            listaCedula.Add(cedula);

                            valorSaque = valorSaque % 20;
                        }
                    }

                    if (valorSaque > 0)
                    {
                        cedula = VerificaNota10(valorSaque);

                        listaCedula.Add(cedula);

                        valorSaque = valorSaque % 10;
                    }
                }
                else
                {
                    var quantidadeCedulaMenor = Convert.ToInt32(valorSaque / 5);

                    if (quantidadeCedulaMenor != 0)
                    {
                        cedula = new Cedula
                        {
                            TipoCedula = "Nota 5",
                            Quantidade = valorSaque > 5 ? quantidadeCedulaMenor - 1 : quantidadeCedulaMenor
                        };

                        listaCedula.Add(cedula);

                        valorSaque = valorSaque = valorSaque % 5;
                    }

                    if (valorSaque > 0)
                    {
                        quantidadeCedulaMenor = Convert.ToInt32(valorSaque / 2);
                        cedula = new Cedula
                        {
                            TipoCedula = "Nota 2",
                            Quantidade = quantidadeCedulaMenor
                        };

                        listaCedula.Add(cedula);

                        valorSaque = valorSaque = valorSaque % 2;
                    }
                }
            }

            if (valorSaque == 0)
            {
                foreach (var item in listaCedula)
                {
                    Console.WriteLine($"{item.TipoCedula} quantidade de  {item.Quantidade}");
                }
            }
            else
            {
                Console.WriteLine("Não é possível sacar o valor informado");
            }

        }

        private static Cedula VerificarNota100(decimal valorSaque)
        {
            var quantidadeCedula = Convert.ToInt32(valorSaque / 100);

            var valorString = valorSaque.ToString();

            var numeroVerifador = Convert.ToInt32(valorString.Substring(valorString.Length - 2, 1));

            var cedula = new Cedula
            {
                TipoCedula = "Nota 100",
                Quantidade = numeroVerifador > 5 ? quantidadeCedula - 1 : quantidadeCedula
            };

            return cedula;
        }

        private static Cedula VerificaNota50(decimal valorSaque)
        {
            var quantidadeCedula = Convert.ToInt32(valorSaque / 50);

            var valorString = valorSaque.ToString();

            quantidadeCedula = Convert.ToInt32(valorString.Substring(valorString.Length - 1, 1)) >= 5 ? quantidadeCedula - 1 : quantidadeCedula;

            if (quantidadeCedula > 0)
            {
                return new Cedula
                {
                    TipoCedula = "Nota 50",
                    Quantidade = quantidadeCedula
                };
            }

            return null;
        }

        private static Cedula VerificaNota20(decimal valorSaque)
        {
            var quantidadeCedula = Convert.ToInt32(valorSaque / 20);

            var valorString = valorSaque.ToString();

            quantidadeCedula = Convert.ToInt32(valorString.Substring(valorString.Length - 1, 1)) >= 5 ? quantidadeCedula - 1 : quantidadeCedula;

            if (quantidadeCedula > 0)
            {
                return new Cedula
                {
                    TipoCedula = "Nota 20",
                    Quantidade = quantidadeCedula
                };
            }

            return null;
        }

        private static Cedula VerificaNota10(decimal valorSaque)
        {

            var quantidadeCedula = Convert.ToInt32(valorSaque / 10);

            var valorString = valorSaque.ToString();

            quantidadeCedula = Convert.ToInt32(valorString.Substring(valorString.Length - 1, 1)) >= 5 ? quantidadeCedula - 1 : quantidadeCedula;

            if (quantidadeCedula > 0)
            {
                return new Cedula
                {
                    TipoCedula = "Nota 10",
                    Quantidade = quantidadeCedula
                };
            }

            return null;
        }
    }
}

