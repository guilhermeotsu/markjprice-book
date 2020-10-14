using System;

namespace Packt.Shared
{
    [Flags]
    public enum LugaresFavoritos : byte
    {
        None = 0b_0000_0000, // 0
        Praia = 0b_0000_0010, // 2  
        Trilha = 0b_0000_0100, // 4
        Restaurante = 0b_0000_1000, // 8
        Bar = 0b_0001_0000 // 16
    }
}