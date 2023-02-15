using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionLibrary.Interfaces;

namespace EncryptionLibrary.Abstractions
{
    public abstract class Encryption : IEncryption
    {
        protected string? Line { get; set; }

        public Encryption(string line) => Line = line;

        protected readonly char[] arrayAlphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public abstract string Encrypt();
        public abstract string Decrypt();

        private protected int[] GetArrayKeys(char[] alphavit)
        {
            int[] massive = new int[Line.Length];

            for (int i = 0; i < Line.Length; i++)
            {
                if (Convert.ToString(Line[i]) == String.Empty) massive[i] = -1;
                else massive[i] = Array.IndexOf(alphavit, Line[i]);
            }

            return massive;
        }
    }
}

//TODO: Произвести рефакторинг кода и обновить код. Особенно касается класса Caesar
//TODO: Сделать возможным шифрование с русским алфавитом + упростить методы получения шифрованных массивов во всех классах
//TODO: Сделать возможность определения user`ом другого алфавита.
//TODO: Вынести базовую реализацию свойства Line в Encryption с возможностью переопределенмя или скрытия свойства.
//TODO: После реализации поиграться с событиями и делегатами.
//TODO: В классе Vernam осуществить проверку Line на соответствие с byte символа алфавита
//TODO: Vernam - Возвращать Encrypt в byte[]
//TODO: Добавить возможность шифровки и дешифровки многострочного сообщения
//TODO: Протестировать каждый класс на возможность работы с шифровкой и дешифровкой как в отдельных экземплрах, так и в одном и том же экземпляре.