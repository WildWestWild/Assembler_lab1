using System;

namespace Assembler_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int pc = 0;
            int[] Reg = new int[16];
            int[] cmem = new int[1024];
            int[] dmem = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160 };
            int cmd, cmdtype, literal, dest, op1, op2;


            cmem[0] = 0x1000AA00;
            cmem[1] = 0x20000015;
            cmem[2] = 0x30000001;
            cmem[3] = 0x40001553;
            cmem[4] = 0x500000A5;


            while (pc < 10)
            {
                cmd = cmem[pc];

                cmdtype = (cmd >> 28) & 0x0F;
                literal = (cmd >> 12) & 0xFFFF;
                dest = (cmd >> 8) & 0x0F;
                op1 = (cmd >> 4) & 0x0F;
                op2 = cmd & 0x0F;

                switch (cmdtype)
                {
                    case 1: Reg[dest] = literal; pc++; break; 
                    case 2: Reg[op1] = dmem[Reg[op2]]; pc++; break;
                    case 3: Reg[dest] = Reg[op1] + Reg[op2]; pc++; break;
                    case 4: Reg[dest] = Reg[op1] + literal; pc++; break;
                    case 5: if (Reg[op1] != Reg[op2]) { pc = 0; } else { pc++; } break;
                    default: pc++; break;
                }
                Console.Write(pc + "," + Reg[0] + "  ");
            }
            Console.WriteLine(Reg[0]);
        }
    }
}
