using System;
using System.Transactions;

namespace Aula05_CalculoCorretoSalarioLiquido
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  Exemplo de como fazer o cálculo em:
             *  https://www.contabeis.com.br/noticias/42234/calculo-da-nova-tabela-progressiva-do-inss-aliquotas-e-parcela-a-deduzir/
             */


            string nome;
            double salario_bruto = 0;   


            Console.WriteLine("Bem-vindo ao Sistema de Cálculo de Salário Liquido");

            Console.WriteLine("Olá, qual é o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite seu salário bruto:");
            salario_bruto = Convert.ToDouble(Console.ReadLine());


            /* Entre cada parcela, o cálculo é feito considerando o máximo e o mínimo destas e a alíquota a 
             * ser aplicada. Enquanto o valor do salário não é atingido, é considerado o teto da faixa salarial.

                Veja como fica o cálculo para um salário de R$ 3.000,00 como exemplo, que se encontra na 2ª faixa:

                - 1ª faixa salarial: 1.045,00 x 0,075 = 78,38
                - 2ª faixa salarial: [2.089,60 - 1.045,00] x 0,09 = 1.044,60 x 0,09 = 94,01
                - Faixa que atinge o salário: [3.000,00 - 2.089,60] x 0,12 = 910,40 x 0,12 = 109,25
                - Total a recolher: 109,25 + 94,01 + 78,38 = 281,64

                Com este resultado é possível calcular a alíquota efetiva que se encontra em 
                cerca de 9,39% (281,64 ÷ 3.000,00).
             */

            double primeira_faixa = 0.0;
            double segunda_faixa = 0.0;
            double terceira_faixa = 0.0;
            double quarta_faixa = 0.0;


            if(salario_bruto <= 1045.00)    // 3000 -NO
            {
                primeira_faixa = salario_bruto * 0.075;
            }


            if (salario_bruto > 1045.00) 
            {
                primeira_faixa = 1045.00 * 0.075;

                // Se menor q 2089.60 é a segunda faixa
                if(salario_bruto <= 2089.60) 
                {
                    segunda_faixa = (salario_bruto - 1045.00) * 0.09;
                } 

                // Se maior ou igual que 2086.61 calcular a segunda faixa sobre o valor devido
                if(salario_bruto >= 2086.61)
                {
                    segunda_faixa = (2086.60 - 1045) * 0.09;

                    // Se até 3134.40, calcular a terceira faixa do valor devido
                    if(salario_bruto <= 3134.40)
                    {
                        terceira_faixa = (salario_bruto - 2086.61) * 0.12;
                    }

                    if(salario_bruto >= 3134.41)
                    {
                        terceira_faixa = (3134.40 - 2086.61) * 0.12;

                        // Se até 6101.06
                        if(salario_bruto <= 6101.06)
                        {
                            quarta_faixa = (salario_bruto - 3134.41) * 0.14;
                        }

                        if(salario_bruto >= 6101.07)
                        {
                            quarta_faixa = (6101.06 - 3134.41) * 0.14;
                        }
                    }
                }
            }









            Console.WriteLine("Valor da primeira faixa 7.5%  : " + primeira_faixa.ToString("0.00") );
            Console.WriteLine("Valor da segunda faixa    9%  : " + segunda_faixa.ToString("0.00") );
            Console.WriteLine("Valor da terceira faixa  12%  : " + terceira_faixa.ToString("0.00") );
            Console.WriteLine("Valor da quarta faixa    14%  : " + quarta_faixa.ToString("0.00") );


            double total_inss = primeira_faixa + segunda_faixa + terceira_faixa + quarta_faixa;

            Console.WriteLine("Total de INSS = " + total_inss.ToString("0.00") );




                /*

            if (salario_bruto <= 1045)
            {
                valor_descontado_inss = salario_bruto * (7.5 / 100);

            }
            else if (salario_bruto >= 1045.01 && salario_bruto <= 2089.6)
            {
                valor_descontado_inss = salario_bruto * 0.09;

            }
            else if (salario_bruto >= 2086.61 && salario_bruto <= 3134.40)
            {
                valor_descontado_inss = salario_bruto * (12.0 / 100);

            }
            else if (salario_bruto >= 3134.41 && salario_bruto <= 6101.06)
            {
                valor_descontado_inss = salario_bruto * (14.0 / 100);
            }
                */



        }
    }
}
