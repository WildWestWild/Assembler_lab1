using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembler_Lab_1
{
    class virtual_machine
    {
        private byte[,] byteCommandTable = new byte[5, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        public void InputCMD()
        {
            Console.WriteLine("Имитатор виртуальной машины принимает на вход двоичные комманды.");
            Console.WriteLine("Ожидается двоичная комманда");
            string inputCommand = Console.ReadLine(); // Читаем команду
            byteCommandTable = stringInCommandTable(inputCommand); // Перепишем строку в таблицу
            SwitchCMDType(byteCommandTable);
        }
        private byte[,] stringInCommandTable(string inputCommand)
        {
            byte countOfTypeCommand = 5; // Колличество типов команд
            byte lengthOneCommand = 4; // Размер любого типа комманд
            int lenghtString = inputCommand.Length;
            byte line = 0;
            if (lenghtString == 0)
            {
                throw new Exception("Отсутсвие комманды");
            }
            for (int i = 0; i < countOfTypeCommand; i++)
            {
                for (int j = 0; j < lengthOneCommand; j++)
                {
                    if (line < lenghtString && inputCommand[line] == '1')
                    {
                        byteCommandTable[i, j] = 1;
                    }
                    line++;
                }
            }
            return byteCommandTable;
        }
        private void SwitchCMDType(byte[,] byteCommandTable)
        {
            DefineType(byteCommandTable[0, 0], byteCommandTable[0, 1], byteCommandTable[0, 2], byteCommandTable[0, 3]);
            DefineLiteral(byteCommandTable[1, 0], byteCommandTable[1, 1], byteCommandTable[1, 2], byteCommandTable[1, 3]);
            DefineDestination(byteCommandTable[2, 0], byteCommandTable[2, 1], byteCommandTable[2, 2], byteCommandTable[2, 3]);
            DefineOperator(byteCommandTable[3, 0], byteCommandTable[3, 1], byteCommandTable[3, 2], byteCommandTable[3, 3]);
            DefineOperator(byteCommandTable[4, 0], byteCommandTable[4, 1], byteCommandTable[4, 2], byteCommandTable[4, 3]);
        }

        private void DefineOperator(params byte[] command)
        {
            int switchCommand = byteArrayInCommand(command);
            switch (switchCommand)
            {
                default:
                    break;
            }
        }

        private void DefineDestination(params byte[] command)
        {
            int switchCommand = byteArrayInCommand(command);
            switch (switchCommand)
            {
                default:
                    break;
            }
        }

        private void DefineLiteral(params byte[] command)
        {
            int literalCommand = byteArrayInCommand(command);
            string literal = Convert.ToString(literalCommand, 10);
        }

        private void DefineType(params byte[] command)
        {
            int switchCommand = byteArrayInCommand(command);

            switch (switchCommand)
            {
                default:
                    break;
            }
        }
        private int byteArrayInCommand(byte[] command)
        {
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                result = result * 10 + command[i];
            }
            return result;
        }
    }
}
